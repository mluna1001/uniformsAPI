<template>
    <div>
        <div>
            <h1 class="title">{{ title }}</h1>
        </div>
        <v-form
            ref="form"
            v-model="valid"
            lazy-validation>
            <v-container fluid>
                <v-row>
                    <v-col cols="6" sm="12" md="6">
                        <v-select
                            :items="vEmployees"
                            item-text="name"
                            item-value="employeeId"
                            :rules="[v => !!v || 'Empleado es requerido']"
                            label="Selecciona empleado:"
                            v-model="vGarmentDeliver.employeeId"
                            @change="setEmployees"
                            required
                            outlined
                        ></v-select>
                    </v-col>
                    <v-col cols="6" sm="12" md="6">
                        <v-select
                            label="Seleccione uniforme a entregar:"
                            :items="vGarments"
                            item-text="description"
                            item-value="garmentId"
                            :rules="[v => !!v || 'Uniforme es requerido']"
                            @change="setGarments"
                            required
                            outlined
                        ></v-select>
                    </v-col>
                </v-row>
                <v-row>
                    <v-col cols="6" sm="12" md="6">
                        <v-select
                            :items="vSizes"
                            item-text="description"
                            item-value="garmentSizeId"
                            label="Selecciona Talla:"
                            :rules="[v => !!v || 'Talla es requerida']"
                            v-model="vGarmentDeliver.garmentSizeID"
                            required
                            outlined
                        ></v-select>
                    </v-col>
                </v-row>
                <v-row>
                    <v-col cols="6" sm="12" md="12">
                        <v-btn
                            :disabled="!valid"
                            color="primary"
                            @click="saveDeliver"
                        >Guardar información de entrega</v-btn>
                    </v-col>
                </v-row>
            </v-container>
        </v-form>
    </div>
</template>

<script>
import axios from 'axios';

export default {
    name: 'Uniforms',
    data: () => ({
        valid: true,
        title: 'Entrega de uniformes',
        vSizes: [],
        vGarments: [],
        vEmployees: [],
        vEmployee: {},
        vGarmentDeliver: { employeeId: 0, garmentSizeID: 0 }
    }),
    created() {
        this.getEmployees();
    },
    methods: {
        getEmployees() {
            this.$root.isBusy = true;
            this.$root.message = 'Cargando datos. Espere por favor...';
            fetch('https://localhost:44334/api/Employees')
                .then(response => response.json())
                .then(data => {
                    if (data.success) {
                        this.vEmployees = data.data;
                        this.$root.isBusy = false;
                    }
            })
                .catch(err => {
                    this.$root.isBusy = false;
                    this.$toaster.error(err);
            });
        },
        setEmployees() {
            this.getGarments(this.vGarmentDeliver.employeeId);
        },
        getGarments(employeeId) {
            this.$root.isBusy = true;
            this.$root.message = 'Cargando uniformes a entregar...';
            fetch(`https://localhost:44334/api/Garment?employeeId=${employeeId}`)
                .then(responseGarm => responseGarm.json())
                .then(dataGarm => {
                    if (dataGarm.success) {
                        this.vGarments = dataGarm.data;
                        this.$root.isBusy = false;
                    }
                })
                .catch(err => {
                    this.$toaster.error(err);
                    this.$root.isBusy = false;
                });
        },
        setGarments(garmentId) {
            this.getSizes(garmentId);
        },
        getSizes(garmentId) {
            this.$root.isBusy = true;
            this.$root.message = 'Cargando tallas del uniforme...';
            fetch(`https://localhost:44334/api/Garment/GetSizes?garmentID=${garmentId}`)
                .then(responseSize => responseSize.json())
                .then(dataSize => {
                    if (dataSize.success) {
                        debugger;
                        this.vSizes = dataSize.data;
                        this.$root.isBusy = false;
                    }
                })
                .catch(err => {
                    this.$toaster.error(err);
                    this.$root.isBusy = false;
                });
        },
        saveDeliver(){
            this.$root.isBusy = true;
            this.$root.message = 'Procesando información...';
            axios.post('https://localhost:44334/api/Delivery', this.vGarmentDeliver)
            .then(response => {
                debugger;
                if (response.data.success) {
                    this.$toaster.success(response.data.message);
                } else {
                    this.$toaster.warning(response.data.message);
                }
                this.$root.isBusy = false;
                this.vGarmentDeliver = { employeeId: 0, garmentSizeID: 0 }
            })
            .catch(err => {
                this.$toaster.error(err);
                this.$root.isBusy = false;
                this.vGarmentDeliver = { employeeId: 0, garmentSizeID: 0 }
            })
        }
    }
}
</script>