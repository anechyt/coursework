import { Component, OnInit } from '@angular/core';
import { Observable } from "rxjs";
import { RecruiterService } from "../services/recruiter.service";
import { CandidatesResponse } from "../../candidates/models/candidates-response";
import {Skill} from "../../candidates/models/skill";

@Component({
  selector: 'app-recruiter-candidates',
  templateUrl: './recruiter-candidates.component.html',
  styleUrls: ['./recruiter-candidates.component.scss']
})
export class RecruiterCandidatesComponent implements OnInit {

  public skill: string | null = null;
  public bio: string | null = null;
  public resume: string | null = null;
  public skills: string[] = [];
  public bios: string[] = [];
  public resumes: string[] = [];
  public candidates$!: Observable<CandidatesResponse[]>

  constructor(private recruiterService: RecruiterService) { }

  ngOnInit(): void {
    this.candidates$ = this.recruiterService.getCandidates();
  }

  public refreshCandidates(): void {
    this.candidates$ = this.recruiterService.getCandidates();
  }

  public addSkill(): void {
    this.skills.push(this.skill ?? '');
  }

  public addBio(): void {
    this.bios.push(this.bio ?? '');
  }

  public addResume(): void {
    this.resumes.push(this.resume ?? '');
  }
}
