using DVLD_Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
namespace DVLD_Busness
{
    public class clsPerson
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int id { set; get; }
        public string first_name { set; get; }
        public string second_name { set; get; }
        public byte gendor {  set; get; }
        public string third_name { set; get; }
        public string last_name { set; get; }
        public DateTime date_of_birht { set; get; }
        public string national_number { set; get; }
        public string address { set; get; }
        public string phone { set; get; }
        public string email { set; get; }
        public int country_id { set; get; }
        public string image_path { set; get; }

        public string FullName()
        {
            return first_name + " " + second_name + " " + third_name + " " + last_name;
        }

        public clsPerson()

        {
            this.id = -1;
            this.first_name = "";
            this.second_name = "";
            this.third_name = "";
            this.last_name = "";
            this.email = "";
            this.phone = "";
            this.address = "";
            this.gendor = 0;
            this.date_of_birht = DateTime.Now;
            this.country_id = -1;
            this.image_path = "";
            this.national_number = "";

            Mode = enMode.AddNew;

            

        }

        private clsPerson(int id, string first_name, string second_name,string third_name,string last_name,
            string email, string phone, string address, DateTime date_of_birht,
            int country_id, string image_path,string national_number, byte gendor)

        {
            this.id = id;
            this.first_name = first_name;
            this.second_name = second_name;
            this.third_name = third_name;
            this.national_number = national_number;
            this.last_name = last_name;
            this.email = email;
            this.phone = phone;
            this.address = address;
            this.date_of_birht = date_of_birht;
            this.country_id = country_id;
            this.image_path = image_path;
            this.gendor = gendor;
                
            Mode = enMode.Update;

        }


        private bool _AddNewPerson()
        {
            

            this.id = clsPersonData.AddNewPerson(this.national_number,this.first_name,this.second_name,this.third_name,
                this.last_name,this.email,this.phone,this.address,this.date_of_birht,this.country_id,
                this.image_path,this.gendor);

            return (this.id != -1);
        }

        private bool _UpdatePerson()
        {
            

            return clsPersonData.UpdatePerson(this.id,this.national_number, this.first_name, this.second_name, this.third_name,
                this.last_name, this.email, this.phone, this.address, this.date_of_birht, this.country_id,
                this.image_path, this.gendor); ;

        }


        public static clsPerson Find(int id)
        {
            string first_name = "", second_name = "", third_name = "", last_name = "",
             email = "", phone = "", address = "",image_path = "", national_number = "";
             DateTime date_of_birht = DateTime.Now;
             byte gendor = 0;
             int country_id = -1;
            


            if (clsPersonData.GetPersonInfoByID(id,ref first_name, ref second_name, ref third_name, ref last_name, ref email, ref phone, ref address, ref date_of_birht
                ,ref image_path, ref national_number, ref gendor,ref country_id))

                return new clsPerson(id,first_name,second_name,third_name,last_name,email,phone,address,date_of_birht,country_id,image_path,national_number,gendor);
            else
                return null;
        }

        public static clsPerson Find(string national_number)
        {
            string first_name = "", second_name = "", third_name = "", last_name = "",
             email = "", phone = "", address = "", image_path = "";

            DateTime date_of_birht = DateTime.Now;
            byte gendor = 0;
            int country_id = -1, id = -1;

            if (clsPersonData.GetPersonInfoByNationalNumber(national_number,ref first_name, ref second_name, ref third_name, 
                ref last_name, ref email,ref phone, ref address, ref date_of_birht, ref image_path, 
                ref gendor, ref id, ref country_id))

                return new clsPerson(id, first_name, second_name, third_name, last_name, email, phone, address, date_of_birht, country_id, image_path, national_number, gendor);
            else
                return null;
        }
        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if(!isPersonExist(national_number))
                    {
                        if (_AddNewPerson())
                        {

                            Mode = enMode.Update;
                            return true;
                        }
                        
                    }
                    else
                    {
                        return false;
                    }
                    break;

                case enMode.Update:

                    return _UpdatePerson();

            }




            return false;
        }

        public static DataTable GetAllPersons()
        {
            return clsPersonData.GetAllPersons();

        }

        public static readonly Dictionary<string, string> filters_By = new Dictionary<string, string>
        {
            { "person_id", @"SELECT Countries.CountryName,People.* FROM People 
                             INNER JOIN Countries ON Countries.CountryID = People.NationalityCountryID
                             WHERE PersonID = @PersonID" },

            { "national_number", @"SELECT Countries.CountryName,People.* FROM People 
                                   INNER JOIN Countries ON Countries.CountryID = People.NationalityCountryID
                                   WHERE NationalNo = @NationalNo" },

            { "first_name", @"SELECT Countries.CountryName,People.* FROM People 
                              INNER JOIN Countries ON Countries.CountryID = People.NationalityCountryID
                              WHERE FirstName LIKE '%' + @FirstName + '%'" },

            { "second_name", @"SELECT Countries.CountryName,People.* FROM People 
                               INNER JOIN Countries ON Countries.CountryID = People.NationalityCountryID
                               WHERE SecondName LIKE '%' + @SecondName + '%'" },

            { "third_name", @"SELECT Countries.CountryName,People.* FROM People 
                              INNER JOIN Countries ON Countries.CountryID = People.NationalityCountryID
                              WHERE ThirdName LIKE '%' + @ThirdName + '%'" },

            { "last_name", @"SELECT Countries.CountryName,People.* FROM People 
                             INNER JOIN Countries ON Countries.CountryID = People.NationalityCountryID
                             WHERE LastName LIKE '%' + @LastName + '%'" },

            { "nationality", @"SELECT Countries.CountryName,People.* FROM People 
                               INNER JOIN Countries ON Countries.CountryID = People.NationalityCountryID
                               WHERE NationalityCountryID = @NationalityCountryID" },

            { "gendor", @"SELECT Countries.CountryName,People.* FROM People 
                          INNER JOIN Countries ON Countries.CountryID = People.NationalityCountryID
                          WHERE Gendor = @Gendor" },

            { "phone", @"SELECT Countries.CountryName,People.* FROM People 
                         INNER JOIN Countries ON Countries.CountryID = People.NationalityCountryID
                         WHERE Phone LIKE '%' + @Phone + '%'" },

            { "email", @"SELECT Countries.CountryName,People.* FROM People 
                         INNER JOIN Countries ON Countries.CountryID = People.NationalityCountryID
                         WHERE Email LIKE '%' + @Email +'%'" },

            { "none", @"SELECT Countries.CountryName,People.* FROM People 
                        INNER JOIN Countries ON Countries.CountryID = People.NationalityCountryID" }
        };

        public static DataTable filter(string query,object filterValue)
        {
            return clsPersonData.filter(query,filterValue);
        }

        public static bool DeletePerosn(int id)
        {
            if (isPersonExist(id))
            {
                return clsPersonData.DeletePerson(id);
            }
            else
            {
                return false;
            }
        }

        public static bool isPersonExist(int id)
        {
            return clsPersonData.IsPersonExist(id);
        }

        public static bool isPersonExist(string national_number)
        {
            return clsPersonData.IsPersonExist(national_number);
        }

        public static int GetPeopleCount()
        {
            return clsPersonData.Count();
        }

    }
}
