import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Colaborador } from 'src/app/models/Colaboradors';
import { environment } from 'src/environments/environment';
import { Response } from '../../models/Response';

@Injectable({
  providedIn: 'root'
})
export class ColaboradorService {
  private apiurl = `${environment.ApiUrl}/Colaborador`
  constructor(private http: HttpClient) { }


  public colaboradores: Colaborador[] = [];
  public colaboradorG: Colaborador[] = [];
  // public ClienteAtual: Cliente[] = [];
  // public ClienteN: number = 0;
  private apiurllogin = `${environment.ApiUrl}/Colaborador/Email`;

GetColaboradorbyEmail(Login: string, senha: string): Observable<Response<Colaborador[]>> {
  const body = { Login: Login, Senha: senha };
  return this.http.post<Response<Colaborador[]>>(this.apiurllogin, body);
}
}
