import { Component } from '@angular/core';
import { Personal } from 'src/models/personal';
import { PersonalService } from '../services/personal.service';

@Component({
  selector: 'app-fetch-employee',
  templateUrl: './fetch-employee.component.html',
  styleUrls: ['./fetch-employee.component.css']
})
export class FetchEmployeeComponent {

  public personalList: Personal[];

  constructor(private _employeeService: PersonalService) {
    this.getPersonal();
  }

  getPersonal() {
    this._employeeService.getPersonal().subscribe(
      (data: Personal[]) => {this.personalList = data; console.log(data); }
    );
  }

  delete(employeeID) {
    const ans = confirm('Esta seguro de eliminar el personal con Id: ' + employeeID);
    if (ans) {
      this._employeeService.deletePersonal(employeeID).subscribe(() => {
        this.getPersonal();
      }, error => console.error(error));
    }
  }
}
