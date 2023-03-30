using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfAppStorage.Models.Entities
{
    public class Applicances
    {
        
        public int Id { get; set; }

        public string Name { get; set; }

        public TypeApplicances TypeAplicances { get; set; }
        public int TypeAplicancesid { get; set; }

       
        public decimal Price { get; set; }
      
        public int CountApplicances { get; set; }

        public Provider Provider { get; set; }
        public int Providerid { get; set; }

        public SectionsStorage SectionsStorage { get; set; }
        public int SectionsStorageid { get; set; }

        public DateTime AddDate { get; set; }
    }
}
