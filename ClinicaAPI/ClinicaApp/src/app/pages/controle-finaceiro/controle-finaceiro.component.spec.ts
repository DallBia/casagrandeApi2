import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ControleFinaceiroComponent } from './controle-finaceiro.component';

describe('ControleFinaceiroComponent', () => {
  let component: ControleFinaceiroComponent;
  let fixture: ComponentFixture<ControleFinaceiroComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ControleFinaceiroComponent]
    });
    fixture = TestBed.createComponent(ControleFinaceiroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
