import { ClienteService } from 'src/app/services/cliente/cliente.service';
import { Component, OnInit } from '@angular/core';
import { Cliente } from 'src/app/models/Clientes';

@Component({
  selector: 'app-controle-finaceiro',
  templateUrl: './controle-finaceiro.component.html',
  styleUrls: ['./controle-finaceiro.component.css']
})
export class ControleFinaceiroComponent implements OnInit{

  ResultParametros = '';
  Resultado = 'ainda sem resultados';

constructor(public clienteService: ClienteService){}
  ngOnInit(): void {
    this.clienteService.GetClientes().subscribe(data => {
      const dados = data.dados;
      dados.map((item) =>{
        item.dtInclusao = new Date(item.dtInclusao!).toLocaleDateString('pt-BR');
        item.clienteDesde = new Date(item.clienteDesde!).toLocaleDateString('pt-BR');
        item.dtNascim = new Date(item.dtNascim!).toLocaleDateString('pt-BR');
        console.log(item);
      })
    // this.clienteService.clientes = data.dados;
    this.clienteService.clientesG = data.dados;
    });
  }
  Filt = '';
  PorNome(param: any){
    if(this.Filt == 'Nome'){
      this.clienteService.clientes = this.clienteService.clientesG.filter(cliente => {
        return cliente.nome.toLowerCase().includes(param.toLowerCase());
    })};

    if(this.Filt == 'Área'){
      this.clienteService.clientes = this.clienteService.clientesG.filter(cliente => {
        return cliente.areaSession.toLowerCase().includes(param.toLowerCase());
    })};
    if(this.Filt == 'Email'){
      this.clienteService.clientes = this.clienteService.clientesG.filter(cliente => {
        return cliente.email.toLowerCase().includes(param.toLowerCase());
    })};
  }
}
