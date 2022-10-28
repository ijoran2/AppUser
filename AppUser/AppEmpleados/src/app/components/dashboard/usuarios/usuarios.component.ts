import {AfterViewInit, Component, ViewChild,OnInit} from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';
import { Usuario } from 'src/app/Interfaces/usuario';
import { UsuarioService } from 'src/app/Services/usuario.service';



@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})

export class UsuariosComponent implements AfterViewInit,OnInit{
  displayedColumns: string[] = ['id', 'nombre', 'apellidoP', 'apellidoM',"email","telefono","activo","acciones"];
  dataSource: MatTableDataSource<Usuario>;
  usuario:Usuario[]=[];
  @ViewChild(MatPaginator)
  paginator!: MatPaginator;
  @ViewChild(MatSort)
  sort!: MatSort;

  constructor( private serviceUsuario: UsuarioService) {
    // Create 100 users


    // Assign the data to the data source for the table to render
    this.dataSource = new MatTableDataSource(this.usuario);
  }
  ngOnInit(): void {

    this.CargarUsuario();

  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  CargarUsuario(){
        this.serviceUsuario.GetUsuarioAll().subscribe(data=>
          this.dataSource = new MatTableDataSource(data)
        )
        }
  CargarUsuarioporId(usuario:number){
          this.serviceUsuario.GetUsuario(usuario).subscribe(data=>
            this.dataSource = new MatTableDataSource(data)
          )
          }
  ElimarUsuario(usuarioId:number){
    this.serviceUsuario.GetDelete(usuarioId).subscribe(data=>
      this.CargarUsuario()
      )

     }

  ActualizarUsuario(id:number,usuario:Usuario[]){
        this.serviceUsuario.ActualzarUsuario(id,usuario).subscribe(
          )
          this.CargarUsuario();
         }

}


