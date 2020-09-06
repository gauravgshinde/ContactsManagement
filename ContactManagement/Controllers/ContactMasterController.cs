using ContactManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ContactManagement.Controllers
{
    public class ContactMasterController : Controller
    {
        // GET: ContactMaster
        public ActionResult Index()
        {
            IEnumerable<mvcContactModel> empList;
            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("ContactMasters").Result; //call webapi method and get response

            if (response.IsSuccessStatusCode)
            {
                empList = response.Content.ReadAsAsync<IEnumerable<mvcContactModel>>().Result; //convert web api result into IEnumerable 
            }
            else
                empList = null;

            return View(empList);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int Id = 0)
        {
            if (Id == 0) //create empty form on create new button
                return View(new mvcContactModel());
            else //create value populated form on edit button click
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("ContactMasters/" + Id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcContactModel>().Result);//convert web api result into mvcEmplModel
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(mvcContactModel contact) //for insert and update
        {
            if (contact.ContactID == 0) //add new record
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.PostAsJsonAsync("ContactMasters", contact).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else //update record
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.PutAsJsonAsync("ContactMasters/" + contact.ContactID, contact).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webApiClient.DeleteAsync("ContactMasters/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";

            return RedirectToAction("Index");

        }

    }
}