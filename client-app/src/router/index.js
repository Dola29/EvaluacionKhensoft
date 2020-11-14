import Vue from 'vue'
import VueRouter from 'vue-router'
//components
import Permission from '../views/Permission/Permission.vue'
//import Register from '../views/Permission/Register.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Permission',
    component: Permission
  },
  // {
  //   path: '/Register',
  //   name: 'Register',
  //   component: Register
  // },
 
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
