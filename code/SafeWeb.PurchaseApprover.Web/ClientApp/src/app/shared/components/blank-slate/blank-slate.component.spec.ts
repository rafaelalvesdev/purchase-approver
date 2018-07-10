import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BlankSlateComponent } from './blank-slate.component';

describe('BlankSlateComponent', () => {
    let component: BlankSlateComponent;
    let fixture: ComponentFixture<BlankSlateComponent>;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [BlankSlateComponent]
        })
            .compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(BlankSlateComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
