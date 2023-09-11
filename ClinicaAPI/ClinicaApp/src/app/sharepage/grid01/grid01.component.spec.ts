import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Grid01Component } from './grid01.component';

describe('Grid01Component', () => {
  let component: Grid01Component;
  let fixture: ComponentFixture<Grid01Component>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [Grid01Component]
    });
    fixture = TestBed.createComponent(Grid01Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
