import Vue from "vue";
import VueRouter, { RouteConfig } from "vue-router";
import Home from "../views/Home.vue";
import ClipboardView from "../views/ClipboardView.vue";
import LoginCallback from "../views/auth/LoginCallback.vue";
import LoginCallbackSilent from "../views/auth/LoginCallbackSilent.vue";

Vue.use(VueRouter);

const routes: Array<RouteConfig> = [
  {
    path: "/",
    name: "Home",
    component: Home
  },
  {
    path: "/clipboard",
    name: "Clipboard",
    component: ClipboardView
  },
  {
    path: "/auth/login-callback",
    name: "LoginCallback",
    component: LoginCallback
  },
  {
    path: "/auth/login-callback-silent",
    name: "LoginCallbackSilent",
    component: LoginCallbackSilent
  }
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  linkExactActiveClass: "active",
  routes
});

export default router;
