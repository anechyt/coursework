export class VacancyStatus {
  public gid: string | null = null;
  public name: string | null = null;

  constructor(gid: string,
              name: string) {
    this.gid = gid;
    this.name = name;
  }
}
