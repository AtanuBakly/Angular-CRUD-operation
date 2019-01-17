using ApiRegistrationDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;

namespace ApiRegistrationDemo.Controllers
{
    public class CountryController : ApiController
    {
        SqlExecute objSqlExecute = null;
        Country country = null;
        List<Country> countryList = null;

        // GET: api/Country
        [HttpGet]
        public List<Country> GetAllCountry()
        {
            countryList = new List<Country>();
            objSqlExecute = new SqlExecute();
            string sql = "SELECT Id, CountryName from Country";
            IDataReader reader = objSqlExecute.ExecuteReader(sql);
            while (reader.Read())
            {
                country = new Country();
                country.Id = Convert.ToInt32(reader["Id"]);
                country.CountryName = Convert.ToString(reader["CountryName"]);
                countryList.Add(country);
            }
            reader.Close();
            return countryList;
        }

        // GET: api/Country/5
        public Country GetCountryById(Int32 id)
        {
            objSqlExecute = new SqlExecute();
            country = new Country();
            string sql = "SELECT Id, CountryName from Country where Id=" + id + "";
            IDataReader reader = objSqlExecute.ExecuteReader(sql);
            while (reader.Read())
            {
                country.Id = Convert.ToInt32(reader["Id"]);
                country.CountryName = Convert.ToString(reader["CountryName"]);
            }
            reader.Close();
            return country;
        }

        // POST: api/Country
        public IHttpActionResult Post(Country country)
        {
            objSqlExecute = new SqlExecute();
            Int32 rec = 0;
            if (ModelState.IsValid)
            {
                string sql = "INSERT INTO Country(CountryName)VALUES('" + country.CountryName + "')";
                rec = objSqlExecute.ExecuteNonQuery(sql);
                if (rec > 0)
                {
                    return this.Content(HttpStatusCode.OK, "Record Insert Successfully!");
                }
                else
                {
                    return this.Content(HttpStatusCode.NotFound, "Record Insert Error!");
                }
            }
            else
            {
                var errorMessage = string.Join("<br/>", ModelState.Values.Where(v => v.Errors.Count > 0).SelectMany(v => v.Errors));
                //var errors = ModelState.Values.SelectMany(v => v.Errors);
                //string _Errors = "";
                //foreach (var a in errors)
                //{
                //    if (a.ErrorMessage.Trim() != "")
                //    {
                //        if (_Errors.Trim() != "")
                //        {
                //            Errors = Errors + ",  ";
                //        }
                //        Errors = Errors + "*" + a.ErrorMessage;
                //    }
                //    else
                //    {
                //        Errors = Errors + a.Exception.InnerException.Message;
                //    }
                //}

                return this.Content(HttpStatusCode.BadRequest, errorMessage);
            }
        }

        // PUT: api/Country/5
        public IHttpActionResult Put(Country country)
        {
            objSqlExecute = new SqlExecute();
            Int32 rec = 0;
            if (ModelState.IsValid)
            {
                string sql = "UPDATE Country SET CountryName='" + country.CountryName + "' where Id=" + country.Id + "";
                rec = objSqlExecute.ExecuteNonQuery(sql);

                if (rec > 0)
                {
                    return this.Content(HttpStatusCode.OK, "Record Update Successfully!");
                }
                else
                {
                    return this.Content(HttpStatusCode.NotFound, "Record Update Error!");
                }
            }
            else
            {
                var errorMessage = string.Join("<br/>", ModelState.Values.Where(v => v.Errors.Count > 0).SelectMany(v => v.Errors));
                return this.Content(HttpStatusCode.BadRequest, errorMessage);
            }
        }

        // DELETE: api/Country/5
        public bool Delete(Int32 id)
        {
            objSqlExecute = new SqlExecute();
            bool rec = false;
            string sql = "DELETE from Country where Id=" + id + "";
            Int32 retrn = objSqlExecute.ExecuteNonQuery(sql);
            if (retrn > 0)
            {
                rec = true;
            }
            return rec;
        }
    }
}
