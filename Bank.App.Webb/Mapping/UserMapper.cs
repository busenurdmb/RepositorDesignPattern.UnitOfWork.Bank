using Bank.App.Webb.Data.Entities;
using Bank.App.Webb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.App.Webb.Mapping
{
    //bir takım methodllar yazıcaz bize liste gelicek entity olarak
    /// <summary>
    /// //gelen listeyi viewe çeviricez
    /// </summary>
    public class UserMapper:IUserMapper
    {
        public List<UserListModel> MapToListOfUserList(List<ApplicationUser> users)
        {
            return users.Select(x => new UserListModel
            {
                ApplicationUserId=x.ApplicationUserId,
                Name=x.Name,
                Surname=x.Surname
            }).ToList();
        }
        public UserListModel MapToUserList(ApplicationUser user)
        {
            return  new UserListModel
            {
                ApplicationUserId = user.ApplicationUserId,
                Name = user.Name,
                Surname = user.Surname
            };
        }
        public ApplicationUser Map(UserListModel model)
        {
            return new ApplicationUser
            {
                Name = model.Name,
                Surname = model.Surname,
            };
        }
    }
}
