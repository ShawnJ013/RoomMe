﻿using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using RoomMe.Api.Providers;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(RoomMe.Api.Startup))]
namespace RoomMe.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            ConfigureOAuth(app);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }
            public void ConfigureOAuth(IAppBuilder app)
        {
            var authorizationOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/users/login"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new LocalAuthorizationProvider()
            };

            var authenticationOptions = new OAuthBearerAuthenticationOptions();

            app.UseOAuthAuthorizationServer(authorizationOptions);
            app.UseOAuthBearerAuthentication(authenticationOptions);
        }
    }
    }


