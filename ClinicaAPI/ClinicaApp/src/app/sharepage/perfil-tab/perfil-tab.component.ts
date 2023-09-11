import { PerfilService } from 'src/app/services/perfil/perfil.service';
import { Subscription } from 'rxjs';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Perfil } from 'src/app/models/Perfils';

@Component({
  selector: 'app-perfil-tab',
  templateUrl: './perfil-tab.component.html',
  styleUrls: ['./perfil-tab.component.css']
})
export class PerfilTabComponent implements OnInit{
  public perfil: Perfil[] = [];
  public nLin: Perfil[] = [];
  public Atual!: Perfil[];
    constructor(private perfilService: PerfilService) {}

  ngOnInit(): void {
    this.perfilService.GetPerfil().subscribe(data => {
      const dados = data.dados;
      dados.map((item) => {
        item.Dir !== null ? item.Dir = item.Dir : item.Dir = false;
        item.Secr !== null ? item.Secr = item.Secr : item.Secr = false;
        item.Coord !== null ? item.Coord = item.Coord : item.Coord = false;
      })
      this.perfilService.perfils = data.dados;
      this.perfilService.perfils.sort((a, b) => a.Id - b.Id);
      // this.perfil = this.perfilService.perfils; // Aqui, você deve atribuir os dados a this.perfil
      console.log(this.perfilService.perfils);
      this.Carregar();
      console.log(this.perfil);
    });

    // this.perfilService.PerfilAtual$.subscribe(perfilAtual => {
    //   this.Atual = perfilAtual;
    // });
  }

  Carregar(){
    for (let i of this.perfilService.perfils) {
      this.nLin =[{
        Id: i.Id,
        Descricao: i.Descricao,
        Help: i.Help,
        Dir: i.Dir,
        Secr: i.Secr,
        Coord: i.Coord,
        Equipe: i.Equipe,
        SiMesmo: i.SiMesmo
      }];
      this.perfil = [...this.perfil, ...this.nLin]
    }
  }


}
