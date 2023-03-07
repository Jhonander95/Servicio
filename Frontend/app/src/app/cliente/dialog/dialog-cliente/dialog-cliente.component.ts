import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Cliente } from 'src/app/models/cliente';
import { ApiclienteService } from 'src/app/services/apicliente.service';

@Component({
  selector: 'app-dialog-cliente',
  templateUrl: './dialog-cliente.component.html',
  styleUrls: ['./dialog-cliente.component.scss']
})
export class DialogClienteComponent {

  form!: FormGroup;
  validationMessages: any;


  constructor(
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<DialogClienteComponent>,
    public apiCliente: ApiclienteService,
    public snackBar: MatSnackBar,
/*     @Inject(MAT_DIALOG_DATA) public cliente: Cliente */
  ){
    this.buildForm();
 /*    if(this.cliente !== null) {
      this.form = cliente;
    } */
  }

  // declare getters for each field
  get nombre() {
    return this.form?.get('nombre');
  }

  get telefono() {
    return this.form?.get('telefono');
  }

  get empresa() {
    return this.form?.get('empresa');
  }

  private buildForm() {
    this.form = this.fb.group({
      nombre: ['', [Validators.required]],
      telefono: ['', [Validators.required, Validators.maxLength(10)]],
      empresa: ['']
    });
  }

  close() {
    this.dialogRef.close();
  }

  addCliente(form: any) {
    const cliente: Cliente = {
      nombre: this.form.value.nombre,
      telefono: this.form.value.telefono,
      empresa: this.form.value.empresa
    }
    this.apiCliente.add(cliente).subscribe(response => {
      if(response.exito === 1){
        this.dialogRef.close();
        this.snackBar.open('Cliente insertado correctamente, Bitch', '',{
          duration: 2000
        });
        console.log(cliente);
      }
    });
  }


}
