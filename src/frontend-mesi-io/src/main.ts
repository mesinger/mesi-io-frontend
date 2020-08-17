import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import axios from "axios";

import "bootstrap";

Vue.config.productionTip = false;

Vue.prototype.$http = axios;
const token = localStorage.getItem("authorization_token");
if (token) {
  Vue.prototype.$http.defaults.header.common["Authorization"] = token;
}

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount("#app");
