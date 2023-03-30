using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppStorage.Models.Entities
{
    public class TypeApplicances
    {
        public int Id { get; set; }
        public string NameType { get; set; }

        public List<Applicances> _ApplicancesList { get; set; }
    }
}
