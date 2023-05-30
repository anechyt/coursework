import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";

@Component({
  selector: 'app-recruiter-header',
  templateUrl: './recruiter-header.component.html',
  styleUrls: ['./recruiter-header.component.scss']
})
export class RecruiterHeaderComponent implements OnInit {
  public firstName: string | null = null;
  public lastName: string | null = null;

  constructor(private router: Router) { }

  ngOnInit(): void {
    this.firstName = localStorage.getItem("FIRSTNAME");
    this.lastName = localStorage.getItem("LASTNAME");
  }

  public onItemClick(item: string) {
    this.router.navigate([item]);
  }
}
