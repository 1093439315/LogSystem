import Vue from 'vue';
import App from './App';
import  router from './router';
import store from './store'
import iView from 'iview';

import 'iview/dist/styles/iview.css';

Vue.use(iView);

new Vue({
    el: '#app',
    router: router,
    store: store,
    render: h => h(App)
});
