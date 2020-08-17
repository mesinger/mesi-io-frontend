import { AccessTokenHandler } from '@/service/AccessTokenHandler';
import { MutationTree } from "vuex";
import { AuthenticationState } from "./types";

const accessTokenHandler = new AccessTokenHandler();

export const mutations: MutationTree<AuthenticationState> = {
  authorizeSuccess(state: AuthenticationState, accessToken: string) {
    state.accessToken = accessToken;
    accessTokenHandler.persistAccessToken(accessToken);
  },
  logout(state: AuthenticationState) {
    state.accessToken = "";
    accessTokenHandler.deleteAccessToken();
  }
};
