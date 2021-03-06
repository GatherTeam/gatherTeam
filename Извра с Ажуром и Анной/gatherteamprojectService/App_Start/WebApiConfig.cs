﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using gatherteamprojectService.DataObjects;
using gatherteamprojectService.Models;

namespace gatherteamprojectService
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            // config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            
            Database.SetInitializer(new gatherteamprojectInitializer());
        }
    }

    public class gatherteamprojectInitializer : ClearDatabaseSchemaIfModelChanges<gatherteamprojectContext>
    {
        protected override void Seed(gatherteamprojectContext context)
        {
            List<GameAddress> todoItems = new List<GameAddress>
            {
                new GameAddress {Id="nooo", GameFieldAddressString = "TestfromWeb", GameFieldX = 10f, GameFieldY = 15f}
//                new GameAddress { id = Guid.NewGuid().ToString(), Text = "Second item ololo", Complete = false },
            };

            foreach (GameAddress todoItem in todoItems)
            {
                context.Set<GameAddress>().Add(todoItem);
            }

            base.Seed(context);
        }
    }
}

