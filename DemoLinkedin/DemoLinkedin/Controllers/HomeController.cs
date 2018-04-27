using DemoLinkedin.Common;
using DemoLinkedin.Helper;
using DemoLinkedin.Models;
using DemoLinkedin.Profiles;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace DemoLinkedin.Controllers
{
    public class HomeController : Controller
    {
        public static string ACCESS_TOKEN_STRING = string.Empty;

        public ActionResult Index()
        {
            var model = new IndexModel();
            if (string.IsNullOrEmpty(ACCESS_TOKEN_STRING))
            {
                return RedirectToAction("LinkedINAuth");
            }

            return View(InitIndexModel());
        }

        public ActionResult Default(string code, string state)
        {
            if (string.IsNullOrEmpty(ACCESS_TOKEN_STRING))
            {
                var data = new ClientData
                {
                    Method = HttpMethod.Post,
                    BaseURL = Consts.HOST_BASE_URL,
                    RelativeURL = Consts.ACCESS_TOKEN_URL,
                    PostData = new Dictionary<string, string>
                {
                    { "code", code },
                    { "grant_type", Consts.GRANT_TYPE },
                    { "redirect_uri", Consts.REDIRECT_URI },
                    { "client_id", Consts.CLIENT_ID },
                    { "client_secret", Consts.CLIENT_SECRET },
                },
                };
                var authCode = ClientHelper.SendRequest<AuthCode>(data);
                if (string.IsNullOrEmpty(authCode?.access_token))
                {
                    throw new Exception("Faild to get the access token");
                }

                ACCESS_TOKEN_STRING = authCode?.access_token;
            }

            IndexModel model = InitIndexModel();
            return View(nameof(Index), model);
        }

        public JsonResult PublishNewActivity(Activity activity)
        {
            activity.Comment = $"This is a test about Linkedin communicated with thrid APP. {activity.Comment}";
            string jsonString = string.Empty;

            JObject jsonObject;

            if (activity.Content != null)
            {
                jsonObject = new JObject
                {
                    { "comment", activity.Comment },
                    { "content", new JObject
                        {
                            { "title", activity.Content.Title},
                            { "description", activity.Content.Description},
                            { "submitted-url", activity.Content.SubmittedUrl},
                            { "submitted-image-url", activity.Content.SubmittedImageUrl},
                        }
                    },
                    { "visibility", new JObject
                        {
                            { "code", "anyone" },
                        }
                    }
                };
            }
            else
            {
                jsonObject = new JObject
                {
                    { "comment", activity.Comment },
                    { "visibility", new JObject
                        {
                            { "code", "anyone" },
                        }
                    }
                };
            }


            var data = new ClientData
            {
                Method = HttpMethod.Post,
                BaseURL = Consts.HOST_BASE_URL,
                RelativeURL = Consts.SHARES_URL,
                JsonPostData = jsonObject.ToString(),
                AccessToken = ACCESS_TOKEN_STRING,
            };

            var result = ClientHelper.SendRequest<object>(data);

            return new JsonResult
            {
                Data = true
            };
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult LinkedINAuth()
        {
            var scope = AuthorizationScope.ReadBasicProfile |
                AuthorizationScope.ReadEmailAddress |
                AuthorizationScope.ReadWriteCompanyPage |
                AuthorizationScope.WriteShare;
            //scope |= AuthorizationScope.ReadNetwork;

            var flags = Enum.GetValues(typeof(AuthorizationScope))
               .Cast<AuthorizationScope>()
               .Where(s => (scope & s) == s)
               .Select(s => s.GetAuthorizationName())
               .ToArray();
            var scopeAsString = string.Join(" ", flags);
            string urlWithPara = $"{Consts.HOST_BASE_URL}/{Consts.AUTHORIZATION_CODE_URL}?response_type={Consts.RESPONSE_TYPE}&client_id={Consts.CLIENT_ID}&redirect_uri={Consts.REDIRECT_URI}&state={Consts.State}&scope={Uri.EscapeDataString(scopeAsString)}";
            return Redirect(urlWithPara);
        }

        private IndexModel InitIndexModel()
        {
            var model = new IndexModel();
            if (string.IsNullOrEmpty(ACCESS_TOKEN_STRING))
            {
                return model;
            }

            var data = new ClientData
            {
                Method = HttpMethod.Get,
                BaseURL = Consts.API_BASE_URL,
                RelativeURL = "v1/people/~:(id,firstName,lastName,headline,num-connections,picture-url)?format=json",
                PostData = null,
                AccessToken = ACCESS_TOKEN_STRING
            };

            model.Profile = ClientHelper.SendRequest<Profile>(data);

            //data.RelativeURL = Consts.CONTACTS_URL;
            //Contacts contacts = ClientHelper.SendRequest<Contacts>(data);

            //data.RelativeURL = Consts.CONNECTIONS_URL;
            //Connections connections = ClientHelper.SendRequest<Connections>(data);

            try
            {

                //https://api.linkedin.com/v1/people/~/shares?format=json
                data.RelativeURL = "v1/people/~/shares?format=json";
                data.Method = HttpMethod.Post;
                JObject jsonObject = new JObject
                {
                    { "comment", "This is a test about communicate with linkedin via the third APP. It's no use crying over spilt milk, because all of the forces of the universe were bent on spilling it. W. Somerset Maugham" },
                    { "visibility", new JObject
                        {
                            { "code", "anyone" },
                        }
                    }
                };

                //data.JsonPostData = "{" +
                //    "\"comment\":\"There are three things I loved in this wrold, Sun, moon and you, Sun for morning, moon for night, and you for ever!\"" +
                //    ",\"visibility\":{" +
                //    "\"code\":\"anyone\"" +
                //    "}}";

                data.PostData = null;
                data.JsonPostData = jsonObject.ToString();
                //ClientHelper.SendRequest<object>(data);
            }
            catch (Exception)
            {

                throw;
            }


            //https://api.linkedin.com/v1/companies



            return model;
        }


    }
}