import Vue from 'vue';
import Router from 'vue-router';
import Home from './../views/Home.vue';
import Uniforms from './../views/Uniforms.vue';

Vue.use(Router);

export default new Router({
    routes: [
        {
            path: '/',
            name: 'Inicio',
            component: Home
        },
        {
            path: '/about',
            name: 'Entrega de uniformes',
            component: Uniforms
        }
    ]
});
