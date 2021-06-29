import { Injectable, Inject } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import { IBase } from '../models/base';


@Injectable({
  providedIn: 'root'
})
export class BaseHttpService<T extends IBase> {
 
  protected _baseUrl : string = this.url + this.endpoint;

  constructor(protected httpClient: HttpClient, private url: string, protected endpoint: string) {}

  get(): Observable<T[]>{

    return this.httpClient.get<T[]>(this._baseUrl);
  }

  getById(id:number){
    return this.httpClient.get<T>(this._baseUrl + "/" + id);
  }


  create(entity: T): Observable<void>{
    const headers={
      'Accept':'application/json',
      'Content-Type':'application/json',
    }
    return this.httpClient.post<void>(this._baseUrl,entity,{headers});
  }
  
  update(entity:T):Observable<boolean>
  {
    entity.id= + entity.id;
    return this.httpClient.put<boolean>(this._baseUrl + '/' + entity.id, entity );
  }

  delete(entityId: number):Observable<boolean>{
    const headers={
      'Accept':'application/json',
      'Content-Type':'application/json',
    }
    return this.httpClient.delete<boolean>(this._baseUrl + '/' +  entityId,{headers});
  }
}
