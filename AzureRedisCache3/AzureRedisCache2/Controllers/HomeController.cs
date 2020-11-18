using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AzureRedisCache2.Models;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using AzureRedisCache2.Helpers;

namespace AzureRedisCache2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if ( RedisCacheHelper.GetDatabase() != null )
                return View( true );
            else
                return View( false );
        }

        public IActionResult SetSimpleComplexObject()
        {
            if ( RedisCacheHelper.GetDatabase() != null )
            {
                SampleObject sampleObject = new SampleObject
                {
                    Country = "Brazil",
                    Id = 7,
                    Name = "Mané"
                };
                RedisCacheHelper.Set( "test1", sampleObject );
            }
            return RedirectToActionPermanent( "Index" );
        }

        public IActionResult SetListComplexObject()
        {
            List<SampleObject> lstSampleObject = new List<SampleObject>();
            if ( RedisCacheHelper.GetDatabase() != null )
            {
                lstSampleObject.Add( new SampleObject
                {
                    Country = "Argentina",
                    Id = 1,
                    Name = "Maradona"
                } );
                lstSampleObject.Add( new SampleObject
                {
                    Country = "Portugal",
                    Id = 2,
                    Name = "Ronaldo"
                } );
                lstSampleObject.Add( new SampleObject
                {
                    Country = "Puskas",
                    Id = 3,
                    Name = "Hungary"
                } );
                RedisCacheHelper.Set( "test2", lstSampleObject );
            }
            return RedirectToActionPermanent( "Index" );
        }

        public IActionResult GetSimpleComplexObject()
        {
            SampleObject sampleObject = new SampleObject();

            if ( RedisCacheHelper.GetDatabase() != null )
            {
                sampleObject = RedisCacheHelper.Get<SampleObject>( "test1" );
            }
            return View( sampleObject );
        }

        public IActionResult GetListComplexObject()
        {
            List<SampleObject> lstSampleObject = new List<SampleObject>();

            if ( RedisCacheHelper.GetDatabase() != null )
            {
                lstSampleObject = RedisCacheHelper.Get<List<SampleObject>>( "test2" );
            }
            return View( lstSampleObject );
        }
    }
}