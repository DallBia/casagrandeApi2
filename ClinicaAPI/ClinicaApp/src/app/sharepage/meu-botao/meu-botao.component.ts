// meu-botao.component.ts
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-meu-botao',
  templateUrl: './meu-botao.component.html',
  styleUrls: ['./meu-botao.component.css']
})
export class MeuBotaoComponent {
  @Input() texto: string = 'Clique-me';
  @Input() altura: string = '50px';
  @Input() largura: string = '100px';
  @Input() cor: string = 'white';
  @Input() size: string = '10pt';
  @Input() fontCor: string = 'black';

  // mostrarPopup() {
  //   alert(this.texto);
  // }
}
