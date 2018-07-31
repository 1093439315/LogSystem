const routers = [
    //首页 默认页
    {
        path: '/',
        name: 'home',
        meta: {
            title: '首页'
        },
        component: (resolve) => require(['../views/main/home.vue'], resolve)
    },
    //登录页
    {
        path: '/login',
        name: 'login',
        meta: {
            title: '登录'
        },
        component: (resolve) => require(['../views/login/login.vue'], resolve)
    }
];
export default routers;
