using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace WebApiService.Core.Models
{
    public class ClientPrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }

        public Platform CurrentUserInfo { get; set; }
        
        public string AppId { get; set; }

        public ClientPrincipal(Platform userInfo)
        {
            this.CurrentUserInfo = userInfo;
            this.Identity = new GenericIdentity(userInfo.AppId);
        }

        public bool IsInRole(string role)
        {
            return true;
        }
    }
}