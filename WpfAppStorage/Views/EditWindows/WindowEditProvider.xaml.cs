using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfAppStorage.Models.Entities;
using WpfAppStorage.ViewModels;

namespace WpfAppStorage.Views.EditWindows
{
    /// <summary>
    /// Interaction logic for WindowEditProvider.xaml
    /// </summary>
    public partial class WindowEditProvider : Window
    {
        public WindowEditProvider(Provider providerToEdit)
        {
            InitializeComponent();
            DataContext = new DataVM();
            DataVM.ProviderApplic  = providerToEdit;
            DataVM.NameCompanyProv = providerToEdit.NameCompany;
            DataVM.CountryProv = providerToEdit.Country;
            DataVM.CityProv = providerToEdit.City;
            DataVM.StreetProv = providerToEdit.Street;
            DataVM.NumberHousePorv = providerToEdit.NumberHouse;
            DataVM.PhoneNumberProv = providerToEdit.PhoneNumber;
        }
    }
}
