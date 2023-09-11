import { Component, ViewChild, ElementRef } from '@angular/core';
import { HeaderService } from '../../sharepage/navbar/header.service';

@Component({
  selector: 'app-bloco-notas',
  templateUrl: './bloco-notas.component.html',
  styleUrls: ['./bloco-notas.component.css']
})
export class BlocoNotasComponent {
  text: string = '';
  processedText: string = '';

  highlightLinks() {
    // RegEx para detectar links ou arquivos
    let regex = /(http[s]?:\/\/[^\s]+)|(\.([a-zA-Z]{3,4}))$/;

    // Se o texto final corresponde a um link ou arquivo
    if(regex.test(this.text)) {
        this.text = this.text.replace(regex, '<span style="color: blue;">$&</span>');
    }

    this.processedText = this.text;
}

onKeydown(event: KeyboardEvent): void {
  const target = event.target as HTMLTextAreaElement;
  if (event.key === 'Enter' && target) {
      event.preventDefault();
      const startPosition = target.selectionStart;
      const endPosition = target.selectionEnd;
      const originalValue = target.value;
      target.value = originalValue.substring(0, startPosition)
                          + '\n\n'
                          + originalValue.substring(endPosition);
      target.selectionStart = target.selectionEnd = startPosition + 2;
  }
}
  constructor() { }

  ngOnInit() {
  }

}
