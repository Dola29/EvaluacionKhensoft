import Vue from 'vue'
import App from './App.vue'
import router from './router'
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'
//Bootstrap-Vue
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import moment from 'moment';

Vue.use(BootstrapVue)
Vue.use(IconsPlugin)

//SweetAlert
import swal from 'sweetalert2';

window.swal = swal;

const toast = swal.mixin({
    toast: true,
    position: 'top-end',
    showConfirmButton: false,
    timer: 3000
});

window.toast = toast;

//Axios
window.axios = require('axios');

//BackEnd-URL
window.be_url = "https://localhost:44392/api";

//filters
Vue.filter('myDate', function(date){
  moment.locale(); 
  return moment(date).format('DD/MM/YYYY');
});

Vue.config.productionTip = false

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
