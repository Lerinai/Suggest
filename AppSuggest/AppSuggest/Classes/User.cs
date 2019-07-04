using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LinqToDB;
using System.Data.Linq;

namespace AppSuggest
{
    public class User
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _firstName;

        public string firstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        private string _lastName;
            
        public string lastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        private string _email;

        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _image;

        public string image
        {
            get { return _image; }
            set { _image = value; }
        }

        private string _password;

        public string password
        {
            get { return _password; }
            set { _password = value; }
        }



        public List<User> friendList;

        public List<Movie> toDoList;

        public List<Movie> doneMovie;

        public User()
        {
            DataContext db = new DataContext(@"c:\linqtest5\northwnd.mdf"); // db link

            // received user session 
            
            //ID = ; requete id
            //email = ; requete email
            //firstName = ; requete firstname
            //lastName = ; requete lastname 
        }



    }
}
