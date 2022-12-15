import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-button-add',
  templateUrl: './button-add.component.html',
  styleUrls: ['./button-add.component.scss'],
})
export class ButtonAddComponent implements OnInit {
  hover: boolean = false;

  constructor() {}

  ngOnInit(): void {}

  mouseEnter() {
    setTimeout(() => (this.hover = true), 300);
  }

  mouseLeave() {
    this.hover = false;
  }
}
