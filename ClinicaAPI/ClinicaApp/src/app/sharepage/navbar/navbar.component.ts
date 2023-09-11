import { User } from './../../models/user';
import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd, ActivatedRoute } from '@angular/router';
import { filter } from 'rxjs/operators';
import { HeaderService } from './header.service';
import { ClienteService } from 'src/app/services/cliente/cliente.service';
import { UserService } from '../../services/user.service'; // Importe o UserService aqui
import { Subscription, BehaviorSubject } from 'rxjs';
import { LoginComponent } from 'src/app/pages/login/login.component';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
  template: `
  <button (click)="abrirCalendario()">Abrir Calendário</button>
`,
styles: []
})
export class NavbarComponent implements OnInit {
  imageLogo = 'assets/img/CasagrandeLogo.png'; // Caminho relativo à pasta de ativos
  imageNot= 'assets/img/bell-fill.svg';
  dataAtual = new Date;
  UsrLog: string = 'usuário';
  UsrLogA!: User;
  public Perf: string = '';

  constructor(
    private clienteService: ClienteService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    public headerService: HeaderService,
    public userService: UserService,

  ) {}

  ngOnInit(): void {

    this.router.events
      .pipe(filter(event => event instanceof NavigationEnd))
      .subscribe(() => {
        this.atualizarLinkAtivo();
      });
      this.UsrLogA = this.userService.UsrLogA;
      if(this.UsrLogA != null){

        if(this.UsrLogA.perfil?.toString() == '0') {
          this.Perf = 'Diretoria';
          }
          if(this.UsrLogA.perfil?.toString() == '1') {
            this.Perf = 'Secretaria';
          }
          if(this.UsrLogA.perfil?.toString() == '2') {
            this.Perf = 'Coordenação';
          }
          if(this.UsrLogA.perfil?.toString() == '3') {
            this.Perf = 'Equipe Clínica';
          }
        this.UsrLog = this.UsrLogA.name + ' (' +  this.Perf + ')';
      }

  }

  atualizarLinkAtivo(): void {
    const child = this.activatedRoute.firstChild;
    if (child) {
      const snapshot = child.snapshot;
      if (snapshot.data && snapshot.data['title']) {
        this.headerService.linkAtivo = snapshot.data['title'];
      }
    }
  }

}
