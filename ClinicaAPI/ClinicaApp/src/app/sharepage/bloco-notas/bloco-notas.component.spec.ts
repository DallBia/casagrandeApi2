import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BlocoNotasComponent } from './bloco-notas.component';

describe('BlocoNotasComponent', () => {
  let component: BlocoNotasComponent;
  let fixture: ComponentFixture<BlocoNotasComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BlocoNotasComponent]
    });
    fixture = TestBed.createComponent(BlocoNotasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
