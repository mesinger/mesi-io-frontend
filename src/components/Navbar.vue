<template>
  <div>
    <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
      <a class="navbar-brand" href="/">
        <img src="~@/assets/img/icon.svg" width="30" height="30" alt="icon" />
        <span class="ml-4 text-caccent">mesi.io</span>
      </a>
      <button
        class="navbar-toggler"
        type="button"
        data-toggle="collapse"
        data-target=".dual-collapse2"
      >
        <span class="navbar-toggler-icon"></span>
      </button>
      <div
        class="navbar-collapse collapse w-100 order-1 order-md-0 dual-collapse2"
      >
        <div class="navbar-nav mr-auto">
          <router-link class="nav-item nav-link" to="/">Home</router-link>
          <router-link class="nav-item nav-link" to="/clipboard"
            >Clipboard</router-link
          >
        </div>
      </div>
      <div class="navbar-collapse collapse w-100 order-3 dual-collapse2">
        <div class="navbar-nav ml-auto" v-if="!isLoggedIn">
          <a class="navbar-btn btn button-navbar nav-item nav-link bg-dark text-white" @click="onLogin">Login</a>
        </div>
        <div class="navbar-nav ml-auto" v-if="isLoggedIn">
          <span class="navbar-text user-welcome-text">
            Hello {{ userName }}
          </span>
          <a class="navbar-btn btn button-navbar nav-item nav-link bg-dark text-white" @click="onLogout">Logout</a>
        </div>
      </div>
    </nav>
    <!-- {{ text }} -->
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop } from "vue-property-decorator";
import { namespace, Getter } from "vuex-class";

@Component
export default class NavBar extends Vue {
  @(namespace("auth").Action("authorize")) authorize: any;
  @(namespace("auth").Action("logout")) logout: any;
  @(namespace("auth").Getter("isLoggedIn")) isLoggedIn!: boolean;
  @(namespace("auth").Getter("userName")) userName!: boolean;

  // get text(): string {
  //   // console.log(this.$store.getters["auth/isLoggedIn"]);
  //   return this.$store.state.auth["accessToken"];
  // }

  onLogin() {
    this.authorize();
  }

  onLogout(): void {
    this.logout();
  }
}
</script>

<style lang="scss" scoped>
.user-welcome-text {
  padding-top: 9px;
  padding-right: 10px;
}
</style>
