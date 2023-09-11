import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from 'src/app/models/Clientes';
import { environment } from 'src/environments/environment';
import { Response } from '../../models/Response';
import { BehaviorSubject } from 'rxjs';
import { TableData } from 'src/app/models/Tables/TableData';
import { TabResult } from 'src/app/models/Tables/TabResult';


@Injectable({
  providedIn: 'root'
})
export class PerfilService {

  constructor() { }
}
