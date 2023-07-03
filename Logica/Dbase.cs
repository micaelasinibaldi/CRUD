using Logica.Models;
using Logica.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Logica
{
    public class Dbase : IDataBase
    {
        //prbando
        public List<Person> ListPersons { get; }
        public Dbase()
        {
            ListPersons = new List<Person>();
        }
        public Person FindId(int? id)
        {
            var personToFind = ListPersons.Find(x => x.ID == id);

            if (personToFind == null)
            {
                return null;
            }
            else
            {
                return personToFind;
            }
        }

        public void Create(IFormCollection info)
        {          
            var person = new Person();

            person.ID = ListPersons.Count + 1;
            person.Name = info["Name"];
            person.LastName = info["LastName"];
            person.Birthday = DateTime.Parse(info["Birthday"]);
            person.FavoriteColor = info["FavoriteColor"];               

            ListPersons.Add(person);            
        }
        public void Delete(int id)
        {            
            var personToDelete = ListPersons.Find(x => x.ID == id);

            ListPersons.Remove(personToDelete);                   
        }

        public void Update(IFormCollection info)
        {
            var infoId = Int32.Parse(info["ID"]);
            var personToUpdate = ListPersons.Find(x => x.ID == infoId);

            if (personToUpdate != null)
            {              
                personToUpdate.Name = info["Name"];
                personToUpdate.LastName = info["LastName"];
                personToUpdate.Birthday = DateTime.Parse(info["Birthday"]);
                personToUpdate.FavoriteColor = info["FavoriteColor"];
            }          
        }
        public List<int> Read(IFormCollection info)
        {           
            var listPersonsFounded = new List<Person>();
            var listPersonsFoundedId = new  List<int>();

            if (!String.IsNullOrEmpty(info["ID"]))
            {
                listPersonsFounded = ListPersons.FindAll(x => x.ID == Int32.Parse(info["ID"]));
            }
            else if (!String.IsNullOrEmpty(info["Name"]))
            {
                listPersonsFounded = ListPersons.FindAll(x => x.Name == info["Name"]);                  
            }
            foreach(var person in listPersonsFounded)
            {
                listPersonsFoundedId.Add(person.ID);
            }               
            return listPersonsFoundedId;
        }
    }
}