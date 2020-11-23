import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookingConfirmationInfoComponent } from './booking-confirmation-info.component';

describe('BookingConfirmationInfoComponent', () => {
  let component: BookingConfirmationInfoComponent;
  let fixture: ComponentFixture<BookingConfirmationInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BookingConfirmationInfoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BookingConfirmationInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
