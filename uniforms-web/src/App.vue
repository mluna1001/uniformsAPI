<template>
    <v-app id="inspire">
        <v-container>
            <v-navigation-drawer
                v-model="drawer"
                app
            >
                <v-list dense>
                    <v-list-item-group color="primary">
                        <v-list-item v-for="(item, i) in vusuario.menuDtoL" :key="i" router :to="item.URLMenu">
                            <v-list-item-icon>
                                <v-icon v-text="item.Icono"></v-icon>
                            </v-list-item-icon>
                            <v-list-item-content>
                                <v-list-item-title v-text="item.Link"></v-list-item-title>
                            </v-list-item-content>
                        </v-list-item>
                    </v-list-item-group>
                </v-list>
            </v-navigation-drawer>

            <v-app-bar app color="primary" dark>
                <v-app-bar-nav-icon @click="drawer = !drawer"></v-app-bar-nav-icon>

                <v-toolbar-title>Uniformes</v-toolbar-title>

                <v-spacer></v-spacer>

               <v-tooltip bottom>
                   <template v-slot:activator="{ on }">
                        <v-btn icon @click="logoutS" slot="activator" v-on="on">
                            <v-icon large>mdi-logout</v-icon>
                        </v-btn>
                   </template>
                    
                    <span>Cerrar sesión</span>
                </v-tooltip>
            </v-app-bar>

            <v-dialog
                v-model="$root.isBusy"
                hide-overlay
                persistent
                width="300"
            >
                <v-card
                    color="primary"
                    dark
                >
                    <v-card-text>
                        Espere por favor...
                        <v-progress-linear
                            indeterminate
                            color="white"
                            class="mb-0"
                        ></v-progress-linear>
                    </v-card-text>
                </v-card>
            </v-dialog>

            <v-main>
                <v-container grid-list-xl row>
                    <v-flex xs12>
                        <transition name="router-anim">
                            <router-view v-if="vusuario !== ''" class="container"></router-view>
                        </transition>
                    </v-flex>
                </v-container>
            </v-main>
        </v-container>
  </v-app>
</template>

<script>

export default {
    name: 'App',
    data() {
        return {
            drawer: false,
            title: 'Hola mundo',
            vusuario: {
                menuDtoL: [
                    {
                        URLMenu: '/',
                        text: '/home',
                        Icono: 'mdi-home',
                        Link: 'Inicio'
                    },
                    {
                        URLMenu: '/uniforms',
                        text: '/uniforms',
                        Icono: 'mdi-information',
                        Link: 'Entrega de uniformes'
                    }
                ]
            }
        }
    },
    created() {
        this.Default();
    },
    methods: {
        logoutS () {
            alert('Cerrando sesión')
        },
        Default() {
            debugger;
            this.$vuetify.theme.themes.name = '';
        }
    },
    components: {
        
    }
}
</script>

<style>
    @import './assets/styles/index.css';
</style>