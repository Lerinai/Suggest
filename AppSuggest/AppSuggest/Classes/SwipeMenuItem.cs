using System;
using System.Collections.Generic;
using System.Text;

namespace AppSuggest.Classes
{
    public enum MenuItemType
    {
        Feed,
        Browse,
        Friends,
        Profile,
        Settings,
        About,
        //Logout
    }
    class SwipeMenuItem
    {
        public MenuItemType Id { get; set; }
        public string Title { get; set; }
    }
}
