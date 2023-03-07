import { Component, OnInit } from '@angular/core';
import { ApiclienteService } from '../services/apicliente.service';
import { Response } from '../models/response';
import { MatDialog } from '@angular/material/dialog';

import { DialogClienteComponent } from './dialog/dialog-cliente/dialog-cliente.component';
import { Cliente } from '../models/cliente';

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
    public dialog: MatDialog
  ){

  }

  ngOnInit(): void{
    this.getClientes();
  }

  openAdd() {
    const dialogRef = this.dialog.open(DialogClienteComponent, {
     /*  width: '500' */
      width: `${window.innerWidth / 2}px`,
      /* height: `${window.innerHeight / 2}px` */
    })
    dialogRef.afterClosed().subscribe(result => {
      this.getClientes();
    });
    console.log('algo perra');
  }

  openEdit(cliente: Cliente) {
    const dialogRef = this.dialog.open(DialogClienteComponent, {
      width: `${window.innerWidth / 2}px`,
      height: `${window.innerHeight / 2}px`,
      data: cliente
    })
    dialogRef.afterClosed().subscribe(result => {
      this.getClientes();
    });
    console.log('algo perra');
  }

  getClientes(){
    this.apiCliente.getClientes().subscribe(response => {
      this.lst = response.data;
    });
  }

}
