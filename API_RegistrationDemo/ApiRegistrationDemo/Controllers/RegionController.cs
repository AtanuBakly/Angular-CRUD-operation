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
    public class RegionController : ApiController
    {
        SqlExecute objSqlExecute = null;
        Region region = null;
        List<Region> regionList = null;

        // GET: api/Region
        public List<Region> GetAllRegion()
        {
            regionList = new List<Region>();
            objSqlExecute = new SqlExecute();
            string sql = "SELECT Id, CountryId, RegionName FROM Region";
            IDataReader reader = objSqlExecute.ExecuteReader(sql);
            while (reader.Read())
            {
                region = new Region();
                region.Id = Convert.ToInt32(reader["Id"]);
                region.CountryId = Convert.ToInt32(reader["CountryId"]);
                region.RegionName = Convert.ToString(reader["RegionName"]);
                regionList.Add(region);
            }
            reader.Close();
            return regionList;
        }

        // GET: api/Region/5
        public List<Region> GetRegionById(Int32 id)
        {
            objSqlExecute = new SqlExecute();
            regionList = new List<Region>();
            string sql = "SELECT Id, RegionName FROM Region where CountryId=" + id + "";
            IDataReader reader = objSqlExecute.ExecuteReader(sql);
            while (reader.Read())
            {
                region = new Region();
                region.Id = Convert.ToInt32(reader["Id"]);
               // region.CountryId = Convert.ToInt32(reader["CountryId"]);
                region.RegionName = Convert.ToString(reader["RegionName"]);
                regionList.Add(region);
            }
            reader.Close();
            return regionList;
        }

        // POST: api/Region
        public IHttpActionResult Post(Region region)
        {
            objSqlExecute = new SqlExecute();
            Int32 rec = 0;
            if (ModelState.IsValid)
            {
                string sql = "INSERT INTO Region(CountryId,RegionName)VALUES(" + region.CountryId + ",'" + region.RegionName + "')";
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
        // PUT: api/Region/5
        public IHttpActionResult Put(Region region)
        {
            objSqlExecute = new SqlExecute();
            Int32 rec = 0;
            if (ModelState.IsValid)
            {
                string sql = "UPDATE Region  SET CountryId=" + region.CountryId + ", RegionName='" + region.RegionName + "' where Id=" + region.Id + "";
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

        // DELETE: api/Region/5
        public bool Delete(Int32 id)
        {
            objSqlExecute = new SqlExecute();
            bool rec = false;
            string sql = "DELETE FROM Region where Id=" + id + "";
            Int32 retrn = objSqlExecute.ExecuteNonQuery(sql);
            if (retrn > 0)
            {
                rec = true;
            }
            return rec;
        }
    }
}
