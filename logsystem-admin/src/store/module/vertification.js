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
                    commit('setToken', res.Token);
                    resolve();
                }).catch(err => {
                    reject(err);
                });
            });
        },
    }
};
