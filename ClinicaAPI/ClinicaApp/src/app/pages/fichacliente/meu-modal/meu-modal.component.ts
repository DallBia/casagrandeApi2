import { Component } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
@Component({
  selector: 'app-meu-modal',
  templateUrl: './meu-modal.component.html',
  styleUrls: ['./meu-modal.component.css'],
})
export class MeuModalComponent {

  constructor(
    public dialogRef: MatDialogRef<MeuModalComponent>
  ) {}

  fechar() {
    this.dialogRef.close();
  }

  voltar() {
    this.dialogRef.close(); // Isso fecha o modal.
  }
}