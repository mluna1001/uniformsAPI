import Vue from 'vue';
import Vuetify from 'vuetify/lib';

import colors from 'vuetify/lib/util/colors'
import "vuetify/dist/vuetify.min.css";

Vue.use(Vuetify);

export default new Vuetify({
    theme: {
        themes: {
            light_1: {
                primary: '#3f51b5',
                secondary: '#b0bec5',
                accent: '#8c9eff',
                error: '#b71c1c',
            },
            light_2: {
                primary: '#4caf50',
                secondary: '#e91e63',
                accent: '#cddc39',
                error: '#f44336',
                warning: '#ffc107',
                info: '#607d8b',
                success: '#2196f3'
            },          
            dark: {
                primary: '#4caf50',
            },
        }
    }
});