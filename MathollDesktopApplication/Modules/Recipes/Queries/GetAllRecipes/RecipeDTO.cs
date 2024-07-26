using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathollDesktopApplication
{
    public class RecipeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }

        public override string ToString()
        {
            return $"Id: {Id},\n Name: {Name},\n DateAdded: {DateAdded}";
        }
    }
}
