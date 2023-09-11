import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FichaclienteComponent } from './fichacliente.component';

describe('FichaclienteComponent', () => {
  let component: FichaclienteComponent;
  let fixture: ComponentFixture<FichaclienteComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FichaclienteComponent]
    });
    fixture = TestBed.createComponent(FichaclienteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
