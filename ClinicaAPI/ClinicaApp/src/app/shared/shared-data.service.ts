// shared-data.service.ts

import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedDataService {
  private minhaVariavelFonte = new BehaviorSubject<string>('Valor Padrão');
  minhaVariavelAtual = this.minhaVariavelFonte.asObservable();

  atualizarVariavel(novoValor: string) {
    this.minhaVariavelFonte.next(novoValor);
  }
}
