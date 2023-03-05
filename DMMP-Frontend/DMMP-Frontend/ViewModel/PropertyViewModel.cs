using DMMP_Frontend.Services;
using DMMP_Frontend.View;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DMMP_Frontend.ViewModel
{
    public partial class PropertyViewModel : BaseViewModel
    {
        public ObservableCollection<Property> Properties { get; } = new();
        PropertyService propertyService;
        IConnectivity connectivity;
        //IGeolocation geolocation;

        public PropertyViewModel(PropertyService propertyService, IConnectivity connectivity)
        {
            Title = "Property View";
            this.connectivity = connectivity;
            this.propertyService = propertyService;
        }

        [RelayCommand]
        async Task GoToDetails(Property property)
        {
            if (property == null)
                return;

            await Shell.Current.GoToAsync(nameof(DetailPage), true, new Dictionary<string, object>
            {
                {"Property", property }
            });
        }

        [ObservableProperty]
        bool isRefreshing;

        [RelayCommand]
        async Task GetPropertiesAsync()
        {
            if (IsBusy)
                return;

            try
            {
                if (connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("No connectivity!",
                        $"Please check internet and try again.", "OK");
                    return;
                }

                IsBusy = true;
                var properties = await propertyService.GetPropertiesAsync();

                if (Properties.Count != 0)
                    Properties.Clear();

                foreach (var monkey in properties)
                    Properties.Add(monkey);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get properties: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }

        }

    }
}
