import { Component, OnInit } from '@angular/core';
import { RecruiterService } from "../services/recruiter.service";
import { Router } from "@angular/router";

@Component({
  selector: 'app-recruiter-home',
  templateUrl: './recruiter-home.component.html',
  styleUrls: ['./recruiter-home.component.scss']
})
export class RecruiterHomeComponent implements OnInit {
  public firstName: string | null = null;
  public lastName: string | null = null;

  constructor(private recruiterService: RecruiterService,
              private router: Router) { }

  ngOnInit(): void {

  }
}
