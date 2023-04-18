export class RegisterResponse {
  accessToken!: string;
  accessTokenExpirationTime!: string;
  userGID!: string;
  role!: string;

  constructor(accessToken: string, accessTokenExpirationTime: string, userGID: string, role: string) {
    this.accessToken = accessToken;
    this.accessTokenExpirationTime = accessTokenExpirationTime;
    this.userGID = userGID;
    this.role = role;
  }
}
