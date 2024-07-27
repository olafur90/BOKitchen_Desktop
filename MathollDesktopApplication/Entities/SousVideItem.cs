using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathollDesktopApplication.Entities
{
    public class SousVideItem
    {
        public string Name { get; set; }
        public List<TemperatureItem> Data { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}\nData: {Data}";
        }
    }

    public class TemperatureItem
    {
        public string Name { get; set; }
        public List<Temperatures> Temperatures { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}\nTemperatures: {Temperatures}";
        }
    }

    public class Temperatures 
    {
        public string Label { get; set; }
        public string Thickness { get; set; }
        public string Celsius { get; set; }
        public string Minimum { get; set; }
        public string Medium { get; set; }
        public string Maximum { get; set; }

        public override string ToString()
        {
            return $"Label: {Label}\nThickness: {Thickness}\nCelsius: {Celsius}\nMinimum: {Minimum}\nMedium: {Medium}\nMaximum: {Maximum}";
        }
    }
}
