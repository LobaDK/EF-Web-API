import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Endpoints } from '../enum/endpoints';

@Injectable({
  providedIn: 'root'
})
export class GenericService<T> {

  url: string = 'http://localhost:4200/api/v1/';

  getAll(endpoint: Endpoints):Observable<T[]>{
    return this.http.get<T[]>(this.url+endpoint)
  }

  add(endpoint: Endpoints, data: T):Observable<T>{
    return this.http.post<T>(this.url+endpoint+"/create", data)
  }

  constructor(private http:HttpClient) { }
}
