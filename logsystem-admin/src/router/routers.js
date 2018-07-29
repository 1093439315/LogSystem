const routers = [
    {
        path: '/aa',
        name: 'home',
        meta: {
            title: ''
        },
        component: (resolve) => require(['../views/index.vue'], resolve)
    }
];

export default routers;
