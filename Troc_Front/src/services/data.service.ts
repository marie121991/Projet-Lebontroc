import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, throwError } from 'rxjs';
import { environment } from 'src/environments/environements';

@Injectable({
  providedIn: 'root',
})
export class DataService {
  constructor(private http: HttpClient) {}

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*',
    }),
  };

  //Méthode qui appelle tous les éléments d'une table
  //Le paramètre de la route (ex: /object ou /user) doit lui être passé à l'appel de la méthode
  //http://localhost:5160/route
  //ex : http://localhost:5160/object
  getAll(route: string) {
    return this.http.get(environment.serviceUrl + route, this.httpOptions).pipe(
      catchError((error) => {
        console.log(error);
        return throwError(() => new Error('Error'));
      })
    );
  }

  //Route
  getOne(route: string, id: string) {
    //http://localhost:5160/route/id
    //ex : http://localhost:5160/object/6059a8b6-e94a-4105-8528-1cfe748c95b3
    return this.http
      .get(environment.serviceUrl + route + '/' + id, this.httpOptions)
      .pipe(
        catchError((error) => {
          console.log(error);
          return throwError(() => new Error('Error'));
        })
      );
  }
}
