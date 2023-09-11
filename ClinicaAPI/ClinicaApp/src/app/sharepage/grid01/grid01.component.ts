import { SharedService } from '../../shared/shared.service';  // Atualize o caminho
import { ClienteService } from 'src/app/services/cliente/cliente.service';
import { TableData } from 'src/app/models/Tables/TableData';
import { Subscription } from 'rxjs';
import { Component, ViewChild } from '@angular/core';
import { FormClienteComponent } from '../form-cliente/form-cliente.component';
import{FileService}from '../../services/foto-service.service';


@Component({
  selector: 'app-grid01',
  templateUrl: './grid01.component.html',
  styleUrls: ['./grid01.component.css']
})
export class Grid01Component {
  public caminho: string = '';
  dataSource: TableData[] = [];
  public nLin: TableData[] = [];
  public Verifica: boolean = false;
  subscription: Subscription;
  nChanges!: boolean;
  @ViewChild(FormClienteComponent) formCli!: FormClienteComponent;

  ngOnInit(): void {

    this.clienteService.GetClientes().subscribe(data => {
      const dados = data.dados;
      dados.map((item) => {
        item.clienteDesde !== null ? item.clienteDesde = new Date(item.clienteDesde!).toLocaleDateString('pt-BR') : '---'
        item.dtInclusao !== null ? item.dtInclusao = new Date(item.dtInclusao!).toLocaleDateString('pt-BR') : '---'
        item.dtNascim !== null ? item.dtNascim = new Date(item.dtNascim!).toLocaleDateString('pt-BR') : '---'
      })
      this.clienteService.clientes = data.dados;
      this.clienteService.clientesG = data.dados;
      this.clienteService.clientesG.sort((a, b) => a.nome.localeCompare(b.nome));

      this.Carregar();
    });


  }

  async Carregar(){
    for (let i of this.clienteService.clientesG) {
      let aCelular: string = '---';
      let aComercial: string = '---';
      let aFixo: string = '---';
      let aSaiS: string = 'Não';
      let aRestM: string = 'Não';
      let aRestP: string = 'Não';

      if(i.id !== undefined){
        if(i.celular!== undefined && i.celular!== null){
          aCelular = i.celular.toString();
          if (aCelular.length === 7) {
            aCelular = `# ${aCelular.slice(0, 4)}-${aCelular.slice(4)}`;
          } else if (aCelular.length === 8) {
            aCelular = `${aCelular.slice(0, 4)}-${aCelular.slice(4)}`;
          } else {
            aCelular = '---';
          }
        }
        if(i.saSozinho == true){
          aSaiS = 'Sim';
        }
        if(i.telComercial!== undefined && i.telComercial!== null){
          aComercial = i.telComercial.toString();
          if (aComercial.length === 7) {
            aComercial = `# ${aComercial.slice(0, 4)}-${aComercial.slice(4)}`;
          } else if (aComercial.length === 8) {
            aComercial = `${aComercial.slice(0, 4)}-${aComercial.slice(4)}`;
          } else {
            aComercial = '---';
          }
        }
        if(i.telFixo!== undefined && i.telFixo!== null){
          aFixo = i.telFixo.toString();
          if (aFixo.length === 7) {
            aFixo = `# ${aFixo.slice(0, 4)}-${aFixo.slice(4)}`;
          } else if (aFixo.length === 8) {
            aFixo =  `${aFixo.slice(0, 4)}-${aFixo.slice(4)}`;
          } else {
            aFixo = '---';
          }
        }
        if(i.maeRestric == true){
          aRestM = 'Sim';
        }
        if(i.paiRestric == true){
          aRestP = 'Sim';
        }

        const aId: string = i.id.toString().padStart(4, '0');
        const aIdade1 = this.converterParaDate(i.dtNascim);
        const aIdade: string = this.calcularIdade(aIdade1) + ' anos';
        this.caminho = '../../assets/img/Clientes/' + aId + '.jpg';
        const imagemValida = await this.verificarImagem(this.caminho);
        //console.log('imagem ' + this.Verifica)
          if (imagemValida !== true) {
            this.caminho = '../../assets/img/Clientes/0000.jpg';
        }
        this.nLin =[{Foto: this.caminho,
          Ficha: aId,
          Id: i.id,
          Nome: i.nome,
          SaiSoz: aSaiS,
          Nascimento: i.dtNascim,
          Area: i.areaSession,
          TelefoneFixo: aFixo,
          Celular: aCelular,
          selecionada: false,
          Idade:aIdade,
          Desde:i.clienteDesde,
          NomeMae: i.mae,
          NomePai: i.pai,
          DtIncl: i.dtInclusao,
          RespFin: i.respFinanc,
          Endereco: i.endereco,
          Email: i.email,
          RestrMae: aRestM,
          RestrPai: aRestP,
          Identidade: i.identidade,
          Ativo: i.ativo
        }];
        this.dataSource = [...this.dataSource, ...this.nLin]

      }
    }
  }
  verificarImagem(url: string): Promise<boolean> {
    return new Promise((resolve) => {
      const img = new Image();
      img.onload = () => resolve(true);
      img.onerror = () => resolve(false);
      img.src = url;
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




  destacarLinha(l:any, lFicha: string) {

    this.nChanges = false;
    this.clienteService.setChangesA(false);
    let numero = parseInt(l.Ficha, 10);
      if (isNaN(numero)) {
        numero = 0;
    }

    this.dataSource.forEach(l => l.selecionada = false);// Desmarcar todas as outras linhas
    this.clienteService.setClienteA(numero);

    // const Vazia1 = this.dataSource.find(cliente => cliente.Id === numero)

    this.clienteService.setClienteAtual(this.dataSource.find(cliente => parseInt(cliente.Ficha, 10) === numero) || this.clienteService.Vazia[0]);
    //console.log(this.dataSource);
    l.selecionada = true;// Marcar a linha clicada
    this.nChanges = true;
    setTimeout(() => {
      this.clienteService.setChangesA(true);
    }, 0)
    console.log(l)
  }



  constructor(private fileService: FileService, private sharedService: SharedService, private clienteService: ClienteService) {

    this.subscription = this.clienteService.ChangesA$.subscribe(
      name => this.nChanges = name
    )

  }

}
