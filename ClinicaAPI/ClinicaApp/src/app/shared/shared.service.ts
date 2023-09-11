import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  private selectedNameSubject = new BehaviorSubject<string>('');
  selectedName$ = this.selectedNameSubject.asObservable();
  setSelectedName(name: string) {
    this.selectedNameSubject.next(name);
  }
  private selectedFichaSubject = new BehaviorSubject<string>('NOVO');
  selectedFicha$ = this.selectedFichaSubject.asObservable();
  setSelectedFicha(name: string) {
    this.selectedFichaSubject.next(name);
  }
  private selectedNascimentoSubject = new BehaviorSubject<string>('');
  selectedNascimento$ = this.selectedNascimentoSubject.asObservable();
    setSelectedNascimento(name: string) {
    this.selectedNascimentoSubject.next(name);
  }

  private selectedImageSource = new BehaviorSubject<string | null>(null);

  selectedImage$ = this.selectedImageSource.asObservable();

  setSelectedImage(imageUrl: string): void {
    this.selectedImageSource.next(imageUrl);
  }





  public listaNomes = [
    { Ficha: '002', Completo: 'Antonio Carlos da Silva', Nascimento: '05/11/1988', Area: 'Fonoaudiologia', ImageUrl: 'assets/img/foto-perfil/002.jpg'  },
    { Ficha: '003', Completo: 'Ronaldo L Lima', Nascimento: '19/11/2006', Area: 'Consulta', ImageUrl: 'assets/img/foto-perfil/003.jpg' },
    { Ficha: '004', Completo: 'Neymar S Júnior', Nascimento: '25/07/2011', Area: 'Psicopedagogia', ImageUrl: 'assets/img/foto-perfil/004.jpg' },
    { Ficha: '005', Completo: 'Ronaldo A Moreira', Nascimento: '18/03/1984', Area: 'Reforço escolar', ImageUrl: 'assets/img/foto-perfil/005.jpg' },
    { Ficha: '006', Completo: 'Ricardo I Leite', Nascimento: '03/08/2011', Area: 'Tratamento', ImageUrl: 'assets/img/foto-perfil/006.jpg' },
    { Ficha: '007', Completo: 'Roberto C Silva', Nascimento: '24/11/1983', Area: 'Fonoaudiologia', ImageUrl: 'assets/img/foto-perfil/007.jpg' },
    { Ficha: '008', Completo: 'Marcos E Morais', Nascimento: '02/12/2006', Area: 'Consulta', ImageUrl: 'assets/img/foto-perfil/008.jpg' },
    { Ficha: '009', Completo: 'Rivaldo V Ferreira', Nascimento: '10/01/1990', Area: 'Psicologia', ImageUrl: 'assets/img/foto-perfil/009.jpg'},
    { Ficha: '010', Completo: 'Romário S Faria', Nascimento: '21/04/2006', Area: 'Consulta', ImageUrl: 'assets/img/foto-perfil/010.jpg' },
    { Ficha: '011', Completo: 'Denilson O Araújo', Nascimento: '15/10/2007', Area: 'Consulta', ImageUrl: 'assets/img/foto-perfil/011.jpg' },
    { Ficha: '012', Completo: 'Adriano L Ribeiro', Nascimento: '02/06/2008', Area: 'Consulta', ImageUrl: 'assets/img/foto-perfil/012.jpg' },
    { Ficha: '013', Completo: 'Antônio A Silva', Nascimento: '07/03/2009', Area: 'Consulta', ImageUrl: 'assets/img/foto-perfil/013.jpg' },
    { Ficha: '014', Completo: 'Arthur A Coimbra', Nascimento: '08/09/2007', Area: 'Fonoaudiologia', ImageUrl: 'assets/img/foto-perfil/014.jpg' },
    { Ficha: '015', Completo: 'Ricardo Inamorato', Nascimento: '11/09/1998', Area: 'Tratamento', ImageUrl: 'assets/img/foto-perfil/015.jpg' },
    { Ficha: '016', Completo: 'José R Júnior', Nascimento: '11/07/2014', Area: 'Tratamento', ImageUrl: 'assets/img/foto-perfil/016.jpg' },
    { Ficha: '017', Completo: 'Edmundo A Neto', Nascimento: '12/02/1993', Area: 'Fonoaudiologia', ImageUrl: 'assets/img/foto-perfil/018.jpg' },
    { Ficha: '018', Completo: 'Djalma S Santos', Nascimento: '17/10/1984', Area: 'Tratamento', ImageUrl: 'assets/img/foto-perfil/019.jpg' },
    { Ficha: '019', Completo: 'Arthur Castro', Nascimento: '29/02/2008', Area: 'Consulta', ImageUrl: 'assets/img/foto-perfil/020.jpg' },
  ];

  private selectedRowSource = new BehaviorSubject<any>(null);
    currentSelectedRow = this.selectedRowSource.asObservable();

  changeSelectedRow(row: any) {
        this.selectedRowSource.next(row);
    }


    constructor() {

    }
}
