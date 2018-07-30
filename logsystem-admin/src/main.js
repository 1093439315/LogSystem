import Vue from 'vue';
import iView from 'iview';
import router from './router'
import Vuex from 'vuex';
import App from './app.vue';
import 'iview/dist/styles/iview.css';

Vue.use(Vuex);
Vue.use(iView);

const store = new Vuex.Store({
    state: {

    },
    getters: {

    },
    mutations: {

    },
    actions: {

    }
});

new Vue({
    el: '#app',
    router: router,
    store: store,
    render: h => h(App)
});
