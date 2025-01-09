import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Building } from '../models/building.model';

@Injectable({
  providedIn: 'root'
})
export class BuildingService {

  url = 'http://localhost:4200/api/v1/Buildings';

  getall():Observable<Building[]>{
    return this.http.get<Building[]>(this.url);
  }

  get(id:number):Observable<Building>{
    return this.http.get<Building>(this.url+'/getById/'+id);
  }

  constructor(private http:HttpClient) { }
}
