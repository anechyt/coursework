export class RegisterRequest {
  email: string | null = null;
  password: string | null = null;
  role: string | null = null;

  constructor(email: string, password: string, role: string) {
    this.email = email;
    this.password = password;
    this.role = role;
  }
}
