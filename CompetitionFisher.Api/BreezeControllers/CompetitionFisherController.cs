﻿using Breeze.ContextProvider;
using Breeze.ContextProvider.EF6;
using Breeze.WebApi2;
using CompetitionFisher.Data;
using CompetitionFisher.Data.Entities;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Web.Http;

namespace CompetitionFisher.Api.BreezeControllers
{
    [BreezeController]
    public class CompetitionFisherController : ApiController
    {

        EFContextProvider<CfContext> _contextProvider = new EFContextProvider<CfContext>();

        public CompetitionFisherController()
        {
            _contextProvider.BeforeSaveEntityDelegate += beforeSaveEntity;
        }
        private bool beforeSaveEntity(EntityInfo entityInfo)
        {
            if (entityInfo.Entity.GetType() == typeof(Competitor))
            {
                var competior = (Competitor)entityInfo.Entity;
                //if (fisherman.Zip == "22222") throw new ArgumentException("22222 is an invalid zip code");
            }
            //return CustomerLogic.OnSaveCustomer((Customer)entityInfo.Entity);
            return true;
        }

        //private Dictionary<Type, List<EntityInfo>> beforeSaveEntities(Dictionary<Type, List<EntityInfo>> entityInfos)
        //{
        //    if (entityInfos.ContainsKey(typeof(Order)))
        //    {
        //        var orders = entityInfos[typeof(Order)];
        //        var orderTotal = 0m;
        //        orders.ForEach(o => orderTotal += ((Order)o.Entity).ItemsTotal);
        //        if (orderTotal > 10.0m)
        //            throw new ArgumentException("Order total exceeds single call policy");
        //    }
        //    return entityInfos;
        //}

        [HttpGet]
        public string Metadata()
        {
            return _contextProvider.Metadata();
        }

        [HttpPost]
        public SaveResult SaveChanges(JObject bundle)
        {
            return _contextProvider.SaveChanges(bundle);
        }

        [HttpGet]
        //[EnableBreezeQuery(AllowedQueryOptions = AllowedQueryOptions.All & ~(AllowedQueryOptions.OrderBy | AllowedQueryOptions.Top | AllowedQueryOptions.Skip))]
        //[EnableBreezeQuery(MaxExpansionDepth = 1)]
        public IQueryable<Competitor> Competitors()
        {
            //var user = ClaimsPrincipal.Current.Identity.Name;
            //// Lookup state that user is responsible for
            //var userState = "MO";
            //return _contextProvider.Context.Customers.Where(c => c.State == userState);
            return _contextProvider.Context.Competitors;
        }

        [HttpGet]
        public IQueryable<ApplicationUser> Users()
        {
            return _contextProvider.Context.Users;
        }

        [HttpGet]
        public IQueryable<Competition> Competitions()
        {
            return _contextProvider.Context.Competitions;
        }

        [HttpGet]
        public object Lookups()
        {
            return new
            {
                //OrderStatuses = _contextProvider.Context.OrderStatuses,
                //ProductOptions = _contextProvider.Context.ProductOptions,
                //ProductSizes = _contextProvider.Context.ProductSizes
            };
        }
    }
}
