using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppStorage.Models.Entities;


namespace WpfAppStorage.Models
{
    public static class DataManager
    {
        #region TABLE APPLICANCE
        // get all applicances
        public static List<Applicances> GetAllApplicances()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var result =  db.Applicances.Include(t=>t.TypeAplicances).Include(p=>p.Provider).Include(s=>s.SectionsStorage).ToList();
                return result;
            }
        }

        // add method
        public static string CreateApplicance(string name, TypeApplicances _typeAplicances, decimal price, int countApplicances, Provider _provider, SectionsStorage _sectionsStorage)
        {
            string result = "Уже существует";
            using (AppDbContext db = new AppDbContext())
            {
                //порверка существует ли запись
                bool check = db.Applicances.Any(x => x.Name == name && x.TypeAplicances == _typeAplicances && x.Price == price && x.CountApplicances == countApplicances
                && x.Provider == _provider && x.SectionsStorage == _sectionsStorage);
                if (!check)
                {
                    Applicances applicances = new Applicances
                    {
                        Name = name,
                        TypeAplicancesid = _typeAplicances.Id,
                        Price = price,
                        CountApplicances = countApplicances,
                        Providerid = _provider.Id,
                        SectionsStorageid = _sectionsStorage.Id,
                        AddDate = DateTime.Now
                    };
                    db.Applicances.Add(applicances);
                    db.SaveChanges();
                    result = "Сделано";
                }
                return result;
            }
        }
        // edit method
        public static string EditApplicance(Applicances _applicances, string name, TypeApplicances _typeAplicances, decimal price, int countApplicances, Provider _provider, SectionsStorage _sectionsStorage)
        {
            string result = "Такой записи не существует";
            using (AppDbContext db = new AppDbContext())
            {
                Applicances applicances = db.Applicances.FirstOrDefault(x => x.Id == _applicances.Id);
                applicances.Name = name;
                applicances.TypeAplicancesid = _typeAplicances.Id;
                applicances.Price = price;
                applicances.CountApplicances = countApplicances;
                applicances.Providerid = _provider.Id;
                applicances.SectionsStorageid = _sectionsStorage.Id;
                applicances.AddDate = DateTime.Now;
                db.SaveChanges();
                result = "Изменение сделано, новое значение: " + applicances.Name;
            }
            return result;
        }
        // delete method
        public static string DeleteApplicances(Applicances model)
        {
            string result = "Такой записи не существует";
            using (AppDbContext db = new AppDbContext())
            {
                db.Applicances.Remove(model);
                db.SaveChanges();
                result = "Удалено " + model.Name;
            }
            return result;
        }
        #endregion

        #region TABLE PROVIDER
        // get all provider
        public static List<Provider> GetAllProvider()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var result = db.Providers.ToList();
                return result;
            }
        }
        // add method
        public static string CreateProvider(string name, string country, string city, string street, int numberHouse, string phoneNumber)
        {
            string result = "Уже существует";
            using (AppDbContext db = new AppDbContext())
            {
                //порверка существует ли запись
                bool check = db.Providers.Any(x => x.NameCompany == name && x.Country == country && x.City == city && x.Street == street && x.NumberHouse == numberHouse && x.PhoneNumber == phoneNumber);
                if (!check)
                {
                    Provider provider = new Provider
                    {
                        NameCompany = name,
                        Country = country,
                        City = city,
                        Street = street,
                        NumberHouse = numberHouse,
                        PhoneNumber = phoneNumber
                    };
                    db.Providers.Add(provider);
                    db.SaveChanges();
                    result = "Сделано";
                }
                return result;
            }
        }
        // edit method
        public static string EditProvider(Provider _provider, string name, string country, string city, string street, int numberHouse, string phoneNumber)
        {
            string result = "Такой записи не существует";
            using (AppDbContext db = new AppDbContext())
            {
                Provider provider = db.Providers.FirstOrDefault(x => x.Id == _provider.Id);
                provider.NameCompany = name;
                provider.Country = country;
                provider.City = city;
                provider.Street = street;
                provider.NumberHouse = numberHouse;
                provider.PhoneNumber = phoneNumber;

                db.SaveChanges();
                result = "Изменение сделано, новое значение: " + provider.NameCompany;
            }
            return result;
        }
        // delete method
        public static string DeleteProvider(Provider model)
        {
            string result = "Такой записи не существует";
            using (AppDbContext db = new AppDbContext())
            {
                db.Providers.Remove(model);
                db.SaveChanges();
                result = "Удалено " + model.NameCompany;
            }
            return result;
        }
        #endregion

        #region TABLE SECTION STORAGE
        // get all sections storage
        public static List<SectionsStorage> GetAllSection()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var result =  db.SectionsStorage.ToList();
                return result;
            }
        }
        // add method
        public static string CreateSection(string name)
        {
            string result = "Уже существует";
            using (AppDbContext db = new AppDbContext())
            {
                //порверка существует ли запись
                bool check = db.SectionsStorage.Any(x => x.NameSections == name);
                if (!check)
                {
                    SectionsStorage sectionsStorage = new SectionsStorage
                    {
                        NameSections = name
                    };
                    db.SectionsStorage.Add(sectionsStorage);
                    db.SaveChanges();
                    result = "Сделано";
                }
                return result;
            }
        }
        // edit method
        public static string EditSection(SectionsStorage _sectionsStorage, string name)
        {
            string result = "Такой записи не существует";
            using (AppDbContext db = new AppDbContext())
            {
                SectionsStorage sectionsStorage = db.SectionsStorage.FirstOrDefault(x => x.Id == _sectionsStorage.Id);
                sectionsStorage.NameSections = name;
                db.SaveChanges();
                result = "Изменение сделано, новое значение: " + sectionsStorage.NameSections;
            }
            return result;
        }
        // delete method
        public static string DeleteSection(SectionsStorage model)
        {
            string result = "Такой записи не существует";
            using (AppDbContext db = new AppDbContext())
            {
                db.SectionsStorage.Remove(model);
                db.SaveChanges();
                result = "Удалено " + model.NameSections;
            }
            return result;
        }
        #endregion

        #region TABLE TYPEAPPLICANCE
        // get all type applicances
        public static List<TypeApplicances> GetAllType()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var result =  db.TypeApplicances.ToList();
                return result;
            }
        }
        // add method
        public static string CreateType(string name)
        {
            string result = "Уже существует";
            using (AppDbContext db = new AppDbContext())
            {
                //порверка существует ли запись
                bool check = db.TypeApplicances.Any(x => x.NameType == name);
                if (!check)
                {
                    TypeApplicances typeAplicances = new TypeApplicances
                    {
                        NameType = name
                    };
                    db.TypeApplicances.Add(typeAplicances);
                    db.SaveChanges();
                    result = "Сделано";
                }
                return result;
            }
        }
        // edit method
        public static string EditType(TypeApplicances _typeAplicances, string name)
        {
            string result = "Такой записи не существует";
            using (AppDbContext db = new AppDbContext())
            {
                TypeApplicances typeAplicances = db.TypeApplicances.FirstOrDefault(x => x.Id == _typeAplicances.Id);
                typeAplicances.NameType = name;
                db.SaveChanges();
                result = "Изменение сделано, новое значение: " + typeAplicances.NameType;
            }
            return result;
        }
        // delete method
        public static string DeleteType(TypeApplicances model)
        {
            string result = "Такой записи не существует";
            using (AppDbContext db = new AppDbContext())
            {
                db.TypeApplicances.Remove(model);
                db.SaveChanges();
                result = "Удалено " + model.NameType;
            }
            return result;
        }
        #endregion
    }
}
