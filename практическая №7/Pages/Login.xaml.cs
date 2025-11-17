using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Json;
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
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Doctor doctor = new Doctor();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            doctor = (Doctor)Resources["DoctorLogin"];
            string doctorSignIn = $"D_{doctor.ID}.json";
            string doctorJsonString = File.ReadAllText(doctorSignIn);
            var doctorJsonRead = JsonSerializer.Deserialize<Doctor>(doctorJsonString);
            if (doctor.Password == doctorJsonRead.Password)
            {
                doctor.Name = doctorJsonRead.Name;
                doctor.MiddleName = doctorJsonRead.MiddleName;
                doctor.LastName = doctorJsonRead.LastName;
                doctor.Specialisation = doctorJsonRead.Specialisation;
                MessageBox.Show($"Добро пожаловать, {doctor.Name} {doctor.MiddleName}!");
                NavigationService.Navigate(new MainPage(doctor));
            }
            else
            {
                MessageBox.Show("Неверные логин или пароль! Попробуйте еще раз.");
            }
        }

        private void Redistr_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registration());
        }
    }
}
