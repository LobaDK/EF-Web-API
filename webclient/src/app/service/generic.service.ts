import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Endpoints } from '../enum/endpoints';

@Injectable({
  providedIn: 'root'
})
export class GenericService<T> {

  url: string = 'http://localhost:4200/api/v1/';

  getall(endpoint: Endpoints):Observable<T[]>{
    return this.http.get<T[]>(this.url+endpoint)
  }

  constructor(private http:HttpClient) { }
}
