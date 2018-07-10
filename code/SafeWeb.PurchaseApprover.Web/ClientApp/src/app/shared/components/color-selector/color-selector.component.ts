import { Component, Input, Output, EventEmitter } from '@angular/core';


@Component({
    selector: 'app-color-selector',
    templateUrl: './color-selector.component.html',
    styleUrls: ['./color-selector.component.scss']
})
export class ColorSeletorComponent {

    @Input() selectedColor: string;
    @Output() selectedColorChange: EventEmitter<string> = new EventEmitter<string>();

    availableColors: string[] = [
        '#333333',
        '#cc0000',
        '#dd4e00',
        '#ffd600',
        '#008c20',
        '#1565c0',
        '#5f18ea'
    ];

    onClick(color: string): void {
        this.selectedColor = color;
        this.selectedColorChange.emit(this.selectedColor);
    }

    mountShadowStyle(color: string): string {
        return `0px 0px 0px 2px ${color}`;
    }
}
