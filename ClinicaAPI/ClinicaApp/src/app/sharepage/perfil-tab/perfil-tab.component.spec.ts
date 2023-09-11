import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PerfilTabComponent } from './perfil-tab.component';

describe('PerfilTabComponent', () => {
  let component: PerfilTabComponent;
  let fixture: ComponentFixture<PerfilTabComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PerfilTabComponent]
    });
    fixture = TestBed.createComponent(PerfilTabComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
