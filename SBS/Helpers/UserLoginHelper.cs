using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SBS.Models;

namespace SBS.Helpers
{
    public static class UserLoginHelper
    {
        public static UserModel UserModel;

        public static SBS.Controllers.LoginStates TryLogin(SBS.Models.LoginViewModel userModel)
        {
            try
            {
                using (var db = new DB.SBSEntities())
                {
                    var user = (from u in db.Users
                        join ld in db.LoginData on u.LoginDataId equals ld.Id
                        join ur in db.UserRights on u.UsersRightId equals ur.Id
                        where ld.Login == userModel.UserName
                        select new
                        {
                            Id = u.Id,
                            Name = u.Name,
                            Login = ld.Login,
                            Password = ld.Password,
                            RightId = ur.Id,
                            LastVisitDate = ld.LastVisitDate
                        }).ToList().LastOrDefault();

                    if (user != null)
                    {
                        UserModel = new UserModel();
                        UserModel.Id = user.Id;
                        UserModel.Name = user.Name;
                        UserModel.LastVisitDate = user.LastVisitDate;
                        UserModel.Login = user.Login;
                        UserModel.Password = user.Password;
                        UserModel.Right = (Models.UserRights) user.RightId;

                        if (IsPasswordEquals(userModel.Password))
                        {
                            return SBS.Controllers.LoginStates.Ok;
                        }
                        else return SBS.Controllers.LoginStates.Failed;
                    }
                    else return SBS.Controllers.LoginStates.Failed;
                }
            }
            catch (Exception exception)
            {
                return SBS.Controllers.LoginStates.Failed;
            }
        }

        public static bool IsPasswordEquals(string passwordInput)
        {
            if (PasswordHelper.Crypt.EncryptString(passwordInput.Trim()) == UserModel.Password)
            {
                return true;
            }
            else return false;
        }
    }
}