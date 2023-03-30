using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfAppStorage.Models.Entities
{
    public class SectionsStorage
    {
        
        public int Id { get; set; }

        
        public string NameSections { get; set; }

        public List<Applicances> _ApplicancesList { get; set; }
    }
}
