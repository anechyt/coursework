import { Skill } from "./skill";

export class CandidateView {
  public firstName: string | null = null;
  public lastName: string | null = null;
  public phoneNumber: string | null = null;
  public score: number | null = null;
  public biography: string | null = null;
  public resume: string | null = null;
  public location: string | null = null;
  public skills: Array<Skill> | null = null;
  userGID: string | null = null;

  constructor(firstName: string,
              lastName: string,
              phoneNumber: string,
              score: number,
              biography: string,
              location: string,
              skills: Array<Skill>,
              resume: string,
              userGID: string) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.phoneNumber = phoneNumber;
    this.score = score;
    this.biography = biography;
    this.location = location;
    this.skills = skills;
    this.resume = resume;
    this.userGID = userGID;
  }
}
