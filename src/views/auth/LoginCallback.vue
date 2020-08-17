<template>
  <div></div>
</template>

<script lang="ts">
import Vue from "vue";
import Oidc from "oidc-client";
import Component from "vue-class-component";
import { namespace } from 'vuex-class';
@Component
export default class LoginCallback extends Vue {
  @(namespace("auth").Action("updateAccessToken")) updatedAccessToken: any;

  async mounted() {
    const userManager = new Oidc.UserManager({response_mode: "query"});
    await userManager.signinRedirectCallback();
    await this.updatedAccessToken();
    this.$router.push("/");
  }
}
</script>
