import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Response } from '../models/response';
import { Cliente } from '../models/cliente';

const httpOption = {
  headers: new HttpHeaders({
    'Contend-Type': 'aplication/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class ApiclienteService {

  url: string = 'https://localhost:7283/api/cliente';

  constructor(
    private _http: HttpClient
  ) { }

  getClientes(): Observable<Response> {
    return this._http.get<Response>(this.url);
  }

  getClienteById(id: number): Observable<Cliente> {
    const url = `${this.url}/${id}`;
    return this._http.get<Cliente>(url);
  }

  add(cliente: Cliente): Observable<Response> {
    return  this._http.post<Response>(this.url, cliente, httpOption);
  }

  edit(cliente: Cliente): Observable<Response> {
    return  this._http.put<Response>(this.url, cliente, httpOption);
  }

  delete(id: number): Observable<Response> {
    return  this._http.delete<Response>(`${this.url}/${id}`);
  }

}
