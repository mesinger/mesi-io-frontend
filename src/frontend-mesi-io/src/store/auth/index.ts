import { AuthenticationState } from "./types";
import { Module } from "vuex";
import { RootState } from "../types";
import { actions } from "./actions";
import { mutations } from "./mutations";
import { getters } from "./getters";
import { AccessTokenHandler } from '@/service/AccessTokenHandler';

const accessTokenHandler = new AccessTokenHandler();

export const state: AuthenticationState = {
  accessToken: accessTokenHandler.getFromLocalStorage() || ""
};

export const auth: Module<AuthenticationState, RootState> = {
  namespaced: true,
  state,
  getters,
  actions,
  mutations
};
