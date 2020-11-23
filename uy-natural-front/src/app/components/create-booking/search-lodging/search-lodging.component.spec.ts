import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchLodgingComponent } from './search-lodging.component';

describe('SearchLodgingComponent', () => {
  let component: SearchLodgingComponent;
  let fixture: ComponentFixture<SearchLodgingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchLodgingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchLodgingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
