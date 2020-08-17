import { User, UserManager } from "oidc-client";

export { User };

export class AuthenticationService {
  private readonly userManager: UserManager;

  constructor() {
    const settings = {
      authority: process.env.VUE_APP_AUTH_AUTHORITY,
      client_id: process.env.VUE_APP_AUTH_CLIENT_ID,
      redirect_uri: `${process.env.VUE_APP_AUTH_BASE_URL}/auth/login-callback`,
      silent_redirect_uri: `${process.env.VUE_APP_AUTH_BASE_URL}/auth/login-callback-silent`,
      post_logout_redirect_uri: process.env.VUE_APP_AUTH_BASE_URL,
      response_type: "code",
      scope: "openid clipboard.user.read clipboard.user.write",
    };
    this.userManager = new UserManager(settings);
  }

  public getUser(): Promise<User | null> {
    return this.userManager.getUser();
  }

  public login(): Promise<void> {
    return this.userManager.signinRedirect();
  }

  public renewToken(): Promise<User> {
    return this.userManager.signinSilent();
  }

  public logout(): Promise<void> {
    return this.userManager.signoutRedirect();
  }
}
