export class Recruiter {
  firstName: string | null = null;
  lastName: string | null = null;
  companyName: string | null = null;
  phoneNumber: string | null = null;
  biography: string | null = null;

  location: string | null = null;
  userGID: string | null = null;

  constructor(firstName: string,
              lastName: string,
              companyName: string,
              phoneNumber: string,
              biography: string,
              location: string,
              userGID: string) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.companyName = companyName;
    this.phoneNumber = phoneNumber;
    this.biography = biography;
    this.location = location;
    this.userGID = userGID;
  }
}
