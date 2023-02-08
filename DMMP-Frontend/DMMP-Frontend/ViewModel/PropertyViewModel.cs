using DMMP_Frontend.Services;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DMMP_Frontend.ViewModel
{
    public class PropertyViewModel : INotifyPropertyChanged
    {
        private readonly PropertyService _propertyService;
        private Property _property;
        private bool _isBusy;
        private string _errorMessage;

        public PropertyViewModel(PropertyService propertyService)
        {
            _propertyService = propertyService;
            SaveCommand = new AsyncCommand(SaveAsync);
        }

        public int Id { get { return _property.PropertyId; } }

        public string Name
        {
            get { return _property.PropertyName; }
            set
            {
                if (_property.PropertyName != value)
                {
                    _property.PropertyName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string City
        {
            get { return _property.City; }
            set
            {
                if (_property.City != value)
                {
                    _property.City = value;
                    OnPropertyChanged();
                }
            }
        }
        public int PostalCode
        {
            get { return _property.PostalCode; }
            set
            {
                if (_property.PostalCode != value)
                {
                    _property.PostalCode = value;
                    OnPropertyChanged();
                }
            }
        }


        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                if (_errorMessage != value)
                {
                    _errorMessage = value;
                    OnPropertyChanged();
                }
            }
        }


        public ICommand SaveCommand { get; }

        private async Task SaveAsync()
        {
            try
            {
                IsBusy = true;
                ErrorMessage = string.Empty;

                // Validate the data
                if (string.IsNullOrEmpty(Name))
                {
                    ErrorMessage = "Name is required.";
                }

                // Save the property
                //await _propertyService.SaveAsync(_property);

                // Update the UI
                OnPropertyChanged(nameof(Id));
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
