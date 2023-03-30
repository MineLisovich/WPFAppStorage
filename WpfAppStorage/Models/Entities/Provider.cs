using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WpfAppStorage.Models.Entities
{
    public class Provider
    {
     
        public int Id { get; set; }

      
        public string NameCompany { get; set; }
       
        public string Country { get; set; }
       
        public string City { get; set; }
      
        public string Street { get; set; }
      
        public int NumberHouse { get; set; }
    
        public string PhoneNumber { get; set; }

        public List <Applicances> _ApplicancesList { get; set; }
    }
}
