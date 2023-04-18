export class LoginRequest {
  email: string | null = null;
  password: string | null = null;

  constructor(email: string, password: string) {
    this.email = email;
    this.password = password;
  }
}
