import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder,Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: ``
})
export class LoginComponent implements OnInit{
      
   constructor(private fb: FormBuilder) {}
   ngOnInit(): void {
     this.CreateLoginForm();
   }

   CreateLoginForm(){
    this.loginform = this.fb.group({
      email:['',Validators.compose([Validators.required,
        Validators.pattern('^[A-Za-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$')])],
      password:['',Validators.compose([Validators.required,
        Validators.pattern('/^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-])/')
      ])]
    })
   }

   get f() { return this.loginform.controls; }
}
