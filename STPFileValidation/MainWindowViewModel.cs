using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace STPFileValidation
{
    public class MainWindowViewModel: NotifyClass
    {
        private readonly STPFileValidator _STPFileValidator;

        private string _STPFile;
        public string STPFile
        {
            get { return _STPFile; }
            set
            {
                if (value != _STPFile)
                {
                    _STPFile = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<ValidationError> ValidationErrors { get; private set; }

        public RelayCommand ValidateCommand { get; private set; }


        public MainWindowViewModel()
        {
            ValidationErrors = new ObservableCollection<ValidationError>();
            ValidateCommand = new RelayCommand(Validate);

            _STPFileValidator = new STPFileValidator();
        }

        public void Validate()
        {
            ValidationErrors.Clear();

            _STPFileValidator.Validate(_STPFile);
            foreach (var error in _STPFileValidator.Errors)
                ValidationErrors.Add(error);
        }

    }


}
