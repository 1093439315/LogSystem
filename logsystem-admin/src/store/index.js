import Vue from 'vue';
import Vuex from 'vuex';

import vertification from './module/vertification';
import app from './module/app';
import platform from './module/platform';

Vue.use(Vuex);

export default new Vuex.Store({
    state: {
        //
    },
    mutations: {
        //
    },
    actions: {
        //
    },
    modules: {
        vertification,
        app,
        platform
    }
});
