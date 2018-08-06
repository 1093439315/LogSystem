import {login} from '@/api/vertification';
import Util from '@/libs/util';

export default {
    state: {
        userName: '',
        userId: '',
        avatorImgPath: '',
        token: Util.getToken(),
        access: ''
    },
    mutations: {
        setAvator(state, avatorPath) {
            state.avatorImgPath = avatorPath;
        },
        setUserId(state, id) {
            state.userId = id;
        },
        setUserName(state, name) {
            state.userName = name;
        },
        setAccess(state, access) {
            state.access = access;
        },
        setToken(state, token) {
            state.token = token;
            Util.setToken(token);
        }
    },
    actions: {
        // 登录
        handleLogin({commit}, {userName, password}) {
            userName = userName.trim();
            return new Promise((resolve, reject) => {
                login({
                    userName,
                    password
                }).then(res => {
                    commit('setToken', res.Data.Token);
                    resolve();
                }).catch(err => {
                    reject(err);
                });
            });
        },
        // 退出登录
        handleLogOut({state, commit}) {
            return new Promise((resolve, reject) => {
                // 如果你的退出登录无需请求接口，则可以直接使用下面三行代码而无需使用logout调用接口
                commit('setToken', '');
                commit('setAccess', []);
                resolve();
            });
        },
    }
};
