import { Component, OnInit } from '@angular/core';
import { ApiclienteService } from '../services/apicliente.service';
import { Response } from '../models/response';
import { MatDialog } from '@angular/material/dialog';

import { DialogClienteComponent } from './dialog/dialog-cliente/dialog-cliente.component';
import { Cliente } from '../models/cliente';
import { DialogClienteEditComponent } from './dialog/dialog-cliente-edit/dialog-cliente-edit.component';
import { DialogDeleteComponent } from '../common/dialog-delete/dialog-delete.component';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.scss']
})
export class ClienteComponent implements OnInit {

  readonly width = 500;
  public lst: any[] = [];
  public columnas: string[] = ['id', 'nombre', 'telefono', 'empresa', 'actions'];

  constructor(
    private apiCliente: ApiclienteService,
    public dialog: MatDialog,
    public snackBar: MatSnackBar
  ){

  }

  ngOnInit(): void{
    this.getClientes();
  }

  openAdd() {
    const dialogRef = this.dialog.open(DialogClienteComponent, {
     /*  width: '500' */
      /* width: `${window.innerWidth / 2}px`, */
      /* height: `${window.innerHeight / 2}px` */
    })
    dialogRef.afterClosed().subscribe(result => {
      this.getClientes();
    });
    console.log('algo perra');
  }

  openEdit(cliente: Cliente) {
    if (!cliente) {
      console.log('Cliente no definido');
      return;
    }
    const dialogRef = this.dialog.open(DialogClienteEditComponent, {
      width: `${window.innerWidth / 2}px`,
      data: cliente
    });
    dialogRef.afterClosed().subscribe(result => {
      this.getClientes();
    });
    console.log('este objeto va desde el boton de editar');
    console.log(cliente);
  }

  getClientes(){
    this.apiCliente.getClientes().subscribe(response => {
      this.lst = response.data;
    });
  }

  delete(id: number) {
    const dialogRef = this.dialog.open(DialogDeleteComponent, {
      width: `${window.innerWidth / 2}px`
    });
    dialogRef.afterClosed().subscribe(result => {
      if(result) {
        this.apiCliente.delete(id).subscribe(response => {
          if(response.exito === 1) {
            this.snackBar.open('Cliente eliminado con exito, perra ya va el de la moto', '', {
              duration: 2000
            });
            this.getClientes();
          }
        });
      }
    });
  }

}
