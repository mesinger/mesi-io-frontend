<template>
  <div id="app">
    <NavBar></NavBar>

    <main class="bg-surface">
      <div id="main">
        <div class="pt-3"></div>

        <router-view />
      </div>
    </main>

    <Footer></Footer>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator";
import NavBar from "@/components/Navbar.vue";
import Footer from "@/components/Footer.vue";
@Component({
  components: {
    NavBar,
    Footer
  }
})
export default class App extends Vue {}
</script>

<style lang="scss">
@import "assets/style/bootstrap-custom.scss";
@import "../node_modules/bootstrap/scss/bootstrap.scss";

.dashboard-item-container {
  padding: 6px 5px 6px 5px;
}
.dashboard-item {
  padding: 4px 6px 4px 6px;
  box-shadow: 5px 6px 10px rgb(214, 211, 211);
}
</style>
