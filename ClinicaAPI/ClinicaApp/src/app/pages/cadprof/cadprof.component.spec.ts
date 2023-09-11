import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadprofComponent } from './cadprof.component';

describe('CadprofComponent', () => {
  let component: CadprofComponent;
  let fixture: ComponentFixture<CadprofComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CadprofComponent]
    });
    fixture = TestBed.createComponent(CadprofComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
