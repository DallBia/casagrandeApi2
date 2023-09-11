import { Component, OnInit } from '@angular/core';
import { AuthService } from './auth.service';
import { Router } from '@angular/router';
import { ColaboradorService } from 'src/app/services/colaborador/colaborador.service';
import { Subscription, BehaviorSubject } from 'rxjs';
import { UserService } from '../../services/user.service'; // Importe o UserService aqui
import { User } from '../../models/user'; // Importe a classe User aqui

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public Perf: string='';
  public UsrLog: string  = '';
  public UsrLogA: any;
  private subscription!: Subscription;



  constructor(private colab: ColaboradorService,
              private authService: AuthService,
              private router: Router,
              public userService: UserService,

    ) {}

  login(email: string, password: string) {
    this.authService.authenticate(email, password).subscribe(
      (success) => {
        if (success) {
          this.router.navigate(['/inicio']);
        } else {
          alert('OOoOOOooOOoPs! Não foi possível fazer o Login... :(');
        }
      },
      (err) => {
        console.error(err);
      }
    );
  }

  ngOnInit(): void {
    this.UsrLogA=this.userService.getUser();
    if(this.UsrLogA != null){
      this.UsrLog = this.DefinirUsuario(this.UsrLogA)
    };

  }


DefinirUsuario(n: User){
  if(n.perfil != null)
  {
    if(n.perfil?.toString() == '0') {
      this.Perf = 'Diretoria';
    }
    if(n.perfil?.toString() == '1') {
      this.Perf = 'Secretaria';
    }
    if(n.perfil?.toString() == '2') {
      this.Perf = 'Coordenação';
    }
    if(n.perfil?.toString() == '3') {
      this.Perf = 'Equipe Clínica';
    }
  }
  return n.name + ' (' + this.Perf + ')'
}
}



// login(email: string, password: string) {
//   this.colab.GetColaboradorbyEmail(email, password).subscribe((data) => {
//     const dados = data.dados;
//     console.log(dados)

//     this.colab.colaboradores = data.dados;
//     this.colab.colaboradorG.sort((a, b) => a.Nome.localeCompare(b.Nome));
//     console.log(this.colab.colaboradores);
//   });
// }
// }




/*  login(email: string, password: string) {
    this.authService.login(email,password);
  }
*/
