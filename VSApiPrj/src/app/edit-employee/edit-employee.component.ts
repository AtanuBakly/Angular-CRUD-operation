import { Component, OnInit } from '@angular/core';
import {Employee} from '../empModel';
import {EmployeeServiceService} from '../employee-service.service';
import {Country} from '../countryModel';
import {Region} from '../regionModel';
import { from } from 'rxjs';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.css']
})
export class EditEmployeeComponent implements OnInit {
  public employeeData:any = {};
  allEmployee:any={};
  countryList:Country[];
  regionListByCountryId:Region[];
  constructor(private service:EmployeeServiceService) { }

  ngOnInit() {
    
  }
  onChange(cntrId:number)
  {
    this.service.GetRegionByCountryId(cntrId).subscribe((data:Region[])=>this.regionListByCountryId=data);
  }
  onSearch(empValue:number)
  {
    //this.service.GetAllEmployeeById(empValue).subscribe((data:Employee[])=>this.employeeData=data);
    this.service.GetAllEmployeeById(empValue).subscribe((data:Employee[]) => {
      this.employeeData = data;
     // console.log(this.employeeData);
      this.service.GetAllCountry().subscribe((data:Country[])=>this.countryList=data);
      this.service.GetRegionByCountryId(this.employeeData.CountryId).subscribe((data:Region[])=>this.regionListByCountryId=data);
    });
  }
  UpdateEmployee(allEmployee:Employee)
  {
   //console.log(allEmployee);
    this.service.UpdateEmployee(this.employeeData).subscribe((data:Employee)=>this.allEmployee=data);
  }
}
