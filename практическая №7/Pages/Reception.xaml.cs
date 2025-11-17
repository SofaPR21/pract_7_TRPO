using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using практическая__7.Class;

namespace практическая__7
{
    /// <summary>
    /// Логика взаимодействия для Reception.xaml
    /// </summary>
    public partial class Reception : Page
    {
        public Doctor doctor { get; set; }
        public Patient patient { get; set; }
        public ObservableCollection<Patient> allPatients { get; set; }
        public AppointmentStories newAppointmentStories { get; set; } = new AppointmentStories();
        public Patient? SelectedPatient { get; set; }

        public Reception(Doctor DoctorInfo, Patient SelectedPacient, ObservableCollection<Patient> patients)
        {
            InitializeComponent();
            patient = SelectedPacient;
            doctor = DoctorInfo;
            allPatients = patients;
            DataContext = this;
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChangingPatient(SelectedPatient));
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            patient.AppointmentStories.Add(new AppointmentStories
            {
                LastAppointment = newAppointmentStories.LastAppointment,
                LastDoctor = doctor.ID,
                Diagnosis = newAppointmentStories.Diagnosis,
                Recomendations = newAppointmentStories.Recomendations
            });

            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string fileName = $"P_{patient.ID}.json";
            patient.Diagnosis = newAppointmentStories.Diagnosis;

            string jsonString = JsonSerializer.Serialize(patient, options);
            File.WriteAllText(fileName, jsonString);

            var index = allPatients.IndexOf(patient);
            if (index >= 0)
            {
                allPatients[index] = patient;
            }

            newAppointmentStories = new AppointmentStories
            {
                LastAppointment = DateTime.Now.ToString("dd.MM.yyyy"),
                LastDoctor = doctor.ID
            };
            OnPropertyChanged(nameof(newAppointmentStories));

            MessageBox.Show("Прием успешно сохранен!");
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

