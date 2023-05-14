using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL04EFCodeFirst
{
    internal class Coach
    {
        public int Id { get; set; }  
        public string Name { get; set; } 

        public string ExperienceDescription { get; set; } 

        public DateTime DateOfEmployment { get; set; } 

        public double Height { get; set; }

    }
}
