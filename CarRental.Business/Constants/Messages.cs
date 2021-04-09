using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Constants
{
    public static class Messages
    {
        public static string BrandAdded = "Brand successfully added.";
        public static string BrandDeleted = "Brand successfully deleted.";
        public static string BrandUpdated = "Brand successfully updated.";

        public static string ColorAdded = "Color successfully added.";
        public static string ColorDeleted = "Color successfully deleted.";
        public static string ColorUpdated = "Color successfully updated.";

        public static string CarAdded = "Car successfull added.";
        public static string CarUpdated = "Car successfull updated.";
        public static string CarDeleted = "Car successfull deleted.";

        public static string UserAdded = "User successfully added.";
        public static string UserUpdated = "User successfully updated.";
        public static string UserDelete = "User successfully deleted.";

        public static string AuthorizationDenied = "Authorization Denied";

        public static string UserRegistered = "User succesfully registered.";
        public static string UserNotFound = "User not found.";
        public static string UserPasswordError = "User password error.";
        public static string UserLoginSuccess = "User login success.";
        public static string UserAlreadyExists = "User already exist.";

        public static string AccessTokenCreated = "Token created.";
    }
}
