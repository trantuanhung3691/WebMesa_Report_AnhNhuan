using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;

namespace QuanLyNhanSu.Web.Api.Modules
{
    public class BasicAuthHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            // Register event handlers
            context.AuthenticateRequest += OnApplicationAuthenticateRequest;
            context.EndRequest += OnApplicationEndRequest;
        }

        private static void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }

        private static bool AuthenticateUser(string credentials)
        {
            var encoding = Encoding.GetEncoding("utf-8");
            credentials = encoding.GetString(Convert.FromBase64String(credentials));
            var credentialsArray = credentials.Split(':');
            if (credentialsArray.Length < 3)
            {
                return false;
            }
            var username = credentialsArray[0];
            var password = credentialsArray[1];
            var timeexpire = credentialsArray[2].Replace("_", ":");
            var time = DateTime.Parse(timeexpire);
            if (DateTime.Now > time)
            {
                return false;
            }
            // change to md5
            var md5code = Commons.Securitys.CalculateMD5Hash(password);
            var user =new QuanLyNhanSu.Dao.AccountDao().Login(username, md5code);
            if (user == null)
            {
                return false;
            }
            var identity = new GenericIdentity(username);
            SetPrincipal(new GenericPrincipal(identity, null));
            return true;
        }

        private static void OnApplicationAuthenticateRequest(object sender, EventArgs e)
        {
            var request = HttpContext.Current.Request;
            var authHeader = request.Headers["Authorization"];
            if (authHeader != null)
            {
                var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);
                if (authHeaderVal.Scheme.Equals("Basic", StringComparison.OrdinalIgnoreCase) && authHeaderVal.Parameter != null)
                {
                    AuthenticateUser(authHeaderVal.Parameter);
                }
            }
        }

        // If the request was unauthorized, add the WWW-Authenticate header 
        // to the response.
        private static void OnApplicationEndRequest(object sender, EventArgs e)
        {
            var response = HttpContext.Current.Response;
            if (response.StatusCode == 401)
            {
                response.Headers.Add("WWW-Authenticate", "Access Denied");
            }
        }

        public void Dispose()
        {
        }
    }
}