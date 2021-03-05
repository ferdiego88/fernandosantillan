import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Personal } from 'src/models/personal';

@Injectable({
  providedIn: 'root'
})
export class PersonalService {

  myAppUrl = '';

  constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl + 'api/Personal/';
  }

  // getCityList() {
  //   return this._http.get(this.myAppUrl + 'GetCityList')
  //     .pipe(map(
  //       response => {
  //         return response;
  //       }));
  // }

  getPersonal() {
    return this._http.get(this.myAppUrl + 'Index').pipe(map(
      response => {
        return response;
      }));
  }

  getPersonalById(id: number) {
    return this._http.get(this.myAppUrl + 'Details/' + id)
      .pipe(map(
        response => {
          return response;
        }));
  }

  savePersonal(personal: Personal) {
    return this._http.post(this.myAppUrl + 'Crear', personal)
      .pipe(map(
        response => {
          return response;
        }));
  }

  updatePersonal(personal: Personal) {
    return this._http.put(this.myAppUrl + 'Editar', personal)
      .pipe(map(
        response => {
          return response;
        }));
  }

  deletePersonal(id: number) {
    return this._http.delete(this.myAppUrl + 'Borrar/' + id)
      .pipe(map(
        response => {
          return response;
        }));
  }
}
