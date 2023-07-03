using System.ComponentModel.DataAnnotations;

namespace Logica.Models
{
    public class Person
    {       
        public int ID { get; set; }
        
        public string Name { get; set; }

        [Display(Name ="Last Name")]        
        public string LastName  { get; set; }        
        public DateTime Birthday { get; set; }

        [Display(Name = "Favorite Color")]        
        public string FavoriteColor { get; set; }
    }
}
