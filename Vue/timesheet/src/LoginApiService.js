import Vue from 'vue'
import axios from 'axios'

const client = axios.create({
  baseURL:  'https://localhost:7199/api/Account/login',
  json: true
})

export default {
    async execute(method, resource, data) {
      return client({
        method,
        url: resource,
        data,
      }).then(req => {
        return req.data
      })
    },
  login(data) { 
    return this.execute('post', '/', data)
  }
  }