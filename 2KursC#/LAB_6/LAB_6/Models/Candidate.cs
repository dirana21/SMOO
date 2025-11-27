using System;
using System.ComponentModel;

public class Candidate : INotifyPropertyChanged
{
    private string _fullName;
    private DateTime _birthDate;
    private string _education;
    private string _language;
    private string _languageLevel;
    private bool _knowsComputer;
    private int _experienceYears;
    private bool _hasRecommendations;

    public string FullName
    {
        get => _fullName;
        set
        {
            if (_fullName != value)
            {
                _fullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }
    }

    public DateTime BirthDate
    {
        get => _birthDate;
        set
        {
            if (_birthDate != value)
            {
                _birthDate = value;
                OnPropertyChanged(nameof(BirthDate));
            }
        }
    }

    public string Education
    {
        get => _education;
        set
        {
            if (_education != value)
            {
                _education = value;
                OnPropertyChanged(nameof(Education));
            }
        }
    }

    public string Language
    {
        get => _language;
        set
        {
            if (_language != value)
            {
                _language = value;
                OnPropertyChanged(nameof(Language));
            }
        }
    }

    public string LanguageLevel
    {
        get => _languageLevel;
        set
        {
            if (_languageLevel != value)
            {
                _languageLevel = value;
                OnPropertyChanged(nameof(LanguageLevel));
            }
        }
    }

    public bool KnowsComputer
    {
        get => _knowsComputer;
        set
        {
            if (_knowsComputer != value)
            {
                _knowsComputer = value;
                OnPropertyChanged(nameof(KnowsComputer));
            }
        }
    }

    public int ExperienceYears
    {
        get => _experienceYears;
        set
        {
            if (_experienceYears != value)
            {
                _experienceYears = value;
                OnPropertyChanged(nameof(ExperienceYears));
            }
        }
    }

    public bool HasRecommendations
    {
        get => _hasRecommendations;
        set
        {
            if (_hasRecommendations != value)
            {
                _hasRecommendations = value;
                OnPropertyChanged(nameof(HasRecommendations));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
