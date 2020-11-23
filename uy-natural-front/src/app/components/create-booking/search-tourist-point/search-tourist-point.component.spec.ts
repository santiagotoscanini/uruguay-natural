import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchTouristPointComponent } from './search-tourist-point.component';

describe('SearchTouristPointComponent', () => {
  let component: SearchTouristPointComponent;
  let fixture: ComponentFixture<SearchTouristPointComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchTouristPointComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchTouristPointComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
