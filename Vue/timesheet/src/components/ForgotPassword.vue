<template>
    <div id="app">
        <div>
            <div class="container">
                <div class="row">
                    <div class="col-lg-4 col-md-6 col-sm-8 mx-auto">
                        <div class="card login">
                            <h1>Reset password</h1>
                            <form class="form-group">
                                <input v-model="email" type="text" class="form-control" placeholder="Email"
                                    required />
                                <br />
                                <input v-model="password" type="password" class="form-control" placeholder="Password"
                                    required />
                                <br />
                                <input type="submit" class="btn btn-primary" @click="doLogin" />
                                <a href="#">Forgot your password?</a>
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
            username: "",
            password: "",
            records: "",
            emptyFields: false
        };
    },
    async created() {
        this.token = await fetchUser();
    },
    async mounted() {
        this.user = await this.fetchUser();
    },
    methods: {
        async getToken() {
            const token = await Cookie.read("token");
            return token;
        },
        async fetchUser() {
            const user = await api.get("user", { token: this.token });
            return user;
        },
    },

    //       async doLogin() {
    //          if (this.username === "" || this.password === "") {
    //             this.emptyFields = true;
    //          } else {
    //             alert("You are now logged in");
    //          }
    //       },
    //       async create() {
    //             const isUpdate = !!this.model.id;
    //             if (isUpdate) {
    //                await api.update(this.model.id, this.model);
    //             } else {
    //                await api.create(this.model);
    //             }
    // }
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
