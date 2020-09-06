using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Unity;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class ContactRepo<T> : IContactRepository<T> where T : class
    {
        [Dependency]
        private DBModel _context = null;
        private DbSet<T> table = null;

        public ContactRepo()
        {
            this._context = new DBModel();
            table = _context.Set<T>();
        }

        public IEnumerable<T> GetContacts()
        {
            return table.ToList();
        }

        public T GetContactbyID(object contactId)
        {
            return table.Find(contactId);
        }

        public void InsertContact(T contact)
        {
            table.Add(contact);
            Save();
        }

        public void UpdateContact(object contactId, T contact)
        {
            _context.Entry(contact).State = EntityState.Modified;
            Save();
        }

        public T DeleteContact(object contactId)
        {
            var contact = table.Find(contactId);
            if (contact != null)
            {
                table.Remove(contact);
                Save();
            }
            return contact;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool ContactExists(object contactId)
        {
            return _context.ContactMasters.Count(e => e.ContactID == Convert.ToInt32( contactId)) > 0;
        }
    }
}