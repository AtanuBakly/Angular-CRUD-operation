using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiRegistrationDemo.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
//private int DMSDocumentUpload(string uploadURL, DocumentUploadModel documentUpload)
//{
//    try
//    {
//        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uploadURL);
//        request.Method = "POST";
//        request.ContentType = "application/json";
//        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
//        {
//            streamWriter.Write(JsonConvert.SerializeObject(documentUpload));
//            streamWriter.Flush();
//        }
//        string response = string.Empty;
//        using (HttpWebResponse res = (HttpWebResponse)request.GetResponse())
//        using (Stream streamr = res.GetResponseStream())
//        using (StreamReader reader = new StreamReader(streamr))
//        {
//            response = reader.ReadToEnd();
//        }
//        return Convert.ToInt32(response);
//    }
//    catch (Exception ex)
//    {
//        throw ex;
//    }
//}
//private object GetUploadDocuments(string uploadURL, List documentIds)
//{
//    try
//    {
//        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uploadURL);
//        request.Method = "POST";
//        request.ContentType = "application/json";
//        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
//        {
//            streamWriter.Write(JsonConvert.SerializeObject(documentIds));
//            streamWriter.Flush();
//        }
//        object response;
//        using (HttpWebResponse res = (HttpWebResponse)request.GetResponse())
//        using (Stream streamr = res.GetResponseStream())
//        using (StreamReader reader = new StreamReader(streamr))
//        {
//            response = reader.ReadToEnd();
//        } return response;
//    }
//    catch (Exception ex)
//    {
//        throw ex;
//    }
//}