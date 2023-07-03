using Microsoft.AspNetCore.Mvc;
using Logica;
using Logica.Models;

namespace WebApplication3.Controllers
{
    public class PersonController : Controller
    {
        static Dbase Dbase = new Dbase();
        
        public IActionResult Index()
        {
            ViewBag.Dbase = Dbase;
            return View();            
        }
        public IActionResult Details(int id)
        {
           var personDetails = Dbase.FindId(id);
           return View(personDetails);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection info)
        {           
            Dbase.Create(info);
            TempData["AlertMessage"] = info["Name"] + " was created successfully";
            return View();
        }
        public IActionResult Delete(int? id) 
        {
            var personToDelete = Dbase.FindId(id);
            return View(personToDelete);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id) 
        {
           var personToDelete = Dbase.FindId(id);
                       
           if (personToDelete == null)
           {
                TempData["DeleteErrorMessage"] = id + " - this ID is not in the list. It can not be deleted.";               
           }
           else
           {
                TempData["DeleteMessage"] = personToDelete.Name + " was deleted.";
                Dbase.Delete(personToDelete.ID);               
           }
           return View();
        }
        public IActionResult Update(int id)
        {
            var personToUpdate = Dbase.FindId(id);        
            return View(personToUpdate);           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(IFormCollection info)
        {            
            var personToUpdate = Dbase.FindId(Int32.Parse(info["ID"]));         
           
            TempData["UpdateMessage"] = personToUpdate.Name + " was successfully updated.";
            Dbase.Update(info);                           
            return View(personToUpdate);
        }
        public IActionResult Read()
        {
            ViewBag.Dbase = Dbase;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Read(IFormCollection info)
        {           
            var listPersonFoundId = Dbase.Read(info);
                        
            if (listPersonFoundId.Count == 0)
            {
                TempData["ReadErrorMessage"] = "This person is not in the list.";
                return View();
            }           
            else
            {
                var listPersonFound = new List<Person>();
                foreach(var id in listPersonFoundId)
                {
                    listPersonFound.Add(Dbase.FindId(id));
                }
                ViewBag.listPersonToShow = listPersonFound;
                return View();
            }
        }
    }
}
