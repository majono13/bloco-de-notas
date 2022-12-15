import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-spinner',
  templateUrl: './spinner.component.html',
  styleUrls: ['./spinner.component.scss'],
})
export class SpinnerComponent implements OnInit {
  @Input('widthSpinner') widthSpinner: string = '70px';
  @Input('message') message: string = '';
  @Input('loadingScreen') loadingScreen: boolean = false;

  constructor() {}

  ngOnInit(): void {}
}
