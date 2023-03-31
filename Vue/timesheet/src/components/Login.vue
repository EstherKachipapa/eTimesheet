<template>
  <div id="app">
    <div class="login-page">
      <div>
        <img source="./assets/logo.png" alt="" />
      </div>
      <div class="container">
        <div class="row">
          <div class="col-lg-4 col-md-6 col-sm-8 mx-auto">
            <div class="card login">
              <h1>Login your account</h1>
              <!-- <form class="form-group">
                <input v-model="username" type="text" class="form-control" placeholder="Username" required />
                <br />
                <input v-model="password" type="password" class="form-control" placeholder="Password" required/>
                <br />
                <input type="submit" class="btn btn-primary" @click="doLogin" />
                <b-btn type="submit" variant="success">Login</b-btn>
                <a href="#">Forgot your password?</a>
              </form> -->
              <form>
                <b-form-group label="Username" style="color: #28c69f">
                  <b-form-input type="text" v-model="model.username" required></b-form-input>
                </b-form-group>
                <b-form-group label="Password" style="color: #28c69f">
                  <b-form-input v-model="model.password" type="password" required></b-form-input>
                </b-form-group>
                <br>
                <div>
                  <b-btn type="submit" @click="authenticateUser()" variant="success">Login</b-btn>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import api from "@/LoginApiService";

export default {
  data() {
    return {
      loading: false,
      records: [],
      model: {},
      // doLogin: "",
      username: "",
      password: ""
    };
  },
  async created() {
    // this.getAll()
  },
  methods: {
    //  async authenticateUser() { 
    //     console.log(this.username, this.password)
    //     await api.login(this.username, this.password)
    //   },
    async authenticateUser() {
      //const isUpdate = !!this.model.id;
        await api.login(this.model)
      

      // Clear the data inside of the form
      // this.model = {}

      // // Fetch all records again to have latest data
      // await this.getAll()
    },
  }
}
</script>

<style>
p {
  line-height: 1rem;
}

.card {
  padding: 20px;
}

.login-page {
  align-items: center;
  display: flex;
  height: 100vh;

}
</style>
