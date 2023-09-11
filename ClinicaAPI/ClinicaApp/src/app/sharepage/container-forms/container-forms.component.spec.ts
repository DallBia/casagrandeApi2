import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContainerFormsComponent } from './container-forms.component';

describe('ContainerFormsComponent', () => {
  let component: ContainerFormsComponent;
  let fixture: ComponentFixture<ContainerFormsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ContainerFormsComponent]
    });
    fixture = TestBed.createComponent(ContainerFormsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
