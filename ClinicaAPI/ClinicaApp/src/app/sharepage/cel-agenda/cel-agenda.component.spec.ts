import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CelAgendaComponent } from './cel-agenda.component';

describe('CelAgendaComponent', () => {
  let component: CelAgendaComponent;
  let fixture: ComponentFixture<CelAgendaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CelAgendaComponent]
    });
    fixture = TestBed.createComponent(CelAgendaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
