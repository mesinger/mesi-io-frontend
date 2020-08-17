import { decodePayload } from '@/util/jwt-decode';
import { AuthenticationService } from './AuthenticationService';

export enum AccessTokenState {
  None,
  Expired,
  Valid
}

export class AccessTokenHandler {
  private readonly accessTokenKey = "identity";
  private readonly authenticationService = new AuthenticationService();

  public persistAccessToken(accessToken: string) {
    localStorage.setItem(this.accessTokenKey, accessToken);
  }

  public getFromLocalStorage(): string | null {
    return localStorage.getItem(this.accessTokenKey);
  }

  public getPayload(token: string): any | null {
    if(token) {
      return decodePayload(token);
    }
    return null;
  }

  public getState(token: string): AccessTokenState {
    const payload = this.getPayload(token);

    if(payload) {
      if(payload.exp) {
        if(payload.exp > Date.now() / 1000) {
          return AccessTokenState.Valid;
        } else {
          return AccessTokenState.Expired;
        }
      }
    }

    return AccessTokenState.None;
  }

  public deleteAccessToken() {
    localStorage.removeItem(this.accessTokenKey);
  }

  public async refreshToken(): Promise<void> {
    await this.authenticationService.renewToken();
    const user = await this.authenticationService.getUser();
    if(user) {
      this.persistAccessToken(user.access_token);
    }
  }
}
