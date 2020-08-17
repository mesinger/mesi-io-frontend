<template>
  <div></div>
</template>

<script lang="ts">
import Vue from "vue";
import Oidc from "oidc-client";
import Component from "vue-class-component";
import { namespace } from 'vuex-class';
@Component
export default class LoginCallbackSilent extends Vue {
  @(namespace("auth").Action("updateAccessToken")) updatedAccessToken: any;

  mounted() {
    new Oidc.UserManager({ response_mode: "query" })
      .signinSilentCallback()
      .then(() => this.updatedAccessToken());
  }
}
</script>
