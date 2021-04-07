import Vue from 'vue';
import Toaster from "v-toaster";
import App from './App.vue';
import vuetify from './plugins/vuetify';
import router from './router';

import 'v-toaster/dist/v-toaster.css'

Vue.use(Toaster, {timeout: 5000});

new Vue({
    vuetify,
    router,
    data: () => ({
        tusuario: {
            usuario: {},
            PerfilDto: {},
        },
        vsnackbar: {
            snackbar: false,
            y: 'top',
            color: 'cyan darken-2',
            x: 'right',
            mode: 'vertical',
            timeout: 6000,
            text: "Hello, I'm a snackbar",
            colores: ['green', 'info', 'error', 'cyan darken-2'],
        },
        isBusy: false,
    }),
    render: h => h(App)
}).$mount('#app');