import Vue from 'vue';
import Router from 'vue-router';
import routes from './routers';
import iView from 'iview';
import Util from '../libs/util';

Vue.use(Router);

const LOGIN_PAGE_NAME = 'login'

const router = new Router({
    routes,
    mode: 'history'
});

router.beforeEach((to, from, next) => {
    iView.LoadingBar.start();
    const token = Util.getToken();
    Util.title(to.meta.title);
    // 未登录且要跳转的页面不是登录页
    if (!token && to.name !== LOGIN_PAGE_NAME) {
        next({
            name: LOGIN_PAGE_NAME // 跳转到登录页
        });
    }
    // 未登陆且要跳转的页面是登录页
    else if (!token && to.name === LOGIN_PAGE_NAME) {
        next();
    }
    // 已登录且要跳转的页面是登录页
    else if (token && to.name === LOGIN_PAGE_NAME) {
        next({
            name: 'home' // 跳转到默认首页
        });
    }
    //根据权限加载和跳转
    else {
        // store.dispatch('getUserInfo').then(user => {
        //     if (canTurnTo(to.name, user.access, routes)) next() // 有权限，可访问
        //     else next({ replace: true, name: 'error_401' }) // 无权限，重定向到401页面
        // })
    }
});

router.afterEach(to => {
    iView.LoadingBar.finish()
    window.scrollTo(0, 0)
});

export default router
