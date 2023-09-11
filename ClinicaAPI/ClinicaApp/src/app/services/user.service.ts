import { Subject } from 'rxjs';
import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";
import { TokenService } from "./token.service";
import {Colaborador} from '../models/Colaboradors'
import jwt_decode from 'jwt-decode';
import { Router } from "@angular/router";
import { User } from '../models';



@Injectable({
  providedIn:'root'
})
export class UserService {
  private user: any;

  public userSubject = new BehaviorSubject<User | null>(null);
  private userLogged = new BehaviorSubject<boolean>(false);
  public UsrLogA!: User;

  constructor(private tokenService: TokenService, private router: Router){

    if(this.tokenService.hasToken())
      this.decodeAndNotify();
  }

  setToken(token: string){

    this.tokenService.setToken(token);
    this.decodeAndNotify();

  }


  setUser(user: User) {
    this.userSubject.next(user);
  }

  getUser(){

    return this.userSubject.asObservable();

  }

  private decodeAndNotify() {

    const token: string = this.tokenService.getToken();
    const user = jwt_decode(token) as User;
    this.userSubject.next(user);
    console.log('Usuário... ')
    console.log(user)
    this.setUserA(user)
    this.userLogged.next(true);

  }

  setUserA(user: any) {
    this.user = user;
    this.UsrLogA = this.user;
  }

  getUserA() {
    return this.user;
  }

  logout() {

    this.tokenService.removeToken();
    this.userSubject.next(null);
    this.userLogged.next(false);
    this.router.navigate(['']);

  }

  isLogged() {
    return this.tokenService.hasToken();
  }

  get isLoggedIn() {
    return this.userLogged.asObservable();
  }

}

/*
export class FocoService {
  private componenteFocado = new Subject<any>();
  componenteFocado$ = this.componenteFocado.asObservable();

  focoRecebido(componente: any) {
    this.componenteFocado.next(componente);
  }
}
*/


// import { environment } from '../environments-antigo/environment';
// import { User } from '../models';

// const baseUrl = `${environment.apiUrl}/users`;

// @Injectable({ providedIn: 'root' })
// export class UserService {
//     constructor(private http: HttpClient) { }

//     getAll() {
//         return this.http.get<User[]>(baseUrl);
//     }

//     getById(id: string) {
//         return this.http.get<User>(`${baseUrl}/${id}`);
//     }

//     create(params: any) {
//         return this.http.post(baseUrl, params);
//     }

//     update(id: string, params: any) {
//         return this.http.put(`${baseUrl}/${id}`, params);
//     }

//     delete(id: string) {
//         return this.http.delete(`${baseUrl}/${id}`);
//     }
// }
