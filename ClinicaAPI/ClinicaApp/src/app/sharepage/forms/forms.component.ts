import { Component, ViewChild, ElementRef, Input , OnChanges, OnDestroy, OnInit, Output, EventEmitter } from '@angular/core';
import { SharedService } from '../../shared/shared.service';  // Atualize o caminho
import { Subscription } from 'rxjs';
import { Subject } from 'rxjs';
import { ClienteService } from 'src/app/services/cliente/cliente.service';
import { TableData } from 'src/app/models/Tables/TableData';
import { HttpClientModule, HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-forms',
  templateUrl: './forms.component.html',
  styleUrls: ['./forms.component.css']
})

export class FormsComponent implements OnDestroy, OnInit {
// ================= -- VARIÁVEIS -- =============================
  Atual!: TableData;
  selectedFile: File | null = null;
  nCliente:number = 0;
  @ViewChild('fileInput') fileInput!: ElementRef;

  // ========================================================
  constructor(private http: HttpClient, private clienteService: ClienteService){

  }

  ngOnInit(): void {
    this.clienteService.ClienteAtual$.subscribe(clienteAtual => {
      this.Atual = clienteAtual;
    });
    this.clienteService.ClienteA$.subscribe(clienteA => {
      this.nCliente = clienteA;
    });

  }
  ngOnDestroy(): void {

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
          this.delayAndRefresh();
      }, error => {
          console.error('Erro no upload', error);
      });

    }

    delayAndRefresh() {
      setTimeout(() => {
        // this.Grid01Service.destacarLinha(this.nL,this.nFicha)
      }, 300);

    }

}
