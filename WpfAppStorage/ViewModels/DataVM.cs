using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfAppStorage.Models;
using WpfAppStorage.Models.Entities;
using WpfAppStorage.Views;
using WpfAppStorage.Views.AddWindows;
using WpfAppStorage.Views.EditWindows;
using System.Windows.Media;
using WpfAppStorage.Views.MessageViews;

namespace WpfAppStorage.ViewModels
{
    public class DataVM : INotifyPropertyChanged
    {

        #region MODELS TABLES
        // type applicances
        public static string TypeApplicancesName { get; set; }

        // sections storage 
        public static string NameSectionStorage { get; set; }

        // provider
        public static string NameCompanyProv { get; set; }

        public static string CountryProv { get; set; }

        public static string CityProv { get; set; }

        public static string StreetProv { get; set; }

        public static int NumberHousePorv { get; set; }

        public static string PhoneNumberProv { get; set; }
        // Applicances
        public static string NameApplic { get; set; }
        public static TypeApplicances TypeAplicancesApplic { get; set; }
        public static decimal PriceApplic { get; set; }
        public  static int CountApplicancesApplic { get; set; }
        public static Provider ProviderApplic { get; set; }
        public static SectionsStorage SectionsStorageApplic { get; set; }
        public static Applicances SelectApplicances { get; set; }

        public TabItem tabItemSelect { get; set; }
        

        #endregion

        #region VIEW DATA TABLES METHODS
        // список бытовой техники  
        private  List<Applicances> allApplicances = DataManager.GetAllApplicances();
        public   List<Applicances> AllApplicances
        {
            get { return  allApplicances; }
            set
            {
                allApplicances = value;
                NotifyPropertyChanged("AllApplicances");
            }
        }

        // список поставщиков
        private List<Provider> allProviders = DataManager.GetAllProvider();
        public List<Provider> AllProviders
        {
            get { return allProviders; }
            set
            {
                allProviders = value;
                NotifyPropertyChanged("AllProviders");
            }
        }
        // список типов быт техники
        private List<TypeApplicances> allType = DataManager.GetAllType();
        public List<TypeApplicances> AllType
        {
            get { return allType; }
            set
            {
                allType = value;
                NotifyPropertyChanged("AllType");
            }
        }
        // список секции склада
        private List<SectionsStorage> allSection = DataManager.GetAllSection();
        public List<SectionsStorage> AllSection
        {
            get { return allSection; }
            set
            {
                allSection = value;
                NotifyPropertyChanged("AllSection");
            }
        }
        #endregion

        #region OPEN WINDOW METHODS
        // метод для открытия окна по центру экрана
        private void OpenWindowCS(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ShowDialog();
        }
        // методы открытия окон
        // Add Window
        private void OpenWindowAddApplicances ()
        {
            SetNullValuesProperties();
            WindowAddAppliances windowAddAppliances = new WindowAddAppliances();
            OpenWindowCS (windowAddAppliances);
        }
        private void OpenWindowAddProvider()
        {
            SetNullValuesProperties();
            WindowAddProvider windowAddProvider = new WindowAddProvider();
            OpenWindowCS(windowAddProvider);
        }
        private void OpenWindowAddSectionsStorage()
        {
            SetNullValuesProperties();
            WindowAddSectionsStorage windowAddSectionsStorage = new WindowAddSectionsStorage();
            OpenWindowCS(windowAddSectionsStorage);
        }
        private void OpenWindowAddTypeApplicances()
        {
            SetNullValuesProperties();
            WindowAddTypeAppliances windowAddTypeAppliances = new WindowAddTypeAppliances();
            OpenWindowCS(windowAddTypeAppliances);
        }
        // Edit Window
        private void OpenWindowEditApplicances(Applicances applicances)
        {
            WindowEditAppliances windowEditAppliances = new WindowEditAppliances(applicances);
            OpenWindowCS(windowEditAppliances);
        }
        private void OpenWindowEditProvider(Provider provider)
        {
            WindowEditProvider windowEditProvider = new WindowEditProvider(provider);
            OpenWindowCS(windowEditProvider);
        }
        private void OpenWindowEditSectionsStorage(SectionsStorage sectionsStorage)
        {
            WindowEditSectionsStorage windowEditSectionsStorage = new WindowEditSectionsStorage(sectionsStorage);
            OpenWindowCS(windowEditSectionsStorage);
        }
        private void OpenWindowEditTypeApplicances(TypeApplicances typeApplicances)
        {
            WindowEditTypeAppliances windowEditTypeAppliances = new WindowEditTypeAppliances(typeApplicances);
            OpenWindowCS(windowEditTypeAppliances);
        }
        #endregion

        #region OPEN WINDOW COMMANDS
        // ADD WINDOW
        // Aplicances
        private RelayCommand openAddApplicancesWindow;
        public RelayCommand OpenAddApplicancesWindow
        {
            get 
            {
                return openAddApplicancesWindow ?? new RelayCommand(obj =>
                {
                    OpenWindowAddApplicances();
                });
            }
        }
        // Provider
        private RelayCommand openAddProviderWindow;
        public RelayCommand OpenAddProviderWindow
        {
            get
            {
                return openAddProviderWindow ?? new RelayCommand(obj =>
                {
                    OpenWindowAddProvider();
                });
            }
        }
        // Sections Storage
        private RelayCommand openAddSectionsStorageWindow;
        public RelayCommand OpenAddSectionsStorageWindow
        {
            get
            {
                return openAddSectionsStorageWindow ?? new RelayCommand(obj =>
                {
                    OpenWindowAddSectionsStorage();
                });
            }
        }
        // Type Applicances
        private RelayCommand openAddTypeApplicancesWindow;
        public RelayCommand OpenAddTypeApplicancesWindow
        {
            get
            {
                return openAddTypeApplicancesWindow ?? new RelayCommand(obj =>
                {
                    OpenWindowAddTypeApplicances();
                });
            }
        }
       

        #endregion

        #region ADD COMMANDS IN TABLE
        // add new type applicances
        private RelayCommand addNewTypeApplicances;
        public RelayCommand AddNewTypeApplicances
        {
            get
            {
                return addNewTypeApplicances ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resulStr = "";
                    //пороверка поля 
                    if (TypeApplicancesName == null || TypeApplicancesName.Replace(" ", "").Length==0)
                    {
                        SetRedBlockControl(window, "NameBlock");
                    }
                    else
                    {
                        resulStr = DataManager.CreateType(TypeApplicancesName);
                        ShowMessageToUser(resulStr);
                        AllUpdate();
                        SetNullValuesProperties();
                        window.Close();
                    }
                   
                });
            }
        }

        // add new sections storage 
        private RelayCommand addNewSectionsStorage;
        public RelayCommand AddNewSectionsStorage
        {
            get
            {
                return addNewSectionsStorage ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string result = "";
                    if (NameSectionStorage == null || NameSectionStorage.Replace(" ", "").Length==0)
                    {
                        SetRedBlockControl(window, "NameSections");
                    }
                    else
                    {
                        result = DataManager.CreateSection(NameSectionStorage);
                        ShowMessageToUser(result);
                        AllUpdate();
                        SetNullValuesProperties();
                        window.Close();
                    }
                });
            }
        }

        // add new provider 
        private RelayCommand addNewProvider;
        public RelayCommand AddNewProvider
        {
            get
            {
                return addNewProvider ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string result = "";
                    if (NameCompanyProv == null || NameCompanyProv.Replace(" ", "").Length==0)
                    {
                        SetRedBlockControl(window, "ProviderName");
                    }

                    if( CountryProv == null || CountryProv.Replace(" ", "").Length==0)
                    {
                        SetRedBlockControl(window, "ProviderCountry");
                    }
                    if (CityProv == null || CityProv.Replace(" ", "").Length==0)
                    {
                        SetRedBlockControl(window, "ProviderCity");
                    }
                    if ( StreetProv == null || StreetProv.Replace(" ","").Length==0)
                    {
                        SetRedBlockControl(window, "ProviderStreet");
                    }
                    if(NumberHousePorv <= 0)
                    {
                        SetRedBlockControl(window, "ProviderNumberHouse");
                    }
                    if (PhoneNumberProv == null || PhoneNumberProv.Replace(" ", "").Length==0)
                    {
                        SetRedBlockControl(window, "ProviderPhone");
                    }
                    else
                    {
                        result = DataManager.CreateProvider(NameCompanyProv,CountryProv,CityProv,StreetProv,NumberHousePorv,PhoneNumberProv);
                        ShowMessageToUser(result);
                        AllUpdate();
                        SetNullValuesProperties();
                        window.Close();
                    }
                });
            }
        }
        private RelayCommand addNewApplicances;
        public RelayCommand AddNewApplicances
        {
            get
            {
                return addNewApplicances ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string result = "";
                    if (NameApplic == null || NameApplic.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(window, "NameApplic");
                    }
                    if (TypeAplicancesApplic == null)
                    {
                        MessageBox.Show("Укажите тип техники");
                    }
                    if (PriceApplic <= 0)
                    {
                        SetRedBlockControl(window, "PriceApplic");
                    }
                    if (CountApplicancesApplic <= 0)
                    {
                        SetRedBlockControl(window, "CountApplic");
                    }
                    if (ProviderApplic == null)
                    {
                        MessageBox.Show("Укажите поставщика");
                    }
                    if (SectionsStorageApplic == null)
                    {
                        MessageBox.Show("Укажите секцию склада");
                    }
                    else
                    {
                        result = DataManager.CreateApplicance(NameApplic, TypeAplicancesApplic, PriceApplic, CountApplicancesApplic, ProviderApplic, SectionsStorageApplic);
                        ShowMessageToUser(result);
                        AllUpdate();
                        SetNullValuesProperties();
                        window.Close();
                    }
                });
            }
        }
        #endregion

        #region COMMANDS EDIT TABLE
        // Applicances
        private RelayCommand editApplicances;
        public RelayCommand EditApplicances
        {
            get
            {
                return editApplicances ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string result = "";
                    if (NameApplic == null || NameApplic.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(window, "NameApplic");
                    }
                    if (TypeAplicancesApplic == null)
                    {
                        MessageBox.Show("Укажите тип техники");
                    }
                    if (PriceApplic <= 0)
                    {
                        SetRedBlockControl(window, "PriceApplic");
                    }
                    if (CountApplicancesApplic <= 0)
                    {
                        SetRedBlockControl(window, "CountApplic");
                    }
                    if (ProviderApplic == null)
                    {
                        MessageBox.Show("Укажите поставщика");
                    }
                    if (SectionsStorageApplic == null)
                    {
                        MessageBox.Show("Укажите секцию склада");
                    }
                    else
                    {
                        result = DataManager.EditApplicance(SelectApplicances,NameApplic,TypeAplicancesApplic,PriceApplic,CountApplicancesApplic,ProviderApplic,SectionsStorageApplic);
                        ShowMessageToUser(result);
                        AllUpdate();
                        SetNullValuesProperties();
                        window.Close();
                    }
                });
            }
        }
        // add new type applicances
        private RelayCommand editTypeApplicances;
        public RelayCommand EditTypeApplicances
        {
            get
            {
                return editTypeApplicances ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resulStr = "";
                    //пороверка поля 
                    if (TypeApplicancesName == null || TypeApplicancesName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(window, "NameBlock");
                    }
                    else
                    {
                        resulStr = DataManager.EditType(TypeAplicancesApplic,TypeApplicancesName);
                        ShowMessageToUser(resulStr);
                        AllUpdate();
                        SetNullValuesProperties();
                        window.Close();
                    }

                });
            }
        }

        // add new sections storage 
        private RelayCommand editSectionsStorage;
        public RelayCommand EditSectionsStorage
        {
            get
            {
                return editSectionsStorage ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string result = "";
                    if (NameSectionStorage == null || NameSectionStorage.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(window, "NameSections");
                    }
                    else
                    {
                        result = DataManager.EditSection(SectionsStorageApplic,NameSectionStorage);
                        ShowMessageToUser(result);
                        AllUpdate();
                        SetNullValuesProperties();
                        window.Close();
                    }
                });
            }
        }

        // add new provider 
        private RelayCommand editProvider;
        public RelayCommand EditProvider
        {
            get
            {
                return editProvider ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string result = "";
                    if (NameCompanyProv == null || NameCompanyProv.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(window, "ProviderName");
                    }

                    if (CountryProv == null || CountryProv.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(window, "ProviderCountry");
                    }
                    if (CityProv == null || CityProv.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(window, "ProviderCity");
                    }
                    if (StreetProv == null || StreetProv.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(window, "ProviderStreet");
                    }
                    if (NumberHousePorv <= 0)
                    {
                        SetRedBlockControl(window, "ProviderNumberHouse");
                    }
                    if (PhoneNumberProv == null || PhoneNumberProv.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(window, "ProviderPhone");
                    }
                    else
                    {
                        result = DataManager.EditProvider(ProviderApplic,NameCompanyProv, CountryProv, CityProv, StreetProv, NumberHousePorv, PhoneNumberProv);
                        ShowMessageToUser(result);
                        AllUpdate();
                        SetNullValuesProperties();
                        window.Close();
                    }
                });
            }
        }
        #endregion


        // удаление из бд
        private RelayCommand deleteItem;
        public RelayCommand DeleteItem
        {
            get
            {
                return deleteItem ?? new RelayCommand(obj=>
                {
                    string result = "Ошибка, ничего не выбрано";
                    //Applicances
                    if (tabItemSelect.Name == "AppliancesTab" && SelectApplicances != null)
                    {
                        result = DataManager.DeleteApplicances(SelectApplicances);
                    }
                    // type applicances
                    if (tabItemSelect.Name == "TypeAppliancesTab" && TypeAplicancesApplic != null)
                    {
                        result = DataManager.DeleteType(TypeAplicancesApplic);
                    }
                    //provider
                    if (tabItemSelect.Name == "ProviderTab" && ProviderApplic != null)
                    {
                        result = DataManager.DeleteProvider(ProviderApplic);
                    }
                    //sections storage
                    if (tabItemSelect.Name == "SectionsStorageTab" && SectionsStorageApplic != null)
                    {
                        result = DataManager.DeleteSection(SectionsStorageApplic);
                    }

                    SetNullValuesProperties();
                    ShowMessageToUser(result);
                    AllUpdate();
                });
            }
        }
        // Редактирование открытие окон
        private RelayCommand openWinEdit;
        public RelayCommand OpenWinEdit
        {
            get
            {
                return openWinEdit ?? new RelayCommand(obj =>
                {
                    string result = "Ошибка, ничего не выбрано";
                    //Applicances
                    if (tabItemSelect.Name == "AppliancesTab" && SelectApplicances != null)
                    {
                        OpenWindowEditApplicances(SelectApplicances);  
                    }
                    // type applicances
                    if (tabItemSelect.Name == "TypeAppliancesTab" && TypeAplicancesApplic != null)
                    {
                        OpenWindowEditTypeApplicances(TypeAplicancesApplic);
                    }
                    //provider
                    if (tabItemSelect.Name == "ProviderTab" && ProviderApplic != null)
                    {
                        OpenWindowEditProvider(ProviderApplic);
                    }
                    //sections storage
                    if (tabItemSelect.Name == "SectionsStorageTab" && SectionsStorageApplic != null)
                    {
                        OpenWindowEditSectionsStorage(SectionsStorageApplic);
                    }
                });
            }
        }

        #region UPDATE VIEWS

        private void SetNullValuesProperties()
        {
        // type applicances
            TypeApplicancesName = null;

        // sections storage 
            NameSectionStorage = null;

        // provider
            NameCompanyProv = null;
            CountryProv = null;
            CityProv = null;
            StreetProv = null;
            NumberHousePorv = 0;
            PhoneNumberProv = null;

        // Applicances
            NameApplic = null;
            TypeAplicancesApplic = null;
            PriceApplic = 0;
            CountApplicancesApplic = 0;
            ProviderApplic = null;
            SectionsStorageApplic = null;
    }
        private void AllUpdate ()
        {
            UpdateViewApplicances();
            UpdateViewProvider();
            UpdateViewSectionsStorage();
            UpdateViewTypeApplicances();
        }
        private void UpdateViewApplicances()
        {
            AllApplicances = DataManager.GetAllApplicances();
            MainWindow.AllAplicancesView.ItemsSource = null;
            MainWindow.AllAplicancesView.Items.Clear();
            MainWindow.AllAplicancesView.ItemsSource = AllApplicances;
            MainWindow.AllAplicancesView.Items.Refresh();
        }

        private void UpdateViewTypeApplicances()
        {
            AllType = DataManager.GetAllType();
            MainWindow.AllTypeAplicancesView.ItemsSource = null;
            MainWindow.AllTypeAplicancesView.Items.Clear();
            MainWindow.AllTypeAplicancesView.ItemsSource = AllType;
            MainWindow.AllTypeAplicancesView.Items.Refresh();
        }

        private void UpdateViewProvider()
        {
            AllProviders = DataManager.GetAllProvider();
            MainWindow.AllProviderView.ItemsSource = null;
            MainWindow.AllProviderView.Items.Clear();
            MainWindow.AllProviderView.ItemsSource = AllProviders;
            MainWindow.AllProviderView.Items.Refresh();
        }

        private void UpdateViewSectionsStorage()
        {
            AllSection = DataManager.GetAllSection();
            MainWindow.AllSectionsStorageView.ItemsSource = null;
            MainWindow.AllSectionsStorageView.Items.Clear();
            MainWindow.AllSectionsStorageView.ItemsSource = AllSection;
            MainWindow.AllSectionsStorageView.Items.Refresh();
        }
        #endregion

        // если поле пустое то будет красная обводка у текстовых полей
        private void SetRedBlockControl (Window window , string blockName)
        {
            Control block = window.FindName(blockName) as Control;
            block.BorderBrush =  Brushes.Red;
           

        }

        // оповещение пользователя о выполненных действиях
        private void ShowMessageToUser(string message)
        {
            MessageView messageView = new MessageView(message);
            OpenWindowCS(messageView);
        }

        //реадизация интерфейса INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged (String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
            }
        }
    }
}
