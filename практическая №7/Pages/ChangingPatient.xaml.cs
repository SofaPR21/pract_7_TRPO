using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace практическая__7
{
    /// <summary>
    /// Логика взаимодействия для ChangingPatient.xaml
    /// </summary>
    public partial class ChangingPatient : Page
    {
        Patient PacientChanging;
        public ChangingPatient(Patient pacientChanging)
        {
            PacientChanging = pacientChanging;
            DataContext = PacientChanging;
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            PacientChanging.ID = PacientChanging.ID;
            string jsonString = JsonSerializer.Serialize(PacientChanging, options);
            File.WriteAllText($"P_{PacientChanging.ID}.json", jsonString);
            MessageBox.Show($"Данные успешно изменены!");
            NavigationService.GoBack();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
