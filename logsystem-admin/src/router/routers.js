const routers = [
    {
        path: '/',
        name: 'home',
        meta: {
            title: ''
        },
        component: (resolve) => require(['../views/index.vue'], resolve)
    }
];

export default routers;
