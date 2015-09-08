using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Web.Http;
using fabianitdevcon15.DataObjects;
using fabianitdevcon15.Models;
using Microsoft.WindowsAzure.Mobile.Service;
using AutoMapper;

namespace fabianitdevcon15
{
    public static class WebApiConfig
    {

        public static void Register()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                // Define a map from the database type TodoItem to 
                // client type MobileTodoItem. Used when getting data.
                cfg.CreateMap<TodoItem, MobileToDoItem>()
                         .ForMember(MobileToDoItem => MobileToDoItem.OnMobileDevice,
                    map => map.UseValue(true))
                         .ForMember(MobileToDoItem => MobileToDoItem.IsFinished,
                   map => map.MapFrom(todoItem => todoItem.Complete));
                // Define a map from the client type to the database
                // type. Used when inserting and updating data.
                cfg.CreateMap<MobileToDoItem, TodoItem>()
                        .ForMember(todoItem => todoItem.Complete,
                    map => map.MapFrom(mobileTodoItem => mobileTodoItem.IsFinished));
            });

            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            // config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            Database.SetInitializer(new MobileServiceInitializer());
        }
    }

    public class MobileServiceInitializer : DropCreateDatabaseIfModelChanges<MobileServiceContext>
    {
        protected override void Seed(MobileServiceContext context)
        {
            List<TodoItem> todoItems = new List<TodoItem>
            {
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "First item", Complete = false },
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Second item", Complete = false },
            };

            foreach (TodoItem todoItem in todoItems)
            {
                context.Set<TodoItem>().Add(todoItem);
            }

            base.Seed(context);
        }
    }
}

