import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-custom-date',
  templateUrl: './custom-date.component.html',
  styleUrls: ['./custom-date.component.css']
})
export class CustomDateComponent implements OnInit {
  displayedDate: Date = new Date();
  semana = ['DOM','SEG','TER','QUA','QUI','SEX','SÁB'];
  constructor() {}

  ngOnInit(): void {}

  onDateChange(event: any): void {
    if (event) {
      this.displayedDate = event.value;
    }
  }
}