import { Skill } from "../../candidates/models/skill";

export class Vacancy {
  public name: string | null = null;
  public description: string | null = null;
  public salary: number | null = null;
  public location: string | null = null;
  public skills: Array<Skill> | null = null;
  vacancyStatusGID: string | null = null;
  recruiterGID: string | null = null;

  constructor(name: string,
              description: string,
              salary: number,
              location: string,
              skills: Array<Skill>,
              vacancyStatusGID: string,
              recruiterGID: string) {
    this.name = name;
    this.description = description;
    this.salary = salary;
    this.location = location;
    this.skills = skills;
    this.vacancyStatusGID = vacancyStatusGID;
    this.recruiterGID = recruiterGID;
  }
}
