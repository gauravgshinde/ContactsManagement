using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public interface IContactRepository<T> where T : class
    {
        void InsertContact(T contact); //C
        IEnumerable<T> GetContacts(); //R
        T GetContactbyID(object custId); //R        
        void UpdateContact(object contactId, T contact); //U
        T DeleteContact(object custId); //D
        void Save();
        bool ContactExists(object contactId);
    }
}
