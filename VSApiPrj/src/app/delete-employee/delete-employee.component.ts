import { Component, OnInit } from '@angular/core';
import {EmployeeServiceService} from '../employee-service.service';
import {Employee} from '../empModel';


@Component({
  selector: 'app-delete-employee',
  templateUrl: './delete-employee.component.html',
  styleUrls: ['./delete-employee.component.css']
})
export class DeleteEmployeeComponent implements OnInit {
  allEmployee:any={};
  constructor(private service:EmployeeServiceService) { }

  ngOnInit() {
  }
  onSubmit(empValue:number)
  {
   // console.log(empValue);
   // let objtempemp:Employee=new Employee(); 
    this.service.GetAllEmployeeById(empValue).subscribe((data:Employee[])=>this.allEmployee=data);
  }
  deleteEmployee(empValue:number)
  {
    this.service.DeleteEmployee(empValue).subscribe();
  }
}
