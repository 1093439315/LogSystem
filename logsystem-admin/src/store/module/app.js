import {
    getBreadCrumbList,
    setTagNavListInLocalstorage,
    getMenuByRouter,
    getTagNavListFromLocalstorage,
    getHomeRoute
} from '@/libs/util';
import routers from '@/router/routers';

export default {
    state: {
        //面包肩列表
        breadCrumbList: [],
        tagNavList: [],
        //home页路由
        homeRoute: getHomeRoute(routers),
        local: ''
    },
    getters: {
        menuList: (state, getters, rootState) => getMenuByRouter(routers, '')//rootState.user.access
    },
    mutations: {
        //设置面包肩列表
        setBreadCrumb(state, routeMetched) {
            state.breadCrumbList = getBreadCrumbList(routeMetched);
        },
        setTagNavList(state, list) {
            if (list) {
                state.tagNavList = [...list];
                setTagNavListInLocalstorage([...list]);
            } else state.tagNavList = getTagNavListFromLocalstorage();
        },
        addTag(state, item, type = 'unshift') {
            if (state.tagNavList.findIndex(tag => tag.name === item.name) < 0) {
                if (type === 'push') state.tagNavList.push(item);
                else state.tagNavList.unshift(item);
                setTagNavListInLocalstorage([...state.tagNavList]);
            }
        },
        setLocal(state, lang) {
            state.local = lang;
        }
    }
};
