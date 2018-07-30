import Cookies from 'js-cookie';
// cookie保存的天数
import config from '../config/config';
import axios from 'axios';
import env from '../config/env';

const ajaxUrl = env === 'development' ?
    'http://127.0.0.1:8888' :
    env === 'production' ?
        'https://www.url.com' :
        'https://debug.url.com';

export const TOKEN_KEY='token';

let util = {};

util.ajax = axios.create({
    baseURL: ajaxUrl,
    timeout: 30000
});

util.title=(title) => {
    title = title ? title : '日志管理系统';
    window.document.title = title;
};

util.getToken= () => {
    const token = Cookies.get(TOKEN_KEY);
    if (token) return token;
    else return false;
};

util.setToken = (token) => {
    Cookies.set(TOKEN_KEY, token, {expires: config.cookieExpires || 1});
};

export  default  util;


