using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace MSH.LogSystem.Models
{
    public class UserPrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }

        public User CurrentUserInfo { get; set; }

        //public List<DTO.ObjectOperationPermission> Permissions { get; set; }

        public string Token { get; set; }

        public UserPrincipal(User userInfo)
        {
            this.CurrentUserInfo = userInfo;
            this.Identity = new GenericIdentity(userInfo.Code);
        }

        public bool IsInRole(string role)
        {
            return true;
        }
    }
}