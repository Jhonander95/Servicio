import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Cliente } from 'src/app/models/cliente';
import { ApiclienteService } from 'src/app/services/apicliente.service';



@Component({
  selector: 'app-dialog-cliente-edit',
  templateUrl: './dialog-cliente-edit.component.html',
  styleUrls: ['./dialog-cliente-edit.component.scss']
})
export class DialogClienteEditComponent {

  form: FormGroup;
  formModified = false;

  constructor(
    public apiCliente: ApiclienteService,
    public snackBar: MatSnackBar,
    public dialogRef: MatDialogRef<DialogClienteEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Cliente,
    private fb: FormBuilder
  ) {
    console.log('Esto viene desde el dialog-edit');
    console.log(this.data);

    this.form = this.fb.group({
      id: [this.data?.id, [Validators.required]],
      nombre: [this.data?.nombre, [Validators.required]],
      telefono: [this.data?.telefono, [Validators.required, Validators.maxLength(10)]],
      empresa: [this.data?.empresa]
    });
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

/*   private buildForm() {
    this.form = this.fb.group({
      nombre: [this.data.cliente.nombre, [Validators.required]],
      telefono: [this.data.cliente.telefono, [Validators.required, Validators.maxLength(10)]],
      empresa: [this.data.cliente.empresa]
    });
  } */
/*   close() {
    this.dialogRef.close();
  } */

  editCliente(form: any) {
    const clienteModificado = {
      id: form.id,
      nombre: form.nombre,
      telefono: form.telefono,
      empresa: form.empresa,
    };
    console.log(clienteModificado);
    this.apiCliente.edit(clienteModificado).subscribe(response => {
      if(response.exito === 1){
        this.dialogRef.close();
        this.snackBar.open('Cliente Editado correctamente, Bitch', '',{
          duration: 2000
        });
        console.log(form);
      }
    });
  }
}
