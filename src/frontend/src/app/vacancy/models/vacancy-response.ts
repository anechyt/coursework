import { Skill } from "../../candidates/models/skill";

export class VacancyResponse {
  public gid: string | null = null;
  public name: string | null = null;
  public description: string | null = null;
  public salary: string | null = null;
  public location: string | null = null;
  public skills: Array<Skill> | null = null;
  public vacancyStatusName: string | null = null;
  public recruiterFirstName: string | null = null;
  public recruiterLastName: string | null = null;
  public recruiterPhoneNumber: string | null = null;

  constructor(gid: string,
              name: string,
              description: string,
              salary: string,
              location: string,
              skills: Array<Skill>,
              vacancyStatusName: string,
              recruiterFirstName: string,
              recruiterLastName: string,
              recruiterPhoneNumber: string) {
    this.gid = gid;
    this.name = name;
    this.description = description;
    this.salary = salary;
    this.location = location;
    this.skills = skills;
    this.vacancyStatusName = vacancyStatusName;
    this.recruiterFirstName = recruiterFirstName;
    this.recruiterLastName = recruiterLastName;
    this.recruiterPhoneNumber = recruiterPhoneNumber;
  }
}
