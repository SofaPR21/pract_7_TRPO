using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using практическая__7.Class;

namespace практическая__7
{
    public class Patient : INotifyPropertyChanged
    {
        private int _ID;
        private string _Name = "";
        private string _LastName = "";
        private string _MiddleName = "";
        private string _Number = "";
        private string _Birthday = "";
        private string _LastAppointment = "";
        private int _LastDoctor;
        private string _Diagnosis = "";
        private string _Recomendations = "";

        public int ID
        {
            get => _ID;
            set
            {
                if (_ID != value)
                {
                    _ID = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Name
        {
            get => _Name;
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string LastName
        {
            get => _LastName;
            set
            {
                if (_LastName != value)
                {
                    _LastName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string MiddleName
        {
            get => _MiddleName;
            set
            {
                if (_MiddleName != value)
                {
                    _MiddleName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Number
        {
            get => _Number;
            set
            {
                if (_Number != value)
                {
                    _Number = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Birthday
        {
            get => _Birthday;
            set
            {
                if (_Birthday != value)
                {
                    _Birthday = value;
                    OnPropertyChanged();
                }
            }
        }

        public string LastAppointment
        {
            get => _LastAppointment;
            set
            {
                if (_LastAppointment != value)
                {
                    _LastAppointment = value;
                    OnPropertyChanged();
                }
            }
        }

        public int LastDoctor
        {
            get => _LastDoctor;
            set
            {
                if (_LastDoctor != value)
                {
                    _LastDoctor = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Diagnosis
        {
            get => _Diagnosis;
            set
            {
                if (_Diagnosis != value)
                {
                    _Diagnosis = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Recomendations
        {
            get => _Recomendations;
            set
            {
                if (_Recomendations != value)
                {
                    _Recomendations = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<AppointmentStories> _AppointmentStories = new ObservableCollection<AppointmentStories>();
        public ObservableCollection<AppointmentStories> AppointmentStories
        {
            get => _AppointmentStories;
            set
            {
                if (_AppointmentStories != value)
                {
                    _AppointmentStories = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
