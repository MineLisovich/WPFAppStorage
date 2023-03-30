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
    /// Interaction logic for WindowEditSectionsStorage.xaml
    /// </summary>
    public partial class WindowEditSectionsStorage : Window
    {
        public WindowEditSectionsStorage(SectionsStorage sectionsStorageToEdit)
        {
            InitializeComponent();
            DataContext = new DataVM();
            DataVM.SectionsStorageApplic = sectionsStorageToEdit;
            DataVM.NameSectionStorage = sectionsStorageToEdit.NameSections;

        }
    }
}
