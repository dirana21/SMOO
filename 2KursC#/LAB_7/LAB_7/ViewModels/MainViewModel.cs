using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using LAB_7.Models;
using LAB_7.Services;

namespace LAB_7.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IStudentRepository _repository;
        private readonly IDialogService _dialogService;

        private Student _selectedStudent;

        public ObservableCollection<Student> Students { get; }

        public Student SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                if (_selectedStudent != value)
                {
                    _selectedStudent = value;
                    OnPropertyChanged(nameof(SelectedStudent));
                    // пересчитать, можно ли редактировать/удалять
                    (EditStudentCommand as RelayCommand)?.RaiseCanExecuteChanged();
                    (DeleteStudentCommand as RelayCommand)?.RaiseCanExecuteChanged();
                }
            }
        }

        public ICommand AddStudentCommand { get; }
        public ICommand EditStudentCommand { get; }
        public ICommand DeleteStudentCommand { get; }
        public ICommand SaveCommand { get; }

        public MainViewModel(IStudentRepository repository, IDialogService dialogService)
        {
            _repository = repository;
            _dialogService = dialogService;

            var students = _repository.LoadStudents();
            Students = new ObservableCollection<Student>(students);

            AddStudentCommand = new RelayCommand(_ => AddStudent());
            EditStudentCommand = new RelayCommand(_ => EditStudent(), _ => SelectedStudent != null);
            DeleteStudentCommand = new RelayCommand(_ => DeleteStudent(), _ => SelectedStudent != null);
            SaveCommand = new RelayCommand(_ => Save());
        }

        private void AddStudent()
        {
            var newStudent = new Student
            {
                LastName = "New",
                FirstName = "Student",
                Age = 18,
                Gender = "Man"
            };

            Students.Add(newStudent);
            SelectedStudent = newStudent;
        }

        private void EditStudent()
        {
            // В нашем варианте редактирование происходит прямо по привязкам
            // (TextBox привязаны к SelectedStudent). Здесь можно сделать доп. проверку.
            if (!ValidateStudent(SelectedStudent))
            {
                _dialogService.ShowError("The student's data is incorrect.", "Error");
            }
        }

        private void DeleteStudent()
        {
            if (SelectedStudent == null)
                return;

            bool confirm = _dialogService.Confirm(
                "Are you sure you want to delete the selected student?",
                "Delete confirmation");

            if (!confirm)
                return;

            Students.Remove(SelectedStudent);
            SelectedStudent = Students.FirstOrDefault();
        }

        private void Save()
        {
            if (Students.Any(s => !ValidateStudent(s)))
            {
                _dialogService.ShowError(
                    "There are errors in some entries. Please correct them before saving.",
                    "Validation error");
                return;
            }

            _repository.SaveStudents(Students.ToList());
        }

        private bool ValidateStudent(Student student)
        {
            if (student == null)
                return false;

            // IDataErrorInfo: если есть ошибка, индексатор вернёт строку
            string[] props = { nameof(Student.FirstName), nameof(Student.LastName), nameof(Student.Age), nameof(Student.Gender) };
            foreach (var p in props)
            {
                if (!string.IsNullOrEmpty(student[p]))
                    return false;
            }
            return true;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion
    }
}
