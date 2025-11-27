
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;


internal class MainViewModel : INotifyPropertyChanged
    {
        private readonly ICandidateRepository _repository;
        private Candidate _selectedCandidate;
        private string _educationFilter;
        private string _languageFilter;

        public ObservableCollection<Candidate> Candidates { get; }
        public ICollectionView CandidatesView { get; }

        public Candidate SelectedCandidate
        {
            get => _selectedCandidate;
            set
            {
                if (_selectedCandidate != value)
                {
                    _selectedCandidate = value;
                    OnPropertyChanged(nameof(SelectedCandidate));
                    if (_selectedCandidate != null)
                        _repository.Update(_selectedCandidate);
                }
            }
        }

        public string EducationFilter
        {
            get => _educationFilter;
            set
            {
                if (_educationFilter != value)
                {
                    _educationFilter = value;
                    OnPropertyChanged(nameof(EducationFilter));
                    CandidatesView.Refresh();
                }
            }
        }

        public string LanguageFilter
        {
            get => _languageFilter;
            set
            {
                if (_languageFilter != value)
                {
                    _languageFilter = value;
                    OnPropertyChanged(nameof(LanguageFilter));
                    CandidatesView.Refresh();
                }
            }
        }

        public ICommand AddCommand { get; }
        public ICommand RemoveCommand { get; }

        public MainViewModel() : this(new FileCandidateRepository("candidates.xml"))
        {

        }

    public MainViewModel(ICandidateRepository repository)
        {
            _repository = repository;

            Candidates = new ObservableCollection<Candidate>(_repository.GetAll());
            CandidatesView = CollectionViewSource.GetDefaultView(Candidates);
            CandidatesView.Filter = FilterCandidates;

            if (Candidates.Any())
            {
                SelectedCandidate = Candidates.First();
            }
            else
            {          
                SelectedCandidate = new Candidate
                {
                    BirthDate = DateTime.Now.AddYears(-20),
                    Education = "higher",
                    Language = "english",
                    LanguageLevel = "I read and translate with a dictionary",
                    KnowsComputer = true
                };
            }

            AddCommand = new RelayCommand(_ => AddCandidate());
            RemoveCommand = new RelayCommand(_ => RemoveCandidate(), _ => SelectedCandidate != null);
        }

        private bool FilterCandidates(object obj)
        {
            if (obj is not Candidate c)
                return false;

            bool educationOk = string.IsNullOrWhiteSpace(EducationFilter) ||
                               (c.Education?.IndexOf(EducationFilter, StringComparison.OrdinalIgnoreCase) >= 0);

            bool languageOk = string.IsNullOrWhiteSpace(LanguageFilter) ||
                              (c.Language?.IndexOf(LanguageFilter, StringComparison.OrdinalIgnoreCase) >= 0);

            return educationOk && languageOk;
        }

        private void AddCandidate()
        {
            if (SelectedCandidate == null)
                return;
           
            if (!Candidates.Contains(SelectedCandidate))
            {
                Candidates.Add(SelectedCandidate);
                _repository.Add(SelectedCandidate);
            }
            else
            {
                
                _repository.Update(SelectedCandidate);
            }
           
            SelectedCandidate = new Candidate
            {
                BirthDate = DateTime.Now.AddYears(-20),
                Education = "higher",
                Language = "english",
                LanguageLevel = "I read and translate with a dictionary",
                KnowsComputer = true
            };
        }

        private void RemoveCandidate()
        {
            if (SelectedCandidate == null)
                return;

            if (MessageBox.Show("Delete candidate?", "Confirmation",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _repository.Remove(SelectedCandidate);
                Candidates.Remove(SelectedCandidate);
                SelectedCandidate = null;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
