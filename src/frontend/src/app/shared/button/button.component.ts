import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.scss']
})
export class ButtonComponent {
  @Input() buttonClass: string = '';
  @Output() onClick = new EventEmitter();

  handleClick() {
    this.onClick.emit();
  }
}
