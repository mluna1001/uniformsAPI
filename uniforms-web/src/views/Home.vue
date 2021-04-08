<template>
    <div>
        <div>
            <h1 class="title">
                "Bienvenido a uniformes"
            </h1>
        </div>
        <div>
            <v-data-table
                :headers="headers"
                :items="vGarmentDelivers"
                :items-per-page="10"
                class="elevation-1"
            ></v-data-table>
        </div>
    </div>    
</template>

<script>
import axios from 'axios';

export default {
    name: 'Home',
    data: () => ({
        vGarmentDelivers: [],
        vEmployees: [],
        vGarments: [],
        vSizes: [],
        garmentDeliver: {},
        headers: [
            { text: "Id", align: "center", value: "deliveryId" },
            { text: "IdEmpleado", align: "center", value: "employeeId" },
            { text: "Nombre", value: "name" },
            { text: "Grupo", align: "center", value: "group" },
            { text: "Uniforme entregado", value: "garment" },
            { text: "Talla", value: "deliverSize" },
            { text: "Fecha", value: "deliveryDate" },
        ]
    }),
    methods: {
        default(){
            fetch('https://localhost:44334/api/Delivery')
                .then(response => {
                    return response.json();
                })
                .then(data => {
                    if (data.success) {
                        this.vGarmentDelivers = data.data;
                    }
                })
                .catch(err => console.error(err));

        }
    },
    created() {
        this.default();
    }
}
</script>