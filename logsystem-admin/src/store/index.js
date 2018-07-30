import Vue from 'vue';
import Vuex from 'vuex';

import user from './module/user';
import vertification from './module/vertification';

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
        vertification
    }
});
