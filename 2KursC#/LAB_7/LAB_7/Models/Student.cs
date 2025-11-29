using System;
using System.ComponentModel;

namespace LAB_7.Models
{
    public class Student : INotifyPropertyChanged, IDataErrorInfo
    {
        private string _firstName;
        private string _lastName;
        private int _age;
        private string _gender;

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged(nameof(LastName));
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (_age != value)
                {
                    _age = value;
                    OnPropertyChanged(nameof(Age));
                    OnPropertyChanged(nameof(AgeWithSuffix));
                }
            }
        }

        public string Gender
        {
            get => _gender;
            set
            {
                if (_gender != value)
                {
                    _gender = value;
                    OnPropertyChanged(nameof(Gender));
                }
            }
        }

        
        public string FullName => $"{LastName} {FirstName}";

        public string AgeWithSuffix => $"{Age} {GetAgeSuffix(Age)}";

        private string GetAgeSuffix(int age)
        {
            
            if (age % 10 == 1 && age % 100 != 11)
                return "year";
            if (age % 10 >= 2 && age % 10 <= 4 && (age % 100 < 10 || age % 100 >= 20))
                return "years";
            return "years";
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion

        #region IDataErrorInfo (Validations)

        public string Error => null; 

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(FirstName):
                        if (string.IsNullOrWhiteSpace(FirstName))
                            return "Name is required.";
                        break;
                    case nameof(LastName):
                        if (string.IsNullOrWhiteSpace(LastName))
                            return "Last name is required.";
                        break;
                    case nameof(Gender):
                        if (string.IsNullOrWhiteSpace(Gender))
                            return "Gender is mandatory.";
                        break;
                    case nameof(Age):
                        if (Age < 16 || Age > 100)
                            return "Age must be in the range [16, 100].";
                        break;
                }
                return null;
            }
        }

        #endregion
    }
}
