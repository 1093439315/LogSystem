import Cookies from 'js-cookie';
// cookie保存的天数
import config from '../config/config';
import axios from 'axios';
import env from '../config/env';
import {forEach, hasOneOf} from '@/libs/tools';

const ajaxUrl = env === 'development' ?
    'http://127.0.0.1:8888' :
    env === 'production' ?
        'https://www.url.com' :
        'https://debug.url.com';

export const TOKEN_KEY = 'token';

let util = {};

util.ajax = axios.create({
    baseURL: ajaxUrl,
    timeout: 30000
});

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
    return [{
        name: 'home',
        to: '/'
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
    return item.children && item.children.length !== 0
};

const showThisMenuEle = (item, access) => {
    if (item.meta && item.meta.access && item.meta.access.length) {
        if (hasOneOf(item.meta.access, access)) return true
        else return false
    } else return true
};
