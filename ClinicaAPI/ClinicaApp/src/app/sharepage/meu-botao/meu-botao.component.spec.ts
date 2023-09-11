import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MeuBotaoComponent } from './meu-botao.component';

describe('MeuBotaoComponent', () => {
  let component: MeuBotaoComponent;
  let fixture: ComponentFixture<MeuBotaoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MeuBotaoComponent]
    });
    fixture = TestBed.createComponent(MeuBotaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
