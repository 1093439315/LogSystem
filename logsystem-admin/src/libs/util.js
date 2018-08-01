import Cookies from 'js-cookie';
// cookie保存的天数
import config from '../config/config';
import {forEach, hasOneOf} from '@/libs/tools';
import routers from '@/router/routers';

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