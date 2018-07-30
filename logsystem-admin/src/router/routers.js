const routers = [
    //首页 默认页
    {
        path: '/',
        meta: {
            title: '首页'
        },
        component: (resolve) => require(['../views/index.vue'], resolve)
    },
    //登录页
    {
        path: '/login',
        meta: {
            title: '登录'
        },
        component: (resolve) => require(['../views/login/login.vue'], resolve)
    }
];
export default routers;
