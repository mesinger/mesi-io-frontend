import { ActionTree } from "vuex";
import { AuthenticationState } from "./types";
import { RootState } from "../types";
import { AuthenticationService } from "@/service/AuthenticationService";

const authService = new AuthenticationService();

export const actions: ActionTree<AuthenticationState, RootState> = {
  async authorize({ commit }): Promise<void> {
    await authService.login();
  },
  async logout({ commit }): Promise<void> {
    commit("logout");
    await authService.logout();
  },
  async updateAccessToken({ commit }): Promise<void> {
    const user = await authService.getUser();
    if(user) {
      commit("authorizeSuccess", user.access_token)
    }
  }
};
