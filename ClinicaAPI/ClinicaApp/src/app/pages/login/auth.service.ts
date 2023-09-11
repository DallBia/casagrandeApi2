import { Injectable } from '@angular/core';
import { Router } from "@angular/router";
import { tap, catchError, map, Observable, throwError, of, BehaviorSubject } from "rxjs";
//import { tap } from 'rxjs';
import { TokenService } from "../../services/token.service";
import { ColaboradorService } from 'src/app/services/colaborador/colaborador.service';
import { HttpClient, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { UserService } from "../../services/user.service";
import { environment } from 'src/environments/environment';
import{NavbarComponent } from '../../sharepage/navbar/navbar.component'

  const API = `${environment.ApiUrl}`

  @Injectable({  providedIn: 'root'})
  export class AuthService {

    constructor(private http: HttpClient,
                private userService: UserService,
                private tokenService: TokenService,
                private router: Router) {

    }

    authenticate(userName: string, password: string) {

      const body = {
        Usuario: userName,
        Senha: password
      };
      return this.http
      .post(
          API + '/User',body, { observe: 'response' }
      )
      .pipe(tap(res => {
          const authToken = res.body as any;
          this.userService.setToken(authToken.token);
          this.userService.setUser(authToken);
          this.userService.setUserA(authToken);
          console.log(res.headers.get('Baerer'));
          console.log(`User ${userName} authenticated with token ${authToken.token}`);
      }))
    }



  }


  /*
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if(this.tokenService.hasToken()) {
      const token = this.tokenService.getToken();
      req = req.clone({
        setHeaders: { 'Authorization' : 'Bearer ' + token }
      })
     }
     return next.handle(req).pipe(catchError( (error) => {
      if(error.status == 401)
       {
        this.tokenService.removeToken();
        this.userService.logout();
        this.router.navigate(['/']);
        return error;
        }
        else if(error.status == 0)
        {
          console.log('erro = 0!');
          console.log(error);
          this.userService.logout();
          this.tokenService.removeToken();
          this.router.navigate(['/']);
        }
        else
        {
          console.log('Erro não tratado no interceptor');
          console.log(error);
        }
      })) as Observable<HttpEvent<any>>;
}}
*/

/*
export class AuthService {

constructor(private colab: ColaboradorService) {

}
  // Defina o email e senha predefinidos
  private readonly predefinedEmail = 'admin@example.com';
  private readonly predefinedPassword = 'password123';

  login(email: string, password: string): Observable<boolean> {
    if (email === this.predefinedEmail && password === this.predefinedPassword) {
      const fakeJWTToken = 'fake-jwt-token';
      localStorage.setItem('access_token', fakeJWTToken);
      return of(true);
    } else {
      return of(false);
    }
  }
  logout() {
    localStorage.removeItem('access_token');
  }

  public get loggedIn(): boolean {
    return localStorage.getItem('access_token') !== null;
  }
}
*/

/*


    dados.map((item) => {
      item.DtDeslig = new Date(item.DtDeslig!).toLocaleDateString('pt-BR');
      item.DtAdmis = new Date(item.DtAdmis!).toLocaleDateString('pt-BR');
      item.DtNasc = new Date(item.DtNasc!).toLocaleDateString('pt-BR');
    });

login(email: string, password: string) {
  this.colab.GetColaboradorbyEmail(email, password).subscribe((data) => {
    const dados = data.dados;
    console.log(dados)
    dados.map((item) => {
      item.DtDeslig = new Date(item.DtDeslig!).toLocaleDateString('pt-BR');
      item.DtAdmis = new Date(item.DtAdmis!).toLocaleDateString('pt-BR');
      item.DtNasc = new Date(item.DtNasc!).toLocaleDateString('pt-BR');
    });
    this.colab.colaboradores = data.dados;
    this.colab.colaboradorG = data.dados;
    this.colab.colaboradorG.sort((a, b) => a.Nome.localeCompare(b.Nome));
    console.log(this.colab.colaboradores);
    if (data) {
      const fakeJWTToken = 'fake-jwt-token';
      localStorage.setItem('access_token', fakeJWTToken);
      this.router.navigate(['/inicio']);
    } else {
      alert('Login failed');
    }
  });*/
// }

