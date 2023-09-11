import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NavbarService {

  // BehaviorSubject para controlar a visibilidade da barra de navegação
  private showNavbarSubject = new BehaviorSubject<boolean>(true);
  showNavbar$ = this.showNavbarSubject.asObservable();

  constructor() { }

  toggleNavbar(show: boolean): void {
    this.showNavbarSubject.next(show);
  }
}
