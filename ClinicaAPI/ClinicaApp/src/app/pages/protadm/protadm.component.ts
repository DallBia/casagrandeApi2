import { Component, OnDestroy } from '@angular/core';
import { SharedService } from '../../shared/shared.service';  // Atualize o caminho
import { Subscription } from 'rxjs';


@Component({
  selector: 'app-protadm',
  templateUrl: './protadm.component.html',
  styleUrls: ['./protadm.component.css']
})


export class ProtadmComponent implements OnDestroy{
  public selectedNascimento: string = '';
  public idade1: any;
  public idade: any;
  private subscription: Subscription;




  constructor(private sharedService: SharedService) {
    this.subscription = this.sharedService.selectedNascimento$.subscribe(
    name => this.selectedNascimento = name );
    this.idade1 = this.converterParaDate(this.selectedNascimento);
    this.idade = this.calcularIdade(this.idade1);

  }


  imageUrl = 'http://localhost:5000/wwwroot/003.jpg';


  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  converterParaDate(dataString: string): Date {
    const [dia, mes, ano] = dataString.split('/').map(Number);
    return new Date(ano, mes - 1, dia);
}
  calcularIdade(dataNascimento: Date): number {
    const hoje = new Date();
    let idade = hoje.getFullYear() - dataNascimento.getFullYear();

    // Ajuste para caso o aniversário ainda não tenha ocorrido este ano
    const m = hoje.getMonth() - dataNascimento.getMonth();
    if (m < 0 || (m === 0 && hoje.getDate() < dataNascimento.getDate())) {
        idade--;
    }

    return idade;
  }
}
