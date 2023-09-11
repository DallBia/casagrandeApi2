import { TableData } from '../../models/Tables/TableData';
import { FormClienteComponent } from './../../sharepage/form-cliente/form-cliente.component';
import { Cliente } from './../../models/Clientes';
import { ClienteService } from './../../services/cliente/cliente.service';
import { Component, ViewChild, OnInit, OnDestroy } from '@angular/core';
import { SharedService } from '../../shared/shared.service';  // Atualize o caminho
import { Subscription } from 'rxjs';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MeuModalComponent } from './meu-modal/meu-modal.component';
import { first } from 'rxjs/operators';
import { Grid01Component } from 'src/app/sharepage/grid01/grid01.component';
import { TabResult } from 'src/app/models/Tables/TabResult';

/*import { UserService, AlertService } from '@app/services';
import { MustMatch } from '@app/_helpers';*/

@Component({
  selector: 'app-fichacliente',
  templateUrl: './fichacliente.component.html',
  styleUrls: ['./fichacliente.component.css'],
})



export class FichaclienteComponent implements OnDestroy, OnInit {
  // [x: string]: any;

  @ViewChild(FormClienteComponent) formCliente!: FormClienteComponent;
  selectedName: string = '';
  selectedNascimento: string = '';
  nCliente: number = 0;
  Atual!: TableData;
  imagefilter = 'assets/img/filter_alt_black_24dp.svg';
  imagefiltro = 'Clinica/Clinica/src/assets/img/filter_alt_black_24dp.svg';
  selectedImage: string = '';
  private subscription: Subscription;
  Selecionada: string = 'Seu texto aqui';
  public idade1: any;
  public idade: any;
  nChanges: boolean = false;
  minhaCondicao: boolean = false;

  // =================== VARIÁVEIS PARA CRIAR COMPONENTES ===============================================

                novo = [
                  { texto: "novo", altura: '9vh', largura: '18vh', cor: 'var(--cor-clara)', size: '16pt' }
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
  // ============== FIM DAS VARIÁVEIS PARA CRIAR COMPONENTES =========================================


  constructor(private sharedService: SharedService, public dialog: MatDialog, private clienteService: ClienteService){

    this.subscription = this.sharedService.selectedName$.subscribe(
      name => this.selectedName = name
    );

      this.subscription = this.clienteService.ClienteA$.subscribe(
        name => this.nCliente = name
      )


    this.sharedService.currentSelectedRow.subscribe(row => {
      if(this.selectedName !==''){
        this.Selecionada = row;
      }else{
        this.Selecionada = '';
      }

    });



    // this.subscription = this.sharedService.selectedNascimento$.subscribe(
    //   name => {this.selectedNascimento = name
    //   this.idade1 = this.converterParaDate(this.selectedNascimento);
    //   this.idade = this.calcularIdade(this.idade1);}
    // );
    // this.sharedService.selectedImage$.subscribe(img => this.selectedImage = img!);

  }


  CliqueNovo(){
    this.clienteService.setChangesA(false);
    this.clienteService.setClienteAtual(this.clienteService.Vazia[0]);
    this.clienteService.setClienteA(-1);
    setTimeout(() => {
      this.clienteService.setChangesA(true);
    }, 0)

  }

  ngOnDestroy() {
    this.subscription.unsubscribe();

  }

    ngOnInit(): void {
      this.clienteService.ClienteAtual$.subscribe(clienteAtual => {
        this.Atual = clienteAtual;
        console.log(this.Atual)
      });
      this.clienteService.ChangesA$.subscribe(chng => {
        this.nChanges = chng;
      });
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

  abrirModal() {
    const dialogRef = this.dialog.open(MeuModalComponent, {
        disableClose: true  // Isto impede que o modal seja fechado ao clicar fora dele ou pressionar ESC
    });
    dialogRef.afterClosed().subscribe(result => {
      // console.log('O modal foi fechado');
      // Você pode adicionar mais lógicas aqui se necessário.
    });
  }

  buscarAlteracoes(event:any){
    let TabNas: string = new Date().toISOString().split('T')[0];
      const TabForm = this.formCliente.clienteform.value
      if(TabForm.telComercial == null){
        TabForm.telComercial="0";
      }
      if(this.Atual.TelCom == null){
        this.Atual.TelCom="0";
      }

      let Dif = 0;
      console.log('Id atual: ' + this.Atual.Id)

      this.Atual.Nome !== TabForm.nome ?  Dif+=1 : null;
      this.Atual.Nascimento == '' ?  this.Atual.Nascimento = new Date().toISOString().split('T')[0] : null;
      this.Atual.Nascimento !== TabForm.dtNascim ?  Dif+=1 : null;
      this.Atual.Desde == '' ?  this.Atual.Desde = new Date().toLocaleDateString() : null;
      this.Atual.DtIncl == '' ?  this.Atual.DtIncl = new Date().toLocaleDateString() : null;
      this.Atual.Identidade !== TabForm.identidade ?  Dif+=1 : null;
      this.Atual.Email !== TabForm.email ?  Dif+=1 : null;
      this.Atual.TelefoneFixo !== TabForm.telFixo ?  Dif+=1 : null;
      this.Atual.Celular !== TabForm.celular ?  Dif+=1 : null;
      this.Atual.Endereco !== TabForm.endereco ?  Dif+=1 : null;
      this.Atual.NomeMae !== TabForm.mae ?  Dif+=1 : null;
      this.Atual.TelCom !== TabForm.telComercial ?  Dif+=1 : null;
      this.Atual.NomePai !== TabForm.pai ?  Dif+=1 : null;

      // console.log('Id atual: ' + this.Atual.Id + '(Atual) e ' + TabForm.Id + '(TabForm)')
      // console.log('Diferenças encontradas: ' + Dif)
      // console.log(this.Atual.DtIncl + ' - ' + typeof this.Atual.DtIncl)
      // console.log(this.Atual.Desde + ' - ' + typeof this.Atual.Desde)
      // console.log(this.Atual.Nascimento + ' - ' + typeof this.Atual.Nascimento)
      // console.log('TAB ' + TabForm.dtNascim + ' - ' + typeof TabForm.dtNascim)
      console.log('TAB Antes: ' + TabNas)
      console.log(TabForm.dtNascim)

      try{
        let a = TabForm.dtNascim;
        console.log('a'+a)
        let b = this.reDatas(a);
        console.log('b'+b)
        let c = b.split('T')[0];
        console.log('c'+c)
        TabNas = c
      }
      catch
      {
        let b = new Date();
        console.log('b'+b)
        let c = b.toISOString();
        console.log('c'+c)
        TabNas = c.split('T')[0];
        TabNas = new Date().toISOString().split('T')[0];
      }

      console.log('TAB depois: ' + TabNas)
      console.log('Diferenças: ' + Dif)
      console.log('Sai: ' + TabForm.saSozinho + ' //' + typeof TabForm.saSozinho)
      //if(Dif>0){
        let Tab: Cliente = {
          id: this.Atual.Id == null ? 0 : this.Atual.Id,
          nome: TabForm.nome == null ? '0' : TabForm.nome,
          mae: TabForm.mae == null ? '0' : TabForm.mae,
          pai: TabForm.pai == null ? '0' : TabForm.pai,
          //dtInclusao: this.Atual.DtIncl == null ? new Date().toString : this.Atual.DtIncl,
          dtInclusao: this.Atual.DtIncl == null ? new Date().toISOString() : this.reDatas(this.Atual.DtIncl),
          maeRestric: TabForm.maeRestric == null ? false : TabForm.maeRestric,
          paiRestric: TabForm.paiRestric == null ? false : TabForm.paiRestric,
          saSozinho: TabForm.saSozinho == null ? false : TabForm.saSozinho,
          respFinanc: TabForm.respFinanc == null ? 'Mãe' : TabForm.respFinanc,
          identidade: TabForm.identidade == null ? '0' : TabForm.identidade.toString(),
          //dtNascim: TabForm.dtNascim == null ? new Date().toString : TabForm.dtNascim,
          //dtNascim: TabForm.dtNascim == null ? new Date().toISOString().split('T')[0] : new Date(TabForm.dtNascim).toISOString().split('T')[0],
          dtNascim: TabNas,
          celular: TabForm.celular == null ? '0' : TabForm.celular,
          telFixo: TabForm.telFixo == null ? '0' : TabForm.telFixo,
          telComercial: TabForm.telComercial == null ? '0' : TabForm.telComercial,
          email: TabForm.email == null ? '0' : TabForm.email,
          endereco: TabForm.endereco == null ? '0' : TabForm.endereco,
          //clienteDesde: this.Atual.Desde == null ? new Date().toString : this.Atual.Desde,
          clienteDesde: this.Atual.Desde == null ? new Date().toISOString() : this.reDatas(this.Atual.DtIncl),
          ativo: true,
          areaSession: TabForm.mae == null ? '' : this.Atual.Area,
        }
        console.log(Tab.dtInclusao + ' (Inclusão) ' + typeof Tab.dtInclusao)
        console.log(Tab.dtNascim + ' (Nascimento) ' + typeof Tab.dtNascim)
        console.log(Tab.clienteDesde + ' (Desde) ' + typeof Tab.clienteDesde)

        if(Tab.id==0){
          console.log(Tab.id + ' - indo para create')
          console.log(Tab)
          this.createCliente(Tab)
        }else{
          console.log(Tab.id + ' - indo para update')
          console.log(Tab)
          this.updateCliente(Tab)
        }

      //}

  }

    FTel(telefone: string) {
      let somenteNumeros = parseInt(telefone.replace(/\D/g, ''));
      return +somenteNumeros;
    }


    reDatas(dataO: string){
      console.log('reDatas: ' + dataO)

      const [dia, mes, ano] = dataO.split('/');
      if(dia.length == 2){
        const data = new Date(Number(ano), Number(mes) - 1, Number(dia));
        const dataFormatada = data.toISOString();
        console.log('Formatada: ' + dataFormatada);
        return (dataFormatada);
      }
      else{
        console.log('Original: ' + dataO);
        return (dataO);
      }

    }

  createCliente(cliente: Cliente){
    this.clienteService.CreateCliente(cliente).subscribe((data) => {
      console.log(data)
      this.delay(300)
      alert('Registro gravado!')
      location.reload()
    }, error => {
      console.error('Erro no upload', error);
    });
  }

    updateCliente(cliente: Cliente){
      this.clienteService.UpdateCliente(cliente).subscribe((data) => {
        console.log(data)
        this.delay(300)
        alert('Registro atualizado!')
        location.reload()
      }, error => {
        console.error('Erro no upload', error);
      });
    }
      delay(time:number) {
        setTimeout(() => {

        }, time);
      }

  onButtonClick(){

  }

}


