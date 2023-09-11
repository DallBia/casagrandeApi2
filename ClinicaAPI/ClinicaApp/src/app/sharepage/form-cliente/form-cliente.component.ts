import { Grid01Component } from 'src/app/sharepage/grid01/grid01.component';
import { Component, ViewChild, ElementRef, Input , SimpleChanges, OnChanges, OnDestroy, OnInit, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ClienteService } from 'src/app/services/cliente/cliente.service';
import { SharedService } from 'src/app/shared/shared.service';
import { TableData } from 'src/app/models/Tables/TableData';
import { of } from 'rxjs';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { Cliente } from 'src/app/models/Clientes';


@Component({
  selector: 'app-form-cliente',
  templateUrl: './form-cliente.component.html',
  styleUrls: ['./form-cliente.component.css'],

})
export class FormClienteComponent implements OnInit, OnChanges {


  selectedValue = 'Cliente';
  formulario: FormGroup | undefined;
  Atual!: TableData;
  selectedFile: File | null = null;
  nCliente:number = 0;
  ValidSai: boolean = false;
  RestrMae: boolean = false;
  RestrPai: boolean = false;
  @ViewChild('fileInput') fileInput!: ElementRef;
  @Output() onSubmit = new EventEmitter<Cliente>();


  constructor(private http: HttpClient, private clienteService: ClienteService){}

  clienteform!: FormGroup;

  submit(){
    this.onSubmit.emit(this.clienteform.value);
  }

  ngOnInit(){

    this.clienteService.ClienteAtual$.subscribe(clienteAtual => {
      this.Atual = clienteAtual;
    });
    this.clienteService.ClienteA$.subscribe(clienteA => {
      this.nCliente = clienteA;
    });

    this.CarregaForm();



  }

  CarregaForm(){

    if(this.Atual.SaiSoz == 'Sim'){
      this.ValidSai = true
    }
    if(this.Atual.RestrMae == 'Sim'){
      this.RestrMae = true
    }
    if(this.Atual.RestrPai == 'Sim'){
      this.RestrPai = true
    }

    let AtualID = this.Atual.Id;
    if(AtualID == -1){
      AtualID = 0
    }

    this.clienteform = new FormGroup({
    nome: new FormControl(this.Atual.Nome),
    dtNascim: new FormControl(this.Atual.Nascimento),
    identidade: new FormControl(this.Atual.Identidade),
    email: new FormControl(this.Atual.Email),
    telFixo: new FormControl(this.Atual.TelefoneFixo),
    celular: new FormControl(this.Atual.Celular),
    endereco: new FormControl(this.Atual.Endereco),
    saSozinho: new FormControl(this.ValidSai),
    respFinanc: new FormControl(this.Atual.RespFin),
    id: new FormControl(AtualID),
    mae: new FormControl(this.Atual.NomeMae),
    pai: new FormControl(this.Atual.NomePai),
    dtInclusao: new FormControl(this.Atual.DtIncl),
    maeRestric: new FormControl(this.RestrMae),
    paiRestric: new FormControl(this.RestrPai),
    telComercial: new FormControl(this.Atual.TelCom),
    clienteDesde: new FormControl(this.Atual.Desde),
    ativo: new FormControl(this.Atual.Ativo),
    areaSession: new FormControl(this.Atual.Area),
    });
    console.log('-Atul:'+this.Atual.Nascimento)
    console.log(this.clienteform)
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes[this.nCliente]) {
      console.log('Opa! alguma coisa mudou por aqui!')

      this.clienteService.ClienteAtual$.subscribe(clienteAtual => {
        this.Atual = clienteAtual;
      });
      this.clienteService.ClienteA$.subscribe(clienteA => {
        this.nCliente = clienteA;
      });

    }
  }



  ngOnDestroy(){

  }

// public stringFormatada =  this.nCliente.toString().padStart(4, '0');
public caminho: string = '"../../../assets/img/Clientes/';
// public NovaImagem: string = this.caminho + this.stringFormatada + '.jpg';
public semFoto: string='"../../../assets/imag/Clientes/0000.jpg';

//====================================================

selecionarImagem() {
  this.fileInput.nativeElement.click();
}

onFileSelected(event:any) {
  const file: File = event.target.files[0];
const stringFormatada =  this.nCliente.toString().padStart(4, '0') + '.jpg';
// this.caminho = '"../../../assets/img/Clientes/';
// this.NovaImagem = this.caminho + this.stringFormatada;
// this.semFoto ='"../../../assets/img/Clientes/0000.jpg';
//console.log(this.stringFormatada)
  if (file) {
      this.uploadFile(file, stringFormatada);
  }

}

uploadFile(file: File, nome: string) {


  const formData = new FormData();
  formData.append('file', file, file.name);
  formData.append('nome', nome);

  this.http.post('https://localhost:7298/api/Image/', formData)
      .subscribe(response => {
          console.log('Upload feito com sucesso', response);
          console.log('imagem do registro' + this.nCliente + ' alterada.')

          this.delayAndRefresh();
      }, error => {
          console.error('Erro no upload', error);
      });
    }

    delayAndRefresh() {
      setTimeout(() => {
        location.reload;
      }, 300);

    }

}

