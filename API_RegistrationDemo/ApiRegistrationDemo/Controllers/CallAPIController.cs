using ApiRegistrationDemo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace ApiRegistrationDemo.Controllers
{
    public class CallAPIController : ApiController
    {
        [HttpGet]
        public List<Country> GetCountryAPI()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost/ApiRegistrationDemo/api/Country");
                request.Method = "GET";
                request.ContentType = "application/json";
                string response;
                List<Country> countryList = new List<Country>();
                using (HttpWebResponse res = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream streamr = res.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(streamr))
                        {
                            response = reader.ReadToEnd();
                            countryList = (new System.Web.Script.Serialization.JavaScriptSerializer()).Deserialize<List<Country>>(response);
                        }
                    }
                }
                return countryList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public Country GetCountryAPIById(int Id)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost/ApiRegistrationDemo/api/Country?Id="+Id);
                request.Method = "GET";
                request.ContentType = "application/json";
                string response;
                Country country = new Country();
                using (HttpWebResponse res = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream streamr = res.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(streamr))
                        {
                            response = reader.ReadToEnd();
                            country = (new System.Web.Script.Serialization.JavaScriptSerializer()).Deserialize<Country>(response);
                        }
                    }
                }
                return country;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public string Post(Country country)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost/ApiRegistrationDemo/api/Country");
                request.Method = "POST";
                request.ContentType = "application/json";

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(JsonConvert.SerializeObject(country));
                    streamWriter.Flush();
                }
                string response = string.Empty;
                using (HttpWebResponse res = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream streamr = res.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(streamr))
                        {
                            response = reader.ReadToEnd();
                        }
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        [HttpPut]
        public string Put(Country country)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost/ApiRegistrationDemo/api/Country");
                request.Method = "PUT";
                request.ContentType = "application/json";

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(JsonConvert.SerializeObject(country));
                    streamWriter.Flush();
                }
                string response = string.Empty;
                using (HttpWebResponse res = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream streamr = res.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(streamr))
                        {
                            response = reader.ReadToEnd();
                        }
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpDelete]
        public string Delete(int Id)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost/ApiRegistrationDemo/api/Country?Id="+ Id);
                request.Method = "DELETE";
                request.ContentType = "application/json";

                string response = string.Empty;
                using (HttpWebResponse res = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream streamr = res.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(streamr))
                        {
                            response = reader.ReadToEnd();
                        }
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
