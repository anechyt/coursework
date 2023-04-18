import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-recruiter-home',
  templateUrl: './recruiter-home.component.html',
  styleUrls: ['./recruiter-home.component.scss']
})
export class RecruiterHomeComponent implements OnInit {
  public firstName: string | null = null;
  public lastName: string | null = null;

  constructor() { }

  ngOnInit(): void {
    this.firstName = localStorage.getItem("FIRSTNAME");
    this.lastName = localStorage.getItem("LASTNAME");
  }
}
