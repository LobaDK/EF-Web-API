import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Building } from '../models/building.model';

@Injectable({
  providedIn: 'root'
})
export class BuildingService {

  url: string = 'http://localhost:4200/api/v1/Buildings';

  /**
   * Retrieves all buildings from the server.
   *
   * @returns An Observable that emits an array of Building objects.
   */
  getall():Observable<Building[]>{
    return this.http.get<Building[]>(this.url);
  }

  constructor(private http:HttpClient) { }
}
