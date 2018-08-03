import Cookies from 'js-cookie';
import config from '../config/config';
import {forEach, hasOneOf} from '@/libs/tools';
import routers from '@/router/routers';
import Enumerable from 'linq';

export const TOKEN_KEY = 'token';

let util = {};

util.title = (title) => {
    title = title ? title : '日志管理系统';
    window.document.title = title;
};

util.getToken = () => {
    const token = Cookies.get(TOKEN_KEY);
    if (token) return token;
    else return false;
};

util.setToken = (token) => {
    Cookies.set(TOKEN_KEY, token, {expires: config.cookieExpires || 1});
};

export default util;

export const showTitle = (item) => {
    return ((item.meta && item.meta.title) || item.name);
};

/**
 * @param {Array} routeMetched 当前路由metched
 * @returns {Array}
 */
export const getBreadCrumbList = (routeMetched) => {
    let res = routeMetched.filter(item => {
        return item.meta === undefined || !item.meta.hide;
    }).map(item => {
        let obj = {
            icon: (item.meta && item.meta.icon) || '',
            name: item.name,
            meta: item.meta
        };
        return obj;
    });
    res = res.filter(item => {
        return !item.meta.hideInMenu;
    });
    //获取home路由
    let homeRoute = getHomeRoute(routers);
    return [{
        name: homeRoute.name,
        to: homeRoute.path,
        icon: homeRoute.meta.icon,
    }, ...res];
};

/**
 * @param {Array} routers 路由列表数组
 * @description 用于找到路由列表中name为home的对象
 */
export const getHomeRoute = routers => {
    let i = -1;
    let len = routers.length;
    let homeRoute = {};
    while (++i < len) {
        let item = routers[i];
        if (item.children && item.children.length) {
            let res = getHomeRoute(item.children);
            if (res.name) return res;
        } else {
            if (item.name === 'home') homeRoute = item;
        }
    }
    return homeRoute;
};

/**
 * @param {Array} list 通过路由列表得到菜单列表
 * @returns {Array}
 */
export const getMenuByRouter = (list, access) => {
    let res = [];
    forEach(list, item => {
        if (!item.meta || (item.meta && !item.meta.hideInMenu)) {
            let obj = {
                icon: (item.meta && item.meta.icon) || '',
                name: item.name,
                meta: item.meta
            };
            if ((hasChild(item) || (item.meta && item.meta.showAlways)) && showThisMenuEle(item, access)) {
                obj.children = getMenuByRouter(item.children, access);
            }
            if (item.meta && item.meta.href) obj.href = item.meta.href;
            if (showThisMenuEle(item, access)) res.push(obj);
        }
    });
    return res;
};

/**
 * @description 本地存储和获取标签导航列表
 */
export const setTagNavListInLocalstorage = list => {
    localStorage.tagNaveList = JSON.stringify(list);
};

/**
 * @returns {Array} 其中的每个元素只包含路由原信息中的name, path, meta三项
 */
export const getTagNavListFromLocalstorage = () => {
    const list = localStorage.tagNaveList;
    return list ? JSON.parse(list) : [];
};

export const hasChild = (item) => {
    return item.children && item.children.length !== 0;
};

const showThisMenuEle = (item, access) => {
    if (item.meta && item.meta.access && item.meta.access.length) {
        if (hasOneOf(item.meta.access, access)) return true;
        else return false;
    } else return true;
};

/**
 * @param {Array} list 标签列表
 * @param {String} name 当前关闭的标签的name
 */
export const getNextName = (list, name) => {
    let res = '';
    if (list.length === 2) {
        res = 'home';
    } else {
        if (list.findIndex(item => item.name === name) === list.length - 1) res = list[list.length - 2].name;
        else res = list[list.findIndex(item => item.name === name) + 1].name;
    }
    return res;
};

/**
 * @param {*} list 现有标签导航列表
 * @param {*} newRoute 新添加的路由原信息对象
 * @description 如果该newRoute已经存在则不再添加
 */
export const getNewTagList = (list, newRoute) => {
    const {name, path, meta} = newRoute;
    let newList = [...list];
    if (newList.findIndex(item => item.name === name) >= 0) return newList;
    else newList.push({name, path, meta});
    return newList;
};

/**
 * 通过配置和路由的配置获取菜单列表
 * @param menuConfig
 * @param routes
 */
export const getMenuListByConfig = (menuConfig, routes) => {
    let res = [];

    //遍历配置获取顶级菜单
    let topMenus = Enumerable.from(menuConfig)
        .select(item => item.parent)
        .distinct()
        .where(item => Enumerable.from(menuConfig).any(cf => cf.name != item))
        .where(item => Enumerable.from(routes).any(ro => ro.name == item))
        .toArray();

    //开始遍历菜单
    Enumerable.from(topMenus)
        .forEach(item => {
            //获取菜单项
            let menuItem = getMenuItems(item, routes, menuConfig);
            res.push(menuItem);
        });

    return res;
};

/**
 * 根据菜单项获取菜单的所有菜单和子菜单
 * @param menuRouteName
 * @param routes
 */
export const getMenuItems = (menuRouteName, routes, menuConfig) => {
    let menuItem = undefined;

    //获取菜单项
    menuItem = convertToMenuItem(menuRouteName, routes, menuConfig);
    if (menuItem) {
        //遍历孩子
        if (!menuItem.canRediect) {
            menuItem.children = [];
            let children = Enumerable.from(menuConfig).where(cf => cf.parent == menuRouteName).toArray();
            Enumerable.from(children).forEach(child => {
                var childMenuItems = getMenuItems(child.name, routes, children);
                menuItem.children.push(childMenuItems);
            });
        }
    }
    return menuItem;
};

/**
 * 根据name从路由配置中获取路由
 * @param name 路由地址
 * @param routes 路由配置
 */
export const getRouteByName = (name, routes) => {
    let findRoute = undefined;
    Enumerable.from(routes)
        .forEach(item => {
            if (item.name == name) {
                findRoute = item;
                return false;
            }
            else {
                if (item.children) {
                    findRoute = getRouteByName(name, item.children);
                    if (findRoute) return false;
                }
            }
        });
    return findRoute;
};

/**
 * 根据name从路由配置中获取菜单项
 * @param name
 * @param routes
 * @param menuConfig
 * @returns {*}
 */
export const convertToMenuItem = (name, routes, menuConfig) => {
    let findRoute = getRouteByName(name, routes);
    if (findRoute) {
        var hasChild = Enumerable.from(menuConfig).any(cf => cf.parent == name);
        return {
            name: findRoute.name,//路由Id
            routePath: findRoute.path,//路由地址
            title: findRoute.meta.title,//标题
            icon: findRoute.meta.icon,//图标
            canRediect: !hasChild,//是否可导航，有孩子不可导航
        };
    }
    return false;
};
