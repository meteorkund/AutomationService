using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomationService.WPF.ViewModels
{
    public class BreakdownDetailsFormViewModel : ViewModelBase
    {


        private string _country;

        public string Country
        {
            get { return _country; }
            set { _country = value;
                OnPropertyChanged(nameof(Country));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        private string _companyName;

        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value;
                OnPropertyChanged(nameof(CompanyName));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        private string _creatorName;

        public string CreatorName
        {
            get { return _creatorName; }
            set { _creatorName = value;
                OnPropertyChanged(nameof(CreatorName));
            }
        }

        private bool _isElectrical;

        public bool IsElectrical
        {
            get { return _isElectrical; }
            set { _isElectrical = value;
                OnPropertyChanged(nameof(IsElectrical));
            }
        }

        private bool _isMechanical;

        public bool IsMechanical
        {
            get { return _isMechanical; }
            set { _isMechanical = value;
                OnPropertyChanged(nameof(IsMechanical));
            }
        }


        private string _department;

        public string Department
        {
            get { return _department; }
            set
            {
                _department = value;
                OnPropertyChanged(nameof(Department));
            }
        }


        private string _sector;

        public string Sector
        {
            get { return _sector; }
            set
            {
                _sector = value;
                OnPropertyChanged(nameof(Sector));
            }
        }



        private string _cause;

        public string Cause
        {
            get { return _cause; }
            set { _cause = value;
                OnPropertyChanged(nameof(Cause));
            }
        }

        private string _service;

        public string Service
        {
            get { return _service; }
            set { _service = value;
                OnPropertyChanged(nameof(Service));
            }
        }





        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);

        public bool CanSubmit => !string.IsNullOrEmpty(CompanyName) &&
                                 !string.IsNullOrEmpty(Country);

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public static RelayCommand UploadPhotoCommand { get; set; }

        public BreakdownDetailsFormViewModel(ICommand submitCommand, ICommand cancelCommand)
        {
            SubmitCommand = submitCommand;
            CancelCommand = cancelCommand;
        }

    }
}
