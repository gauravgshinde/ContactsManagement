using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    public class ContactMastersController : ApiController
    {        
        private IContactRepository<ContactMaster> _contactRepo = null;
        public ContactMastersController()
        {
            this._contactRepo = new ContactRepo<ContactMaster>();
        }
        public ContactMastersController(IContactRepository<ContactMaster> repository)
        {
            this._contactRepo = repository;
        }



        // GET: api/ContactMasters
        public IEnumerable<ContactMaster> GetContactMasters()
        {
            return _contactRepo.GetContacts();
        }


        // GET: api/ContactMasters/5
        [ResponseType(typeof(ContactMaster))]
        public IHttpActionResult GetContactMaster(int id)
        {
            ContactMaster contactMaster = _contactRepo.GetContactbyID(id);

            if (contactMaster == null)
            {
                return NotFound();
            }

            return Ok(contactMaster);
        }

        // PUT: api/ContactMasters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContactMaster(int id, ContactMaster contactMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contactMaster.ContactID)
            {
                return BadRequest();
            }

            try
            {
                _contactRepo.UpdateContact(id, contactMaster);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_contactRepo.ContactExists(id))
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

        // POST: api/ContactMasters
        [ResponseType(typeof(ContactMaster))]
        public IHttpActionResult PostContactMaster(ContactMaster contactMaster)
        {
            _contactRepo.InsertContact(contactMaster);

            return CreatedAtRoute("DefaultApi", new { id = contactMaster.ContactID }, contactMaster);
        }

        // DELETE: api/ContactMasters/5
        [ResponseType(typeof(ContactMaster))]
        public IHttpActionResult DeleteContactMaster(int id)
        {           
            ContactMaster contactMaster = _contactRepo.DeleteContact(id);

            return Ok(contactMaster);
        }      
    }
}