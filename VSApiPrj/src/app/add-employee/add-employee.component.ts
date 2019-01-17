import { Component, OnInit } from '@angular/core';
import {Employee} from '../empModel';
import {EmployeeServiceService} from '../employee-service.service';
import {Country} from '../countryModel';
import {Region} from '../regionModel';
import { from } from 'rxjs';


@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent implements OnInit {
  public employeeData:any = {};
  allEmployee:any={};
  countryList:Country[];
  regionListByCountryId:Region[];
  constructor(private service:EmployeeServiceService) { }

  ngOnInit() {
   // let objtempemp:Employee=new Employee(); 
   this.service.GetAllCountry().subscribe((data:Country[])=>this.countryList=data);
  }
  onChange(cntrId:number)
  {
    //console.log(cntrId);
    //GetStateByCountryId
    this.service.GetRegionByCountryId(cntrId).subscribe((data:Region[])=>this.regionListByCountryId=data);
  }
  addEmployee()
  {
    //console.log(objemp.Name);
    //console.log(this.employeeData);
   // this.employeeData.DOB="1987-05-12";
    //this.employeeData.Salary=1234;

  //  this.employeeData.Qualification="MCA";
   // this.employeeData.CountryId=1;
   // this.employeeData.RegionId=1;

   // this.service.SaveEmployee(this.employeeData).subscribe((data:Employee[])=>this.allEmployee=data);
   //this.service.SaveEmployee(this.employeeData).subscribe();
   this.service.SaveEmployee(this.employeeData).subscribe((data:Employee)=>this.allEmployee=data);
  }

}
