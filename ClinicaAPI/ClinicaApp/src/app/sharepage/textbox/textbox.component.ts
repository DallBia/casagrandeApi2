import { SharedService } from './../../shared/shared.service';
import { Component, Input } from '@angular/core';
import { FileService } from '../../services/foto-service.service';


@Component({
  selector: 'app-textbox',
  templateUrl: './textbox.component.html',
  styleUrls: ['./textbox.component.css']
})



export class TextboxComponent {

  @Input() label: string = "label";
  @Input() nome: string = "(nome)";
  @Input() largura: string = "10px";
  @Input() altura: string = "10px";




  selectedFile: File | null = null;

  constructor(private fileService: FileService) { }

  onFileSelected(event: any) {
      this.selectedFile = <File>event.target.files[0];
  }

  onSubmit() {
    if (this.selectedFile) {
      this.fileService.uploadFile(this.selectedFile)
          .subscribe(
              response => console.log(response),
              error => console.error(error)
          );
  } else {
      console.error('Nenhum arquivo selecionado');
  }
  }


}
