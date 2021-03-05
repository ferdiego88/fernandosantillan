import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PersonalService } from '../services/personal.service';
import { City } from 'src/models/city';
import { Personal } from 'src/models/personal';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent implements OnInit {

  personalForm: FormGroup;
  title = 'Crear';
  IdPersonal: number;
  errorMessage: any;
  cityList: City[];

  constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
    private _employeeService: PersonalService, private _router: Router) {
    if (this._avRoute.snapshot.params['id']) {
      this.IdPersonal = this._avRoute.snapshot.params['id'];
    }

    this.personalForm = this._fb.group({
      idPersonal: 0,
      apPaterno: ['', [Validators.required]],
      apMaterno: ['', [Validators.required]],
      nombre1: ['', [Validators.required]],
      nombre2: [''],
      nombreCompleto: [''],
      fchNac: ['', [Validators.required]],
      fchIngreso: ['', [Validators.required]],
    });
  }

  ngOnInit() {
    // this._employeeService.getCityList().subscribe(
    //   (data: City[]) => this.cityList = data
    // );

    if (this.IdPersonal > 0) {
      this.title = 'Editar';
      this._employeeService.getPersonalById(this.IdPersonal)
        .subscribe((response: Personal) => {
          this.personalForm.setValue(response); console.log(response);
        }, error => console.error(error));
    }
  }

  save() {

    if (!this.personalForm.valid) {
      console.log('Formulario no valido');
      return;
    }

    if (this.title === 'Crear') {
      console.log(this.personalForm.value);
      this._employeeService.savePersonal(this.personalForm.value)
        .subscribe(() => {
          this._router.navigate(['/fetch-employee']);
        }, error => console.error(error));
    } else if (this.title === 'Editar') {
      console.log(this.personalForm.value);
      this._employeeService.updatePersonal(this.personalForm.value)
        .subscribe(() => {
          this._router.navigate(['/fetch-employee']);
        }, error => console.error(error));
    }
  }

  cancel() {
    this._router.navigate(['/fetch-employee']);
  }


  get nombre1() { return this.personalForm.get('nombre1'); }
  get nombre2() { return this.personalForm.get('nombre2'); }
  get apPaterno() { return this.personalForm.get('apPaterno'); }
  get apMaterno() { return this.personalForm.get('apMaterno'); }
  get fchNac() { return this.personalForm.get('fchNac'); }
  get fchIngreso() { return this.personalForm.get('fchIngreso'); }
}
