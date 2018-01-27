

var clientsApp = new Vue({
    el: '#app-clients',
    data: {
        clients: clients,
    },
    methods: {
        actionClicked: function () {
            console.log("Congrats!! Vue.js is connected to the view.")
        }
    }
})