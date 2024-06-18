import { Component, OnInit, inject} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: ``
})

export class LoginComponent implements OnInit{
  authService = inject(AuthService);
  hide = true;
  form!:FormGroup;
  fb =inject(FormBuilder);
   
  login():void{
    this.authService.login(this.form.value).subscribe((response) =>{
      console.log(response);
    })
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      email:['',Validators.required,Validators.email],
      password:['',Validators.required]
    });    
  }

}
