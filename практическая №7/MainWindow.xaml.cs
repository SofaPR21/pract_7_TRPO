using System.Numerics;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace практическая__7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool authorization = false;

        public Doctor doctorReg = new Doctor();

        public Doctor doctorLogin = new Doctor();

        public Patient patient = new Patient();

        public Patient patientSear = new Patient();

        public Patient patientReception = new Patient();

        public Patient patientAdmission = new Patient();

        public FileCount fileCount = new FileCount();
        public MainWindow()
        {
            InitializeComponent();
            InfoCountFile();
        }

        void InfoCountFile()
        {
            fileCount = (FileCount)Resources["UsersCount"];
            int doctorCount = Directory.GetFiles(".", "D_*.json").Length;
            int patientCount = Directory.GetFiles(".", "P_*.json").Length;
            fileCount.DoctorCount = doctorCount;
            fileCount.PatientCount = patientCount;
        }

        private void Registr_Click(object sender, RoutedEventArgs e)
        {
            doctorReg = (Doctor)Resources["DoctorReg"];
            Random rnd = new Random();
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            doctorReg.ID = rnd.Next(10000, 100000);
            doctorReg.login = true;
            string jsonString = JsonSerializer.Serialize(doctorReg, options);

            File.WriteAllText($"D_{doctorReg.ID}.json", jsonString);

            MessageBox.Show($"Регистрация успешна.\nID:{doctorReg.ID}");
            Clipboard.SetText(doctorReg.ID.ToString());
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            doctorLogin = (Doctor)Resources["DoctorLogin"];
            string doctorSignIn = $"D_{doctorLogin.ID}.json";
            string doctorJsonString = File.ReadAllText(doctorSignIn);
            var doctorJsonRead = JsonSerializer.Deserialize<Doctor>(doctorJsonString);
            if (doctorLogin.Password == doctorJsonRead.Password)
            {
                doctorLogin.Name = doctorJsonRead.Name;
                doctorLogin.LastName = doctorJsonRead.LastName;
                doctorLogin.MiddleName = doctorJsonRead.MiddleName;
                doctorLogin.Specialisation = doctorJsonRead.Specialisation;
                MessageBox.Show($"Добро пожаловать, {doctorLogin.Name} {doctorLogin.LastName}.");
                authorization = true;
            }
            else
            {
                MessageBox.Show("Неверный идентификатор или пароль, попробуйте еще раз!");
            }
        }

        private void RegistrPatient_Click(object sender, RoutedEventArgs e)
        {
            patient = (Patient)Resources["PatientLogin"];
            Random rnd = new Random();
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            patient.ID = rnd.Next(10000, 100000);
            string jsonString = JsonSerializer.Serialize(patient, options);

            File.WriteAllText($"P_{patient.ID}.json", jsonString);

            MessageBox.Show($"Регистрация успешна.\nВаш ID:{patient.ID}");
            Clipboard.SetText(patient.ID.ToString());
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            patientSear = (Patient)Resources["PatientSearch"];
            string patientSignIn = $"P_{patientSear.ID}.json";
            string patientJsonString = File.ReadAllText(patientSignIn);
            var patientJsonRead = JsonSerializer.Deserialize<Patient>(patientJsonString);
            if (patientSear.ID == patientJsonRead.ID)
            {
                patientSear.Name = patientJsonRead.Name;
                patientSear.LastName = patientJsonRead.LastName;
                patientSear.MiddleName = patientJsonRead.MiddleName;
                patientSear.Birthday = patientJsonRead.Birthday;
                MessageBox.Show($"Информация о пациенте: {patientSear.Name} {patientSear.LastName}.");
            }
            else
            {
                MessageBox.Show("Идентификатор не найден, попробуйте еще раз!");
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            patientSear = (Patient)Resources["PatientSearch"];
            string patientSignIn = $"P_{patientSear.ID}.json";
            string patientJsonString = File.ReadAllText(patientSignIn);
            var patientJsonRead = JsonSerializer.Deserialize<Patient>(patientJsonString);
            if (patientSear.ID == patientJsonRead.ID)
            {
                patientSear.Name = patientJsonRead.Name;
                patientSear.LastName = patientJsonRead.LastName;
                patientSear.MiddleName = patientJsonRead.MiddleName;
                patientSear.Birthday = patientJsonRead.Birthday;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            patientSear = (Patient)Resources["PatientSearch"];
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            patientSear.ID = patientSear.ID;
            string jsonString = JsonSerializer.Serialize(patientSear, options);
            File.WriteAllText($"P_{patientSear.ID}.json", jsonString);
            MessageBox.Show($"Данные изменены успешно.");
        }

        private void SearchReception_Click(object sender, RoutedEventArgs e)
        {
            patientReception = (Patient)Resources["PatientReception"];
            string patientSignIn = $"P_{patientReception.ID}.json";
            string patientJsonString = File.ReadAllText(patientSignIn);
            var patientJsonRead = JsonSerializer.Deserialize<Patient>(patientJsonString);

            if (patientReception.ID == patientJsonRead.ID)
            {
                patientReception.Name = patientJsonRead.Name;
                patientReception.LastName = patientJsonRead.LastName;
                patientReception.MiddleName = patientJsonRead.MiddleName;
                patientReception.Birthday = patientJsonRead.Birthday;
                patientReception.LastAppointment = patientJsonRead.LastAppointment;
                patientReception.LastDoctor = doctorLogin.ID;
                patientReception.Diagnosis = patientJsonRead.Diagnosis;
                patientReception.Recomendations = patientJsonRead.Recomendations;
                MessageBox.Show($"Информация о пациенте: {patientReception.Name} {patientReception.LastName}.");
            }
            else
            {
                MessageBox.Show("Идентификатор не найден, попробуйте еще раз!");
            }
        }

        private void PatientAdmission_Click(object sender, RoutedEventArgs e)
        {
            if (authorization)
            {
                patientReception = (Patient)Resources["PatientReception"];
                string patientSignIn = $"P_{patientReception.ID}.json";
                string patientJsonString = File.ReadAllText(patientSignIn);
                var patientJsonRead = JsonSerializer.Deserialize<Patient>(patientJsonString);

                if (patientReception.ID == patientJsonRead.ID)
                {
                    patientReception.Name = patientJsonRead.Name;
                    patientReception.LastName = patientJsonRead.LastName;
                    patientReception.MiddleName = patientJsonRead.MiddleName;
                    patientReception.Birthday = patientJsonRead.Birthday;
                    patientReception.LastAppointment = patientJsonRead.LastAppointment;
                    patientReception.LastDoctor = doctorLogin.ID;
                    patientReception.Diagnosis = patientJsonRead.Diagnosis;
                    patientReception.Recomendations = patientJsonRead.Recomendations;
                    MessageBox.Show($"Информация о пациенте: {patientReception.Name} {patientReception.LastName}.");
                }
                else
                {
                    MessageBox.Show("Идентификатор не найден, попробуйте еще раз!");
                }
            }
            else
            {
                MessageBox.Show("Авторизуйтесь как пользователь!");
            }
        }

        private void SaveReception_Click(object sender, RoutedEventArgs e)
        {
            patientReception = (Patient)Resources["PatientReception"];
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            patientReception.ID = patientReception.ID;
            string jsonString = JsonSerializer.Serialize(patientReception, options);
            File.WriteAllText($"P_{patientReception.ID}.json", jsonString);
            MessageBox.Show($"Данные сохранены успешно.");
        }
    }
}