using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auth0.OidcClient;

namespace MathollDesktopApplication.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TimeToCookInMinutes { get; set; }
        public int ForNumberOfPeople { get; set; }
        public DateTime DateAdded { get; set; }
        public string Difficulty { get; set; }
        public string Category { get; set; }
        public string Instructions { get; set; }
        public string BaseImage { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\n Name: {Name}\n TimeToCookInMinutes: {TimeToCookInMinutes}\n ForNumberOfPeople: {ForNumberOfPeople}\n DateAdded: {DateAdded.ToString()}\n Difficulty: {Difficulty}\n Category: {Category}\n Instructiosn: {Instructions}\n BaseImage: {BaseImage}";
        }
    }
}