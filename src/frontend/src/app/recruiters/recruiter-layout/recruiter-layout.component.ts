import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";

@Component({
  selector: 'app-recruiter-layout',
  templateUrl: './recruiter-layout.component.html',
  styleUrls: ['./recruiter-layout.component.scss']
})
export class RecruiterLayoutComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
    this.router.navigate(["create"]);
  }
}
