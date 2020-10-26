﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using wsAdventure.Models;

namespace wsAdventure.Controllers
{
    public class SalesOrderDetailsController : ApiController
    {
        private SYKESDBEntities db = new SYKESDBEntities();

        // GET: api/SalesOrderDetails
        public IQueryable<SalesOrderDetail> GetSalesOrderDetail()
        {
            return db.SalesOrderDetail;
        }

        // GET: api/SalesOrderDetails/5
        [ResponseType(typeof(SalesOrderDetail))]
        public IHttpActionResult GetSalesOrderDetail(int id)
        {
            SalesOrderDetail salesOrderDetail = db.SalesOrderDetail.Find(id);
            if (salesOrderDetail == null)
            {
                return NotFound();
            }

            return Ok(salesOrderDetail);
        }

        // PUT: api/SalesOrderDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSalesOrderDetail(int id, SalesOrderDetail salesOrderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != salesOrderDetail.SalesOrderDetailID)
            {
                return BadRequest();
            }

            db.Entry(salesOrderDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesOrderDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
        /*
        // POST: api/SalesOrderDetails
        [ResponseType(typeof(SalesOrderDetail))]
        public IHttpActionResult PostSalesOrderDetail(SalesOrderDetail salesOrderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SalesOrderDetail.Add(salesOrderDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = salesOrderDetail.SalesOrderDetailID }, salesOrderDetail);
        }

        // DELETE: api/SalesOrderDetails/5
        [ResponseType(typeof(SalesOrderDetail))]
        public IHttpActionResult DeleteSalesOrderDetail(int id)
        {
            SalesOrderDetail salesOrderDetail = db.SalesOrderDetail.Find(id);
            if (salesOrderDetail == null)
            {
                return NotFound();
            }

            db.SalesOrderDetail.Remove(salesOrderDetail);
            db.SaveChanges();

            return Ok(salesOrderDetail);
        }
        */
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SalesOrderDetailExists(int id)
        {
            return db.SalesOrderDetail.Count(e => e.SalesOrderDetailID == id) > 0;
        }
    }
}