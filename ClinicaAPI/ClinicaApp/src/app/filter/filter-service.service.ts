import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FilterService {
  private filterSubject = new BehaviorSubject<string>('');

  getFilterObservable() {
    return this.filterSubject.asObservable();
  }

  updateFilter(value: string) {
    this.filterSubject.next(value);
  }
}
