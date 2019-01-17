using ApiRegistrationDemo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiRegistrationDemo.Controllers
{
    public class EmployeeController : ApiController
    {
        SqlExecute objSqlExecute = null;
        Employee employee = null;
        List<Employee> employeeList = null;

        // GET: api/Employee
        public List<Employee> GetAllEmployee()
        {
            employeeList = new List<Employee>();
            objSqlExecute = new SqlExecute();
            string sql = "SELECT E.Id, E.Name, E.Address, E.DOB, E.Salary, E.Gender, E.IsMarried, E.CountryId, ";
            sql += " CountryName=(SELECT C.CountryName from Country C where C.Id=E.CountryId),E.RegionId, ";
            sql += " RegionName=(Select RegionName from Region R where R.Id=E.RegionId) FROM Employee E";
            IDataReader reader = objSqlExecute.ExecuteReader(sql);
            while (reader.Read())
            {
                employee = new Employee();
                employee.Id = Convert.ToInt32(reader["Id"]);
                employee.Name = Convert.ToString(reader["Name"]);
                employee.Address = Convert.ToString(reader["Address"]);
                employee.DOB = Convert.ToDateTime(reader["DOB"]);
                employee.Salary = Convert.ToDecimal(reader["Salary"]);
                employee.Gender = Convert.ToString(reader["Gender"]);
                employee.IsMarried = Convert.ToBoolean(reader["IsMarried"]);
                employee.CountryId = Convert.ToInt32(reader["CountryId"]);
                employee.CountryName = Convert.ToString(reader["CountryName"]);
                employee.RegionId = Convert.ToInt32(reader["RegionId"]);
                employee.RegionName = Convert.ToString(reader["RegionName"]);
                employeeList.Add(employee);
            }
            reader.Close();
            return employeeList;
        }

        // GET: api/Employee/5
        [HttpGet]
        public Employee GetEmployeeById(Int32 id)
        {
            objSqlExecute = new SqlExecute();
            employee = new Employee();
            string sql = "SELECT E.Id, E.Name, E.Address, E.DOB, E.Salary, E.Gender, E.IsMarried, E.CountryId, ";
            sql += "CountryName=(SELECT C.CountryName from Country C where C.Id=E.CountryId),E.RegionId, ";
            sql += " RegionName=(Select RegionName from Region R where R.Id=E.RegionId) FROM Employee E where E.Id=" + id + "";
            IDataReader reader = objSqlExecute.ExecuteReader(sql);
            while (reader.Read())
            {
                employee.Id = Convert.ToInt32(reader["Id"]);
                employee.Name = Convert.ToString(reader["Name"]);
                employee.Address = Convert.ToString(reader["Address"]);
                employee.DOB = Convert.ToDateTime(reader["DOB"]);
                employee.Salary = Convert.ToDecimal(reader["Salary"]);
                employee.Gender = Convert.ToString(reader["Gender"]);
                employee.IsMarried = Convert.ToBoolean(reader["IsMarried"]);
                employee.CountryId = Convert.ToInt32(reader["CountryId"]);
                employee.CountryName = Convert.ToString(reader["CountryName"]);
                employee.RegionId = Convert.ToInt32(reader["RegionId"]);
                employee.RegionName = Convert.ToString(reader["RegionName"]);
            }
            reader.Close();
            return employee;
        }

        // POST: api/Employee
        [HttpPost]
        public IHttpActionResult Post(Employee employee)
        {
            objSqlExecute = new SqlExecute();
            Int32 rec = 0;
            if (ModelState.IsValid)
            {
                string sql = "INSERT INTO Employee(Name, Address, DOB, Salary, Gender, IsMarried, CountryId, RegionId) ";
                sql += " VALUES('" + employee.Name + "','" + employee.Address + "','" + Convert.ToDateTime(employee.DOB) + "','" + Convert.ToDecimal(employee.Salary) + "', ";
                sql += " '" + employee.Gender + "','" + Convert.ToBoolean(employee.IsMarried) + "'," + employee.CountryId + "," + employee.RegionId + ")";
                rec = objSqlExecute.ExecuteNonQuery(sql);
            }

            //List<string> name = new List<string>
            //{
            //    "Atanu",
            //    "Bakly"
            //};
            if (rec > 0)
            {
                // return Ok<List<string>>(name);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // PUT: api/Employee/5
        public IHttpActionResult Put(Employee employee)
        {
            objSqlExecute = new SqlExecute();
            Int32 rec = 0;
            if (ModelState.IsValid)
            {
                string sql = "UPDATE Employee SET Name='" + employee.Name + "', ";
                sql += "Address='" + employee.Address + "', ";
                sql += "DOB='" + employee.DOB + "', ";
                sql += "Salary=" + employee.Salary + ", ";
                sql += "Gender='" + employee.Gender + "' ,";
                sql += "IsMarried='" + employee.IsMarried + "', ";
                sql += "CountryId=" + employee.CountryId + " ,";
                sql += "RegionId=" + employee.RegionId + " ";
                sql += "where Id=" + employee.Id + "";
                rec = objSqlExecute.ExecuteNonQuery(sql);
            }
            if (rec > 0)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/Employee/5
        [HttpDelete]
        public bool Delete(Int32 id)
        {
            objSqlExecute = new SqlExecute();
            bool rec = false;
            string sql = "DELETE from Employee where Id=" + id + "";
            Int32 retrn = objSqlExecute.ExecuteNonQuery(sql);
            if (retrn > 0)
            {
                rec = true;
            }
            return rec;
        }
    }
}
