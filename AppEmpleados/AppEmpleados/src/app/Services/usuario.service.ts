import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from '../Interfaces/usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  constructor(private http: HttpClient) { }

GetUsuarioAll():Observable<Usuario[]>{
return this.http.get<Usuario[]>("http://localhost:5090/api/Usuarios");
};

GetUsuario(usuario:number):Observable<Usuario[]>{
return this.http.get<Usuario[]>("http://localhost:5090/api/Usuarios/"+ usuario);
  };

GetDelete(usuario:number):Observable<Usuario[]>{
return this.http.delete<Usuario[]>("http://localhost:5090/api/Usuarios/"+ usuario);
    };

CraerUsuario(usuario:Usuario[]):Observable<any>{
  const headers = { 'content-type': 'application/json'}
  const body=JSON.stringify(usuario);
return this.http.post<Usuario>("http://localhost:5090/api/Usuarios/",body,{'headers':headers});
   };

ActualzarUsuario(id:number, usuario:Usuario[]):Observable<any>{
  const headers = { 'content-type': 'application/json'}
    const body=JSON.stringify(usuario);

return this.http.patch<Usuario[]>("http://localhost:5090/api/Usuarios/" +id,body,{'headers':headers});
   };

}
