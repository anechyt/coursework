import { Skill } from "../../candidates/models/skill";

export class Vacancy {
  public name: string | null = null;
  public description: string | null = null;
  public salary: string | null = null;
  public location: string | null = null;
  public skills: Array<Skill> | null = null;
  vacancyStatusGID: string | null = null;
  recruiterGID: string | null = null;
}
