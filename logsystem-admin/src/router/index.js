import Vue from 'vue';
import Router from 'vue-router';
import routes from './routers';
import iView from 'iview';
import Util from '../libs/util';

Vue.use(Router);

const router = new Router({
    routes,
    mode: 'history'
});

router.beforeEach((to, from, next) => {
    iView.LoadingBar.start();
    Util.title(to.meta.title);
    next();
});

router.afterEach(to => {
    iView.LoadingBar.finish()
    window.scrollTo(0, 0)
});

export default router
