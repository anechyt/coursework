import { Component, OnInit } from '@angular/core';
import { Observable } from "rxjs";
import { RecruiterService } from "../services/recruiter.service";
import { CandidatesResponse } from "../../candidates/models/candidates-response";
import {CandidateView} from "../../candidates/models/candidate-view";

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
  public candidates$!: Observable<CandidateView[]>

  constructor(private recruiterService: RecruiterService) { }

  ngOnInit(): void {
    this.candidates$ = this.recruiterService.getCandidates();
  }

  public refreshCandidates(): void {
    this.candidates$ = this.recruiterService.getCandidates();
    this.skills = [];
    this.bios = [];
    this.resumes = [];

    this.skill = '';
    this.bio = '';
    this.resume = '';
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

  public searchBySkills(): void {
    this.candidates$ = this.recruiterService.getCandidatesBySkills(this.skills);
  }

  public searchByBio(): void {
    this.candidates$ = this.recruiterService.getCandidatesByBio(this.bios);
  }

  public searchByResume(): void {
    this.candidates$ = this.recruiterService.getCandidatesByResume(this.resumes);
  }
}
