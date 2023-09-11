import { Component, OnInit, OnDestroy } from '@angular/core';
import { SharedService } from '../../shared/shared.service';  // Atualize o caminho
import { Subscription } from 'rxjs';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-cadprof',
  templateUrl: './cadprof.component.html',
  styleUrls: ['./cadprof.component.css'],
  template: `
  <label>{{ selectedName }}</label>
`
})
export class CadprofComponent implements OnDestroy {
  selectedName: string = '';
  selectedNascimento: string = '';
  selectedFicha: string = 'NOVO';
  imagefilter = 'assets/img/filter_alt_black_24dp.svg';

  private subscription: Subscription;
  Selecionada: string = 'Seu texto aqui';
  public idade1: any;
  public idade: any;

  novo = [
    { texto: this.selectedFicha, altura: '9vh', largura: '18vh', cor: 'var(--cor-clara)', size: '16pt' }
  ];
  bAnexar = [
    { texto: 'Anexar Arquivos', altura: '100%', largura: '100%', cor: 'white', size: '16pt' }
 ]
  containers = [
    {altura:'10vh', largura: "200vh"}
  ]
  meutxt = {
    label: 'Parâmetro',
    nome: 'filtro-param',
    largura: '65%',  // em pixels
    altura: '3.5vh'     // em pixels
  };

  filtro = [
    {altura:'4vh', largura: "30vh"}
  ]

  infoContainer = [
    {altura:'55vh', largura: "80vh"}
  ]
  salvarEnd = [
    {texto: 'Salvar', altura: "7vh", largura:'18vh', cor: 'var(--cor-clara)', size: '18pt', fontCor: 'black'},
    {texto: 'Cancelar', altura: "7vh", largura:'18vh', cor: 'var(--cor-media)', size: '18pt', fontCor: 'white'}
  ]
  imagefiltro = 'Clinica/Clinica/src/assets/img/filter_alt_black_24dp.svg';
  selectedImage: string = '';

  constructor(private sharedService: SharedService){
    this.subscription = this.sharedService.selectedName$.subscribe(
      name => this.selectedName = name
    );

    this.sharedService.currentSelectedRow.subscribe(row => {
      this.Selecionada = row;
  });
    this.subscription = this.sharedService.selectedFicha$.subscribe(
      name => this.selectedFicha = name
    );

    this.subscription = this.sharedService.selectedNascimento$.subscribe(
      name => {this.selectedNascimento = name
      this.idade1 = this.converterParaDate(this.selectedNascimento);
    this.idade = this.calcularIdade(this.idade1);}
    );
    this.sharedService.selectedImage$.subscribe(img => this.selectedImage = img!);

  }
  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  converterParaDate(dataString: string): Date {
    const [dia, mes, ano] = dataString.split('/').map(Number);
    return new Date(ano, mes - 1, dia);
}
  calcularIdade(dataNascimento: Date): string {
    const hoje = new Date();
    let idade = hoje.getFullYear() - dataNascimento.getFullYear();

    // Ajuste para caso o aniversário ainda não tenha ocorrido este ano
    const m = hoje.getMonth() - dataNascimento.getMonth();
    if (m < 0 || (m === 0 && hoje.getDate() < dataNascimento.getDate())) {
        idade--;
    }

    return idade.toString();
  }

  isNotNaN(valor: any): boolean {
    return !isNaN(valor);
}

  // onButtonClick(){

  // }
}
