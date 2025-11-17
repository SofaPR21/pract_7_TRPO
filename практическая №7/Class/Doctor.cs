using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace практическая__7
{
    public class Doctor : INotifyPropertyChanged
    {
        public bool login = false;
        private int _ID;
        private string _Name = "";
        private string _LastName = "";
        private string _MiddleName = "";
        private string _Specialisation = "";
        private string _Password = "";

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

        public string Specialisation
        {
            get => _Specialisation;
            set
            {
                if (_Specialisation != value)
                {
                    _Specialisation = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Password
        {
            get => _Password;
            set
            {
                if (_Password != value)
                {
                    _Password = value;
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

