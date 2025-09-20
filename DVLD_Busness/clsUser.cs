using DVLD_Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Busness
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int id { set; get; }

        public int person_id { set; get; }
        public string username { set; get; }

        public string password { set; get; }

        public bool is_active { set; get; }

        public clsPerson perosn_info;

        public clsUser() 
        {
            Mode = enMode.AddNew;
            this.id = -1;
            this.username = "";
            this.password = "";
            this.is_active = false;
            this.person_id = -1;
            
        }

        public clsUser(int id, int perosn_id,string username, string password, bool is_active)
        {
            Mode = enMode.Update;
            this.id = id;
            this.username = username;
            this.password = password;
            this.is_active = is_active;
            this.person_id = perosn_id;
            this.perosn_info = clsPerson.Find(this.person_id);
        }

        public static readonly Dictionary<string, string> filters_By = new Dictionary<string, string>
        {
            { "user_id", @"SELECT  Users.UserID,Users.PersonID,People.FirstName + ' ' + People.SecondName + ' ' + 
                             ISNULL(People.ThirdName, '') + ' ' + People.LastName AS FullName,
                             Users.UserName,Users.IsActive

                             FROM Users 
                             INNER JOIN People ON People.PersonID = Users.PersonID
                             WHERE UserID = @UserID"
            },

            { "username", @"SELECT  Users.UserID,Users.PersonID,People.FirstName + ' ' + People.SecondName + ' ' + 
                             ISNULL(People.ThirdName, '') + ' ' + People.LastName AS FullName,
                             Users.UserName,Users.IsActive

                             FROM Users 
                             INNER JOIN People ON People.PersonID = Users.PersonID
                             WHERE UserName LIKE '%' + @UserName + '%'" },

            { "person_id", @"SELECT  Users.UserID,Users.PersonID,People.FirstName + ' ' + People.SecondName + ' ' + 
                             ISNULL(People.ThirdName, '') + ' ' + People.LastName AS FullName,
                             Users.UserName,Users.IsActive

                             FROM Users 
                             INNER JOIN People ON People.PersonID = Users.PersonID
                             WHERE Users.PersonID = @PersonID"
            },

            { "fullname", @"SELECT * FROM 
                            (
                            SELECT  Users.UserID,Users.PersonID,People.FirstName + ' ' + People.SecondName + ' ' + 
                                    ISNULL(People.ThirdName, '') + ' ' + People.LastName AS FullName,
                                    Users.UserName,Users.IsActive

                                    FROM Users 
		                            INNER JOIN People ON People.PersonID = Users.PersonID

                            )virtualtable 
	                        WHERE  virtualtable.FullName LIKE '%' + @FullName + '%'"
            },

            { "is_active", @"SELECT  Users.UserID,Users.PersonID,People.FirstName + ' ' + People.SecondName + ' ' + 
                             ISNULL(People.ThirdName, '') + ' ' + People.LastName AS FullName,
                             Users.UserName,Users.IsActive

                             FROM Users 
                             INNER JOIN People ON People.PersonID = Users.PersonID
                             WHERE IsActive = @IsActive"
            },

            { "none", @"SELECT  Users.UserID,Users.PersonID,People.FirstName + ' ' + People.SecondName + ' ' + 
                             ISNULL(People.ThirdName, '') + ' ' + People.LastName AS FullName,
                             Users.UserName,Users.IsActive

                             FROM Users 
                             INNER JOIN People ON People.PersonID = Users.PersonID" 
            }
        };

        public static DataTable filter(string query, object filterValue)
        {
            return clsUserData.filter(query, filterValue);
        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (!IsUserExist(this.username))
                    {
                        if (_AddNewUser())
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
                    if (!IsUserExist(this.username))
                        return _UpdateUser();
                    else
                        return false;

            }




            return false;
        }

        private bool _AddNewUser()
        {


            this.id = clsUserData.AddNewUser(this.person_id,this.username,this. password,this.is_active);

            return (this.id != -1);
        }

        private bool _UpdateUser()
        {


            return clsUserData.UpdateUser(this.id,this.username,this.password,this.is_active);

        }

        public static clsUser Find(int id)
        {
            int perosn_id = -1;
            string username = "", password = "";
            bool is_active = false;
            
            

            if (clsUserData.GetuserInfoByID(id,ref username,ref password,ref is_active,ref perosn_id))
            {
                return new clsUser(id,perosn_id,username,password,is_active);
            }

                
            else
                return null;
        }
        
        public static clsUser Find(string username,string password)
        {

            bool is_active = false;
            int user_id = -1,perosn_id=-1;
            

            if (clsUserData.GetuserInfoByUsernameAndPassword(username,password,ref user_id,ref is_active,ref perosn_id))
            {
                return new clsUser(user_id, perosn_id,username, password, is_active);
            }


            else
                return null;
        }

        public static bool IsUserExist(int perosn_id)
        {
            return clsUserData.IsUserExist(perosn_id);
        }

        public static bool IsUserExist(string username)
        {
            return clsUserData.IsUserExist(username);
        }


        public static bool IsUserExist(string username, string password)
        {
            return clsUserData.IsUserExist(username,password);
        }

        public static bool DeleteUser(int id)
        {
           return clsUserData.DeleteUser(id);
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();

        }

        public static int GetUserCount()
        {
            return clsUserData.Count();
        }

        public static bool change_password(int user_id,string new_password)
        {
            return clsUserData.change_password(user_id,new_password);
        }
    }
}
