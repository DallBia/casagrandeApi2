
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import{Grid01Component}from '../sharepage/grid01/grid01.component';
import { BehaviorSubject } from 'rxjs';
@Injectable({
    providedIn: 'root'
})
export class FileService {

    private baseUrl = 'https://localhost:7298/api';

    constructor(private http: HttpClient) { }

    uploadFile(file: File) {
        const formData = new FormData();
        // let nome: string = '003.jpg'
        formData.append('file', file, file.name);

        return this.http.post(this.baseUrl + '/Image', formData);
    }

  }
