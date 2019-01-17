import { Injectable } from '@angular/core';
import{HttpClient,HttpHeaders } from '@angular/common/http';
import {Employee} from './empModel';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class EmployeeServiceService {

  constructor(private httpClient:HttpClient) { }

  public GetAllCountry()
  {
    let url="http://localhost/ApiRegistrationDemo/api/Country";
    return this.httpClient.get(url);
  }
  public GetRegionByCountryId(Id:number)
  {
    let url="http://localhost/ApiRegistrationDemo/api/Region?id="+Id;
    return this.httpClient.get(url);
  }

  public GetAllEmployee()
  {
    let url="http://localhost/ApiRegistrationDemo/api/Employee";
    return this.httpClient.get(url);
  }
  public GetAllEmployeeById(Id:number)
  {
    let url="http://localhost/ApiRegistrationDemo/api/Employee?Id="+Id;
    return this.httpClient.get(url);
  }
  public SaveEmployee(empdata:Employee)
  {
    let url="http://localhost/ApiRegistrationDemo/api/Employee";
    return this.httpClient.post(url,empdata,
      {
      headers: new HttpHeaders({
      'Content-Type':'application/json'
      })
      });
  }
  public DeleteEmployee(Id:number)
  {
    let url="http://localhost/ApiRegistrationDemo/api/Employee?id="+Id;
    return this.httpClient.delete(url,{
      headers: new HttpHeaders({
      'Content-Type':'application/json'
      })
      });
  }

  public UpdateEmployee(empdata:Employee)
  {
    let url="http://localhost/ApiRegistrationDemo/api/Employee";
    return this.httpClient.put(url,empdata,
      {
      headers: new HttpHeaders({
      'Content-Type':'application/json'
      })
      });
  }

}
