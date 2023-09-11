import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from 'src/app/models/Clientes';
import { environment } from 'src/environments/environment';
import { Response } from '../../models/Response';
import { BehaviorSubject } from 'rxjs';
import { TableData } from 'src/app/models/Tables/TableData';
import { TabResult } from 'src/app/models/Tables/TabResult';

@Injectable({
  providedIn: 'root'
})


export class ClienteService {
  public Vazia: TableData[] = [{
    Foto: '../../assets/img/Clientes/0000.jpg',
    Ficha: '',
    Id: 0,
    Nome: '',
    Nascimento: '',
    Area: '',
    selecionada: false,
    SaiSoz: '',
    Idade: '',
    Desde: '',
    Proxses: '',
    TelefoneFixo:'',
    Celular: '',
    TelCom: '',
    NomeMae: '',
    NomePai: '',
    DtIncl: '',
    RespFin: '',
    Endereco: '',
    Email: '',
    RestrMae: '',
    RestrPai: '',
    Identidade: '0',
    Ativo: false
    }];

  constructor(private http: HttpClient) { }

  public clientes: Cliente[] = [];
  public clientesG: Cliente[] = [];
  // public ClienteAtual: Cliente[] = [];
  // public ClienteN: number = 0;

 private apiurl = `${environment.ApiUrl}/Cliente`
  GetClientes() : Observable<Response<Cliente[]>>{
    return this.http.get<Response<Cliente[]>>(this.apiurl);
  }
  CreateCliente(cliente: Cliente) : Observable<Response<Cliente[]>>{
    return this.http.post<Response<Cliente[]>>(`${this.apiurl}` , cliente);
  }
  UpdateCliente(cliente: Cliente) : Observable<Response<Cliente[]>>{
    return this.http.put<Response<Cliente[]>>(`${this.apiurl}/Editar` , cliente);
  }

  private ClienteAtual = new BehaviorSubject<TableData>(this.Vazia[0]);
  ClienteAtual$ = this.ClienteAtual.asObservable();
  setClienteAtual(name: TableData) {
    this.ClienteAtual.next(name);
  }

  private ClienteA = new BehaviorSubject<number>(0);
  ClienteA$ = this.ClienteA.asObservable();
  setClienteA(name: number) {
    this.ClienteA.next(name);
  }

  private ChangesA = new BehaviorSubject<boolean>(false);
  ChangesA$ = this.ChangesA.asObservable();
  setChangesA(name: boolean) {
    this.ChangesA.next(name);
  }


  ngOnInit(){

  }

}
