import { Component, OnInit } from '@angular/core';
import { CandidateService } from "../services/candidate.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-candidate-home',
  templateUrl: './candidate-home.component.html',
  styleUrls: ['./candidate-home.component.scss']
})
export class CandidateHomeComponent implements OnInit {

  constructor(private candidateService: CandidateService,
              private router: Router) { }

  ngOnInit(): void {
  }
}
