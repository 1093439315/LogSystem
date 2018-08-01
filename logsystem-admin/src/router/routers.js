import Home from '@/views/main';

const routers = [
    {
        path: '/',
        component: Home,
        children: [
            //首页 默认页
            {
                path: '/',
                name: 'home',
                meta: {
                    hideInMenu: true,
                    notCache: true,
                    icon: 'md-home',
                    title: '首页'
                },
                component: (resolve) => require(['@/views/console-main'], resolve)
            }
        ],
    },
    //登录页
    {
        path: '/login',
        name: 'login',
        meta: {
            title: '登录'
        },
        component: (resolve) => require(['@/views/login'], resolve)
    },
    //系统设置
    {
        path: '/setting',
        name: 'setting',
        meta: {
            title: '系统设置',
            icon: 'md-settings',
        },
        component: Home,
        children: [
            //平台设置
            {
                path: 'platformSetting',
                name: 'platformSetting',
                meta: {
                    icon: 'md-cloud-done',
                    title: '平台设置'
                },
                component: (resolve) => require(['@/views/setting/platform-setting'], resolve)
            },
            //日志设置
            {
                path: 'logSetting',
                name: 'logSetting',
                meta: {
                    icon: 'md-shuffle',
                    title: '日志设置'
                },
                component: (resolve) => require(['@/views/setting/log-setting'], resolve)
            }
        ]
    },
];
export default routers;
