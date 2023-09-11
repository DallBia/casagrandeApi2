import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProtclinComponent } from './protclin.component';

describe('ProtclinComponent', () => {
  let component: ProtclinComponent;
  let fixture: ComponentFixture<ProtclinComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ProtclinComponent]
    });
    fixture = TestBed.createComponent(ProtclinComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
