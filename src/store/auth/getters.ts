import { GetterTree } from "vuex";
import { AuthenticationState } from "./types";
import { RootState } from "../types";
import { AccessTokenHandler, AccessTokenState } from "@/service/AccessTokenHandler";

const accessTokenHandler = new AccessTokenHandler();

export const getters: GetterTree<AuthenticationState, RootState> = {
  isLoggedIn(state): boolean {
    const tokenState = accessTokenHandler.getState(state.accessToken);
    switch (tokenState as AccessTokenState) {
      case AccessTokenState.None:
        return false;
      case AccessTokenState.Expired:
        accessTokenHandler.refreshToken();
        return true;
      case AccessTokenState.Valid:
        return true;
      default:
        return false;
    }
  },
  userName(state): string {
    const payload = accessTokenHandler.getPayload(state.accessToken);
    if (payload && payload.name) {
      return payload.name;
    }
    return "username";
  },
  userId(state): string {
    const payload = accessTokenHandler.getPayload(state.accessToken);
    if (payload && payload.sub) {
      return payload.sub;
    }
    return "";
  },
  accessToken(state): string {
    return state.accessToken || "";
  },
};
