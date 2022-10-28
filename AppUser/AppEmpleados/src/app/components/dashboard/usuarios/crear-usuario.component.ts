import { Component, OnInit } from '@angular/core';
import { FormControl,FormGroup,ReactiveFormsModule, RequiredValidator } from "@angular/forms";
import { Usuario } from 'src/app/Interfaces/usuario';
import { UsuarioService } from 'src/app/Services/usuario.service';

@Component({
  selector: 'app-crear-usuario',
  templateUrl: './crear-usuario.component.html',
  styleUrls: ['./crear-usuario.component.css']
})
export class CrearUsuarioComponent implements OnInit {
usuario:Usuario[]=[]
nombreIn:string="";

  userForm = new FormGroup({
    nombre: new FormControl(),
    apellidoP: new FormControl(),
    apellidoM: new FormControl(),
    telefono: new FormControl(),
    email: new FormControl(),
    activo: new FormControl()
});

  constructor( private serviceUsuario: UsuarioService ) {

  }


  ngOnInit(): void {
  }

  onFormSubmit(): void {


  this.usuario = [{Id:0, "Nombre":this.userForm.get("nombre")?.value,"ApellidoP": this.userForm.get("apellidoP")?.value,"ApellidoM":this.userForm.get("apellidoM")?.value,"Telefono":this.userForm.get("telefono")?.value,"Email":this.userForm.get("email")?.value,"Activo":this.userForm.get("activo")?.value}]
  console.log(this.usuario)

  this.CrearUsuario(this.usuario);
}



CrearUsuario(usuario:Usuario[]){
  this.serviceUsuario.CraerUsuario(usuario).subscribe(data=>(
      this.usuario=data
  )
    )
   }

}
