import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { ApiauthService } from "../services/apiauth.service";
import { FormGroup, FormControl, FormBuilder, Validators } from "@angular/forms";
import { Login } from "../models/login";


@Component({
  templateUrl: 'Login.component.html',
  selector: 'app-login',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent implements OnInit {

  form!: FormGroup;

  constructor(public apiauthService: ApiauthService,
    private router: Router,
    private fb: FormBuilder,
  ) {
    if (this.apiauthService.usuarioData) {
      this.router.navigate(['/']);
    }

  }

  ngOnInit() {
    this.buildForm();
  }

  // declare getters for each field
  get email() {
    return this.form?.get('email');
  }

  get password() {
    return this.form?.get('password');
  }


  private buildForm() {
    this.form = this.fb.group({
      email: ['', [Validators.required]],
      password: ['', [Validators.required]]
    });
  }

  login() {
    console.log(this.form.value);

    this.apiauthService.login(this.form.value).subscribe(response => {
      if (response.exito === 1) {
        this.router.navigate(['/']);
      }
    });

  }
}
