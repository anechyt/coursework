import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';

@Component({
  selector: 'app-input',
  templateUrl: './input.component.html',
  styleUrls: ['./input.component.scss']
})
export class InputComponent implements OnInit {
  @Input() isRequired: boolean = false;
  @Input() label: string | null = null;
  @Input() value: string | null = null;
  @Input() placeholder: string | null = null;
  @Output() valueChange = new EventEmitter<string>();
  @Input() inputClass: string = '';

  ngOnInit() {
    if (!this.value) {
      this.value = '';
    }
  }

  onChange(event: any) {
    this.valueChange.emit(event.target.value);
  }

  get isValid() {
    return !this.isRequired || (this.value && this.value.trim().length > 0);
  }
}
