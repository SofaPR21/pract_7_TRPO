using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace практическая__7
{
    public class FileCount : INotifyPropertyChanged
    {
        private int _DoctorCount;

        private int _PatientCount;

        public int DoctorCount
        {
            get => _DoctorCount;
            set
            {
                if (_DoctorCount != value)
                {
                    _DoctorCount = value;
                    OnPropertyChanged();
                }
            }
        }

        public int PatientCount
        {
            get => _PatientCount;
            set
            {
                if (_PatientCount != value)
                {
                    _PatientCount = value;
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
