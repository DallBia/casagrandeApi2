import { MeuBotaoComponent } from 'src/app/sharepage/meu-botao/meu-botao.component';
import {FormClienteComponent} from '../../sharepage/form-cliente/form-cliente.component';
import { TableData } from 'src/app/models/Tables/TableData';
import { Cliente } from './../../models/Clientes';
import { ClienteService } from './../../services/cliente/cliente.service';
import { Component, ViewChild, OnInit, OnDestroy } from '@angular/core';
import { SharedService } from '../../shared/shared.service';  // Atualize o caminho
import { Subscription } from 'rxjs';


@Component({
  selector: 'app-protclin',
  templateUrl: './protclin.component.html',
  styleUrls: ['./protclin.component.css']
})
export class ProtclinComponent {
  texto: string = '';
  private subscription!: Subscription;
  nCliente: number = 0;
  Atual!: TableData;
  public Ficha:string = 'FICHA';
  public NomeCliente: string = '';
  public MostraInfo: boolean = true;
  public idFoto: string = '';

  constructor(private clienteService: ClienteService) { }

  ngOnInit() {
    this.subscription = this.clienteService.ClienteA$.subscribe(
      name => this.nCliente = name
    )
    this.clienteService.ClienteAtual$.subscribe(clienteAtual => {
      this.Atual = clienteAtual;
    });

    if(this.nCliente !== 0){
      this.Ficha = this.Atual.Ficha;
      this.NomeCliente = this.Atual.Nome.toUpperCase();
      this.idFoto = '../../../assets/img/Clientes/' + this.Ficha + '.jpg'

      }else{
      this.Ficha = 'FICHA';
      this.NomeCliente = '';
       console.log(this.idFoto)
    }

    this.newInfo(this.MostraInfo);
  }

  newInfo(opt: boolean){
    this.MostraInfo = !opt;
  }

  adicionarEspaco() {
    this.texto += '\n\n';
  }


  ficha = [
    { texto: this.Ficha, altura: '10vh', largura: '18vh', cor: 'var(--cor-clara)', size: '20pt' }
  ];
  containers = [
    {altura:'10vh', largura: "200vh"}
  ];
  botoes = [
    { texto: '', altura: '4.6vh', largura: '15vh', cor: 'white' },
    { texto: '', altura: '4.6vh', largura: '15vh', cor: 'white' },
    { texto: '', altura: '4.6vh', largura: '15vh', cor: 'white'},
    { texto: '', altura: '4.6vh', largura: '15vh', cor:'white' }
  ];
  botoesInfo = [
    { texto: 'Anexar Documento', altura: '4vh', largura: '30vh', cor: 'white' },
    { texto: 'Ver Documento', altura: '4vh', largura: '30vh', cor: 'white' },
    { texto: 'Imprimir Relatório', altura: '4vh', largura: '30vh', cor: 'white' },
    { texto: 'Buscar neste Prontuário', altura: '4vh', largura: '30vh', cor: 'white' },
    { texto: 'Inserir nova informação', altura: '4vh', largura: '30vh', cor: 'white' },
 ]


}
