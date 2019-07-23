using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AppSuggest
{
    class DataBase: DbContext
    {
        private string _dbWay;

        public string dbWay
        {
            get { return _dbWay; }
            set { _dbWay = value; }
        }

        public DataBase()
        {
            dbWay = "http://137.74.118.171/phpmyadmin";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(" + dbWay + ");Database=Blogging;Integrated Security=True");
        }
    }
}
