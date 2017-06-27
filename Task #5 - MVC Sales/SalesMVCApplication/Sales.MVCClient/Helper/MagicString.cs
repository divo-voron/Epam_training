using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sales.MVCClient.Helper
{
    public static class MagicString
    {
        public const string PathAccountDataBase = "SalesAccountDataBaseContext";
        public const string PathSalesDataBase = "SalesDataBaseContext";

        public const string RolesAdmin = "admin";
        public const string RolesUser = "user";

        public const string ErrorWrongLoginOrPassword = "Wrong login or password";
        public const string ErrorNoMore50CharactersInString = "The length of the string must be no more than 50 characters";

        public const string DisplayPassword = "Password";
        public const string DisplayConfirmPassword = "Confirm password";

        public const string DisplayUserName = "Name";
        public const string DisplayUserUserName = "Username";
        public const string DisplayUserEmail = "E-mail";
        public const string DisplayUserAddress = "Home adress";
        public const string DisplayUserRoles = "Access roles";

        public const string DisplayClientIndex = "Clients";
        public const string DisplayClientCreate = "Add client";
        public const string DisplayClientEdit = "Edit client";
        public const string DisplayClientDetails = "Details by client";
        public const string DisplayClientDelete = "Remove client";
        public const string DisplayClientName = "Name of client";

        public const string DisplayManagerIndex = "Managers";
        public const string DisplayManagerCreate = "add manager";
        public const string DisplayManagerEdit = "Edit manager";
        public const string DisplayManagerDetails = "Details by manager";
        public const string DisplayManagerDelete = "Remove manager";
        public const string DisplayManagerName = "Name of manager";

        public const string DisplayProductIndex = "Products";
        public const string DisplayProduct = "Product";
        public const string DisplayDateSetPrice = "Price setting date";
        public const string DisplayProductPrice = "Price of the product";
        public const string DisplayProductName = "Product name";

        public const string DisplayOperationDate = "Date of operation";
        public const string DisplayOperationManager = "Manager";
        public const string DisplayOperationClient = "Client";
        public const string DisplayOperationProduct = "Product";
        public const string DisplayOperationPrice = "Price";

        public const string DisplayOperationLabel = "Options";
        public const string DisplayOperationLabelEdit = "Edit";
        public const string DisplayOperationLabelDetails = "Details";
        public const string DisplayOperationLabelDelete = "Delete";
    }
}