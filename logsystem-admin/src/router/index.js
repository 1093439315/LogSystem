import Vue from 'vue';
import Router from 'vue-router';
import routes from './routers';
import iView from 'iview';
import Util from '../libs/util';
import store from '@/store';


Vue.use(Router);

const LOGIN_PAGE_NAME = 'login';

const router = new Router({
    routes,
    mode: 'history'
});

router.beforeEach((to, from, next) => {
    iView.LoadingBar.start();
    const token = Util.getToken();
    // 未登录且要跳转的页面不是登录页 则跳转到登录页
    if (!token && to.name !== LOGIN_PAGE_NAME) {
        next({
            name: LOGIN_PAGE_NAME, // 跳转到登录页
            query: {redirect: to.fullPath} //附带登录后返回的地址
        });
    }
    // 未登陆且要跳转的页面是登录页 则直接跳转
    else if (!token && to.name === LOGIN_PAGE_NAME) {
        next();
    }
    // 已登录且要跳转的页面是登录页 则跳转到首页
    else if (token && to.name === LOGIN_PAGE_NAME) {
        next({
            name: 'home' // 跳转到默认首页
        });
    }
    //已登录且要跳转的页面不是登录页 根据权限加载和跳转
    else {
        //有权限则跳转到该页面
        //无权限跳转到首页 目前默认都有权限
        next();
    }
});

router.afterEach(to => {
    iView.LoadingBar.finish();
    Util.title(to.meta.title);
    window.scrollTo(0, 0);
});

export default router;
