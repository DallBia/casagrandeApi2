import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormsEquiComponent } from './forms-equi.component';

describe('FormsEquiComponent', () => {
  let component: FormsEquiComponent;
  let fixture: ComponentFixture<FormsEquiComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FormsEquiComponent]
    });
    fixture = TestBed.createComponent(FormsEquiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
