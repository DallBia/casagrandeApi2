import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MeuModalComponent } from './meu-modal.component';

describe('MeuModalComponent', () => {
  let component: MeuModalComponent;
  let fixture: ComponentFixture<MeuModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MeuModalComponent]
    });
    fixture = TestBed.createComponent(MeuModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
