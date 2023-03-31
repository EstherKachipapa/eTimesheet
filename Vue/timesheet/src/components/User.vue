<template>
    <div class="container-fluid mt-4">
      <h1 class="h1" style="color: #28c69f"></h1>
        <!-- <b-icon icon="people"></b-icon>Users</h1> -->
      <b-alert :show="loading" variant="info">Loading...</b-alert>
      <b-row>
        <b-col>
          <table class="table table-striped">
            <thead>
              <tr>
                <!-- <th>ID</th> -->
                <th>Username</th>
                <th>Password</th>
                <th>Email</th>
                <th>&nbsp;</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="record in records" :key="record.id">
                <!-- <td>{{ record.id }}</td> -->
                <td>{{ record.username}}</td>
                <td>{{ record.password }}</td>
                <td>{{ record.email }}</td>
                <td class="text-right">
                <a href="#" @click.prevent="updateEmployeeRecord(record)" v-b-modal.modal-1><b-icon icon="pencil-square"></b-icon>Edit</a> - 
                <a href="#" @click.prevent="deleteEmployeeRecord(record.id)"><b-icon icon="trash-fill"></b-icon>Delete</a>
              </td>
              </tr>
            </tbody>
          </table>
        </b-col>
      </b-row>
      <br>
      <br>
      <b-button v-b-modal.modal-1>ADD</b-button>
<b-modal id="modal-1" title="Add user" hide-footer >
            <form @submit.prevent="createEmployeeRecord">
              <b-form-group label="Username" style="color: #28c69f">
                <b-form-input type="text" v-model="model.username"></b-form-input>
              </b-form-group>
              <b-form-group label="Password" style="color: #28c69f">
                <b-form-input v-model="model.password" type="text"></b-form-input>
              </b-form-group>
              <b-form-group label="Email" style="color: #28c69f">
                <b-form-input v-model="model.email" type="email"></b-form-input>
              </b-form-group>
              <br>
              <div>
                <b-btn type="submit" variant="success">Save Record</b-btn>
              </div>
            </form>
</b-modal>
    </div>
  </template>
  
  <script>
    import api from '@/UserApiService';
  
    export default {
      data() {
        return {
          loading: false,
          records: [],
          model: {}
        };
      },
      async created() {
        this.getAll()
      },
      methods: {
        async getAll() {
          this.loading = true
  
          try {
            this.records = await api.getAll()
          } finally {
            this.loading = false
          }
        },
        async updateEmployeeRecord(EmployeeRecord) {
          // We use Object.assign() to create a new (separate) instance
          this.model = Object.assign({}, EmployeeRecord)
        },
        async createEmployeeRecord() {
          const isUpdate = !!this.model.id;
  
          if (isUpdate) {
            await api.update(this.model.id, this.model)
          } else {
            await api.create(this.model)
          }
  
          // Clear the data inside of the form
          this.model = {}
  
          // Fetch all records again to have latest data
          await this.getAll()
        },
        async deleteEmployeeRecord(id) {
          if (confirm('Are you sure you want to delete this record?')) {
            // if we are editing a food record we deleted, remove it from the form
            if (this.model.id === id) {
              this.model = {}
            }
  
            await api.delete(id)
            await this.getAll()
          }
        }
      }
    }
  </script>