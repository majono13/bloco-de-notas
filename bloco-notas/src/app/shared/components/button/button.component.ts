import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.scss'],
})
export class ButtonComponent implements OnInit {
  @Input('disabled') disabled: boolean = false;
  @Input('message') message: string = '';
  @Input('color') color: string = 'accent';

  constructor() {}

  ngOnInit(): void {}
}
