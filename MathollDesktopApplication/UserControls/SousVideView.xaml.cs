using Auth0.ManagementApi.Models;
using MathollDesktopApplication.Entities;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace MathollDesktopApplication
{
    /// <summary>
    /// Interaction logic for SousVide.xaml
    /// </summary>
    public partial class SousVide : UserControl
    {
        SousVideItem sousVideData;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SousVide"/> class.
        /// </summary>
        public SousVide()
        {
            InitializeComponent();
            PopulateSousVideGrid();
        }

        /// <summary>
        /// Populates the grid with data from the JSON file.
        /// </summary>
        /// <remarks>
        /// I am using a JSON file for this instead of using a database and the API because the main foxus of this project is to get
        /// hands on practice with C# and WPF, so I want to try different things to do things in as many different ways as possible
        /// even if it's not the most efficient way.
        ///
        /// For example I might use the API to get the heattable for the air fryer from API instead of using the JSON file and
        /// possible allowing user to add or manipulate existing data in the database.
        /// </remarks>
        /// <exception cref="FileNotFoundException"></exception>
        public void PopulateSousVideGrid()
        {
            // JSON file is located in root/Assets
            string jsonFileName = "SousVideHitatafla.json";
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", jsonFileName);
            string jsonString;
            try
            {
                if (!File.Exists(jsonFilePath))
                {
                    throw new FileNotFoundException($"File not found: {jsonFilePath}");
                }

                jsonString = File.ReadAllText(jsonFilePath, Encoding.UTF8);
                sousVideData = JsonConvert.DeserializeObject<SousVideItem>(jsonString);
                
                int i = 0;
                
                // TODO: Add something prettier and more functional than a textBlock! This is for testing purposes only to visualize data coming in.
                foreach (var category in sousVideData.Data)
                {   
                    TextBlock textBlock = new()
                    {
                        Text = category.Name,
                        Margin = new Thickness(0, i, 0, 0),
                        FontWeight = FontWeights.Bold
                    };
                    SousVideGrid.Children.Add(textBlock);
                    i += 15;
                }
            }
            catch (JsonException ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
