import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubmitBookingInfoComponent } from './submit-booking-info.component';

describe('SubmitBookingInfoComponent', () => {
  let component: SubmitBookingInfoComponent;
  let fixture: ComponentFixture<SubmitBookingInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SubmitBookingInfoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SubmitBookingInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
