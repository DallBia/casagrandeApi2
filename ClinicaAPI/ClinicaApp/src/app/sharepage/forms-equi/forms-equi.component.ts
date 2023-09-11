import { Component, OnDestroy } from '@angular/core';
import { SharedService } from '../../shared/shared.service';  // Atualize o caminho
import { Subscription } from 'rxjs';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-forms-equi',
  templateUrl: './forms-equi.component.html',
  styleUrls: ['./forms-equi.component.css']
})
export class FormsEquiComponent {
  selectedName: string = '';
  selectedNascimento: string = '';
  selectedImage: string = '';
  private subscription: Subscription;

  infoContainer = [
    {altura:'55vh', largura: "80vh"}
  ]

  constructor(private sharedService: SharedService){
    this.subscription = this.sharedService.selectedName$.subscribe(
      name => this.selectedName = name
      
    );
    this.subscription = this.sharedService.selectedNascimento$.subscribe(
      name => this.selectedNascimento = name
      
    );
    this.subscription = this.sharedService.selectedImage$.subscribe(
      imageUrl => this.selectedImage = imageUrl || ''
   );
  
}
private destroy$ = new  Subject<void>();
/*ngOnInit(): void {
  this.sharedService.selectedImage$.subscribe(imageUrl => {
    this.selectedImage = imageUrl;
  });
}*/
ngOnDestroy() {
  this.subscription.unsubscribe();
  this.destroy$.next();
  this.destroy$.complete();
}
}