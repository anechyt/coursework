import { Component, OnInit } from '@angular/core';
import { Observable } from "rxjs";
import { Candidate } from "../../candidates/models/candidate";
import { RecruiterService } from "../services/recruiter.service";

@Component({
  selector: 'app-recruiter-candidates',
  templateUrl: './recruiter-candidates.component.html',
  styleUrls: ['./recruiter-candidates.component.scss']
})
export class RecruiterCandidatesComponent implements OnInit {
  public candidates$!: Observable<Candidate[]>

  constructor(private recruiterService: RecruiterService) { }

  ngOnInit(): void {
    this.candidates$ = this.recruiterService.getCandidates();
  }

}
