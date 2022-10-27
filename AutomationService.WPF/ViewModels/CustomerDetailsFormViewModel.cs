using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomationService.WPF.ViewModels
{
    public class CustomerDetailsFormViewModel : ViewModelBase
    {



        private string _nameSurname;

        public string NameSurname
        {
            get { return _nameSurname; }
            set
            {
                _nameSurname = value;
                OnPropertyChanged(nameof(NameSurname));
                OnPropertyChanged(nameof(CanSubmit));
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

        public bool CanSubmit => !string.IsNullOrEmpty(NameSurname);

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public static RelayCommand UploadPhotoCommand { get; set; }

        public CustomerDetailsFormViewModel(ICommand submitCommand, ICommand cancelCommand)
        {
            SubmitCommand = submitCommand;
            CancelCommand = cancelCommand;
        }

    }
}
