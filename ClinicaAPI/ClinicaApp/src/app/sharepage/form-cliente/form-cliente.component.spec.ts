import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormClienteComponent } from './form-cliente.component';

describe('FormClienteComponent', () => {
  let component: FormClienteComponent;
  let fixture: ComponentFixture<FormClienteComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FormClienteComponent]
    });
    fixture = TestBed.createComponent(FormClienteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
