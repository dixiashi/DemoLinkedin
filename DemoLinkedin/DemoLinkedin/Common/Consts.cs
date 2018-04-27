using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoLinkedin.Common
{
    public class Consts
    {

        public const string HOST_BASE_URL = "https://www.linkedin.com/";
        public const string API_BASE_URL = "https://api.linkedin.com/";


        public const string RESPONSE_TYPE = "code";
        public const string GRANT_TYPE = "authorization_code";
        public const string REDIRECT_URI = "http://10.172.50.148:57143/Home/Default";
        public const string CLIENT_ID = "77e8mfrek1rocm";
        public const string CLIENT_SECRET = "gLGupqxdEDpOOIPT";


        public const string AUTHORIZATION_CODE_URL = "oauth/v2/authorization";
        public const string ACCESS_TOKEN_URL = "oauth/v2/accessToken";
        public const string BASIC_PROFILE_URL = "v1/people/~?format=json";

        public const string CONNECTIONS_URL = "v1/people/~/connections?format=json";
        public const string CONTACTS_URL = "v1/contacts?format=json";
        public const string COMPANIES_URL = "v1/companies?format=json";

        

        public const string BY_DOMAIN = "email-domain=apple.com";
        public const string SHARES_URL = "v1/people/~/shares?format=json";
        public const string COMPANIES_URL3 = "v1/companies?format=json";
        public const string COMPANIES_URL4 = "v1/companies?format=json";
        public const string COMPANIES_URL5 = "v1/companies?format=json";

        //https://api.linkedin.com/v1/companies?email-domain=apple.com

        //public const string ACCESS_TOKEN_STRING = "AQUstwdWHGyb-LaB60BZdRkHj1ULbx_mPQDgqOOrN_c7agkCpn9SitLgQlDehHfuC11rLsjHa1UBAO-yEn3HZeelsm6yXajym-mE4CWiLGQ9OF-X91OGYsBVh426rGFroORPegU-TISgLfcagQxmkIVFq7q54Xo4i9SVJ9fUo-Ir-KtwqIkQPrZPLEKsTw3Ldt5sDobPRLzFbS5J0uhKM0BJfMSuBWHzoTHkfGaCLToVu1Bv7MZvtLLDZZyaVX0hs5Rc4J6mTXhCnVy_wPkVObTRmzQ_ZMPXl6j9t2M5dHngx_Rc2UQ5NXvz7lc8QWh4L7ux9MXaGOGeND51Cr7qFXjZbSF9Eg";


        public static string State { get { return Guid.NewGuid().ToString(); } }



    }
}