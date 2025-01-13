import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Building } from '../models/building.model';

@Injectable({
  providedIn: 'root'
})
export class BuildingService {

  url: string = 'http://localhost:4200/api/v1/Buildings';

  getall():Observable<Building[]>{
    return this.http.get<Building[]>(this.url);
  }

  constructor(private http:HttpClient) { }
}
