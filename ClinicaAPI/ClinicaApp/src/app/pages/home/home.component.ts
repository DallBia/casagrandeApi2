import { Component, ViewChild, ElementRef, OnInit  } from '@angular/core';
import { HeaderService } from '../../sharepage/navbar/header.service';
import { ClienteService } from 'src/app/services/cliente/cliente.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  textoAvisos: string = '';

  @ViewChild('avisosTextarea') avisosTextarea!: ElementRef;
  public textoPreDefinido: string = '';
  getCursorPosition(): number {
    return this.avisosTextarea.nativeElement.selectionStart;
  }

  ngOnInit(): void {

    this.clienteService.setClienteA(0);
  }
  addBullet() {
    const cursorPosition = this.getCursorPosition();
    const beforeCursor = this.textoAvisos.substring(0, cursorPosition).trim();
    const afterCursor = this.textoAvisos.substring(cursorPosition).trim();

    const linesBeforeCursor = beforeCursor.split('\n');

    if (linesBeforeCursor.length === 1 && !beforeCursor.startsWith('· ')) {
      // Caso especial: apenas a primeira linha está sendo alterada e ainda não tem um bullet
      this.textoAvisos = '· ' + beforeCursor + '\n' + afterCursor;
    } else {
      // Mantém o texto como está
      this.textoAvisos = beforeCursor + '\n' + afterCursor;
    }

      if (!linesBeforeCursor[linesBeforeCursor.length - 1].startsWith('· ')) {
        // Adiciona o bullet na última linha antes do cursor se ainda não tiver
        linesBeforeCursor[linesBeforeCursor.length - 1] = '· ' + linesBeforeCursor[linesBeforeCursor.length - 1];
      }

      this.textoAvisos = [...linesBeforeCursor, afterCursor].join('\n');

    // Posicione o cursor corretamente após a inserção
    setTimeout(() => {
      this.avisosTextarea.nativeElement.selectionStart = cursorPosition + 2;
      this.avisosTextarea.nativeElement.selectionEnd = cursorPosition + 2;
    });
  }
  buttons = [
    { text: 'FICHAS DE CLIENTES', param: 'parametro1', route: '/fichacliente'},
    { text: 'CADASTRO DA EQUIPE', param: 'parametro2', route: '/cadprof'},
    { text: 'AGENDA', param: 'parametro3', route: '/agenda' },
    { text: 'PRONTUÁRIO CLÍNICO', param: 'parametro4', route: '/protclin'},
    { text: 'PRONTUÁRIO ADMINISTRATIVO', param: 'parametro5', route: '/protadm'},
    { text: 'CONTROLE FINANCEIRO', param: 'parametro6', route: '/controleFinaceiro'}
  ];

  constructor(private headerService: HeaderService, private clienteService: ClienteService) {}

  atualizarHeader(texto: string): void {
    this.headerService.linkAtivo = texto;
  }
}
