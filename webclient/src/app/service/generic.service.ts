import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Endpoints } from '../enum/endpoints';

@Injectable({
  providedIn: 'root'
})
/**
 * A generic service class for performing CRUD operations on entities of type `T`.
 *
 * @template T - The type of the entity that this service will handle.
 */
export class GenericService<T> {

  url: string = 'http://localhost:4200/api/v1/';

  /**
   * Retrieves an entity of type `T` from the specified endpoint by its ID.
   *
   * @param endpoint - The endpoint to send the GET request to.
   * @param id - The ID of the entity to retrieve.
   * @returns An `Observable` of type `T` containing the retrieved entity.
   */
  get(endpoint: Endpoints, id: number):Observable<T>{
    return this.http.get<T>(this.url+endpoint+"/getById/"+id)
  }

  /**
   * Retrieves all entities of type `T` from the specified endpoint.
   *
   * @param endpoint - The endpoint to send the GET request to.
   * @returns An `Observable` of type `T[]` containing all entities from the endpoint.
   */
  getAll(endpoint: Endpoints):Observable<T[]>{
    return this.http.get<T[]>(this.url+endpoint)
  }


  /**
   * Adds a new resource to the specified endpoint.
   * 
   * This method sends a POST request to the given endpoint with the provided data.
   * The data is converted to `FormData` format before being sent.
   * 
   * @template T - The type of the response expected from the server.
   * @param {Endpoints} endpoint - The endpoint to which the resource should be added.
   * @param {Record<string, any>} data - The data to be sent to the server.
   * @returns {Observable<T>} An observable of the response from the server.
   */
  add(endpoint: Endpoints, data: Record<string, any>):Observable<T>{
    let formData = new FormData();
    Object.keys(data).forEach(key => {
      formData.append(key, data[key]);
    });
    return this.http.post<T>(this.url+endpoint+"/create", formData)
  }

  /**
   * Delete a record from the given endpoint.
   * 
   * @param endpoint The endpoint to delete data from.
   * @param id The id of the record to be updated.
   * @returns {Observable<T>} An observable of the data deleted from the endpoint.
   */
  delete(endpoint: Endpoints, id: number):Observable<T>{
    return this.http.delete<T>(this.url+endpoint+"/delete/"+id)
  }

  
  /**
   * Updates a resource at the specified endpoint with the given data.
   * 
   * @template T The type of the response expected from the server.
   * @param {Endpoints} endpoint - The endpoint to which the update request is sent.
   * @param {number} id - The ID of the resource to be updated.
   * @param {Record<string, any>} data - The data to update the resource with.
   * @returns {Observable<T>} An observable of the response from the server.
   */
  update(endpoint: Endpoints, id: number, data: Record<string, any>):Observable<T>{
    let formData = new FormData();
    Object.keys(data).forEach(key => {
      formData.append(key, data[key]);
    });
    return this.http.patch<T>(this.url+endpoint+"/update/"+id, formData)
  }

  /**
   * Sends a request to buy an item for a user.
   *
   * @param {Endpoints} endpoint - The API endpoint to send the request to.
   * @param {number} itemId - The ID of the item to be purchased.
   * @param {number} userId - The ID of the user making the purchase.
   * @returns {Observable<T>} - An observable containing the response from the server.
   */
  buy(endpoint: Endpoints, itemId: number, userId: number):Observable<T>{
    let formData = new FormData();
    formData.append("characterId", String(userId));
    return this.http.post<T>(this.url.concat(endpoint, "/buy/", String(itemId)), formData)
  }

  constructor(private http:HttpClient) { }
}
