import Vue from 'vue'
import Router from 'vue-router'
import Hello from '@/components/Hello'
import Login from '@/components/Login'
import User from '@/components/User'
import Activity from '@/components/Activity'
import Project from '@/components/Project'
import Employee from '@/components/Employee'
import Supervisor from '@/components/Supervisor'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Hello',
      component: Hello
    }, 
    {
      path: '/project',
      name: 'Project',
      component: Project
    }, 
    {
      path: '/supervisor',
      name: 'Supervisor',
      component: Supervisor
    }, 
      {
      path: '/employee',
      name: 'Employee',
      component: Employee
    }, 
    {
      path: '/login',
      name: 'Login',
      component: Login
    },
    {
      path: '/activity',
      name: 'Activity',
      component: Activity
    },
    {
      path: '/user',
      name: 'User',
      component: User
    }
  ]
})
