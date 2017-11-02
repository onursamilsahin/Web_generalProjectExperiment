using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Web_Api.Models;

namespace Web_Api.Controllers
{
    public class ValuesController : ApiController
    {
        NORTHWNDEntities db = new NORTHWNDEntities();
        static List<string> degerler = new List<string>() {
            "deger1","deger2","deger3"

        };

         
        // GET api/values
     
        [HttpGet]
        public IEnumerable<string> Degerler()
        {


            return degerler ;
        }
        [HttpGet]
        public IEnumerable<Employees> VeriGetir()
        {
            db.Configuration.ProxyCreationEnabled = false;


            return db.Employees.ToList();
        }
        public HttpResponseMessage VeriEkle(Employees Data)
        {


            db.Employees.Add(Data);
            try
            {
                if (db.SaveChanges() > 0)
                {
                    HttpResponseMessage message = Request.CreateResponse(HttpStatusCode.Created, Data);
                    message.Headers.Location = new Uri(Request.RequestUri + "/" + Data.EmployeeID);
                    return message;


                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Veri ekleme işlemi yapılmadı.");
                }
            }
            catch (Exception ex )
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }



            
        }
        public HttpResponseMessage VeriGuncelle(Employees Data) {


            try
            {
                Employees emp = db.Employees.FirstOrDefault(x => x.EmployeeID == Data.EmployeeID);

               
                if (emp==null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Employee ID:" + Data.EmployeeID);

                }
                else
                {
                     emp.FirstName = Data.FirstName;
                    emp.LastName = Data.LastName;
                    emp.Title = Data.Title;
                    if (db.SaveChanges() > 0)
                    {

                        return Request.CreateResponse(HttpStatusCode.OK, Data);

                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Güncelleme yapılamadı...");
                    }

                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }



        }
        [HttpGet]
        public IHttpActionResult DataById(int id) {

            var data = db.Employees.FirstOrDefault(x => x.EmployeeID == id);
            if (data==null)
            {
                return NotFound();
            }
            return Ok(data);


        }
        [HttpGet]
        public async Task <IHttpActionResult> DeleteById(int id)
        {

            var   data = await db.Employees.FirstOrDefaultAsync(x => x.EmployeeID == id);
            if (data == null)
            {
                return NotFound();
            }
            db.Employees.Remove(data);
            if (db.SaveChanges() > 0)
            {
                return Ok(id);

            }
            else
            {
                return BadRequest("0");
            }






        }


        // GET api/values/5
        [HttpGet]
        public string DegerGetir(int id)
        {
            return degerler[id];
        }
        [HttpPost]
        // POST api/values
        public void DegerEkle([FromBody]string value)
        {
            degerler.Add(value);
        }
        [HttpPut]
        // PUT api/values/5
        public void DegerGuncelle(int id, [FromBody]string value)
        {
            degerler[id] = value;
        }
        [HttpDelete]
        // DELETE api/values/5
        public void DegerSil(int id)
        {
            degerler.RemoveAt(id);
        }
    }
}
