import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProtadmComponent } from './protadm.component';

describe('ProtadmComponent', () => {
  let component: ProtadmComponent;
  let fixture: ComponentFixture<ProtadmComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ProtadmComponent]
    });
    fixture = TestBed.createComponent(ProtadmComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
