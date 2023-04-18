export class LoginResponse {
  accessToken!: string;
  accessTokenExpirationTime!: Date;
  refreshToken!: string;
  role!: string;
  userGID!: string;

  constructor(accessToken: string, accessTokenExpirationTime: Date, refreshToken: string, role: string, userGID: string) {
    this.accessToken = accessToken;
    this.accessTokenExpirationTime = accessTokenExpirationTime;
    this.refreshToken = refreshToken;
    this.role = role;
    this.userGID = userGID;
  }
}
