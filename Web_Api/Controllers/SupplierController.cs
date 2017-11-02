using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Web_Api.Models;

namespace Web_Api.Controllers
{
    public class SupplierController : ApiController
    {
        NORTHWNDEntities db = new NORTHWNDEntities();

        public async Task<IHttpActionResult> DataSupplierAll() {


            var data = await db.Suppliers.ToListAsync();

            if (data ==null)
            {
                return NotFound();

            }
            return Ok(data);
        }

        public async Task<IHttpActionResult> DataSupplierById(int id)
        {
            var data = await db.Suppliers.FirstOrDefaultAsync(x => x.SupplierID == id);
            if (data==null)
            {
                return NotFound();
            }
            return Ok(data);




        }


        public async Task<IHttpActionResult> DeleteDataSupplier(int id) {

            var data = await db.Suppliers.FirstOrDefaultAsync(x => x.SupplierID == id);
            if (data==null)
            {
                return NotFound();
            }
            
                db.Suppliers.Remove(data);
                if (db.SaveChanges()>0)
                {
                return Ok();

            }
            else
            {
                return BadRequest();
            }
           
        }

      public async Task<IHttpActionResult> DataSupplierUpdate(Suppliers data)
        {
            if (ModelState.IsValid)
            {
                db.Entry(data).State = EntityState.Modified;
                var result= await db.SaveChangesAsync();
                if (result>0)
                {
                    return Ok("1");

                }
                else
                {
                    return BadRequest("0");
                }
            }
            else
            {
                return BadRequest("0");   
            }
        }




    }
}
