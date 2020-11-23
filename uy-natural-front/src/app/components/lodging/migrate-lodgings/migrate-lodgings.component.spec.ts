import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MigrateLodgingsComponent } from './migrate-lodgings.component';

describe('MigrateLodgingsComponent', () => {
  let component: MigrateLodgingsComponent;
  let fixture: ComponentFixture<MigrateLodgingsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MigrateLodgingsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MigrateLodgingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
