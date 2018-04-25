using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charts.Models;
using Microsoft.AspNetCore.Mvc;

namespace Charts.Controllers
{
    public class ChartsController : Controller
    {
        private Random rnd = new Random();

        public IActionResult Bar()
        {
            //list of department
            var lstModel = new List<SimpleReportViewModel>();
            lstModel.Add( new SimpleReportViewModel
            {
                DimensionOne = "Technology",
                Quantity = rnd.Next( 10 )
            } );
            lstModel.Add( new SimpleReportViewModel
            {
                DimensionOne = "Sales",
                Quantity = rnd.Next( 10 )
            } );
            lstModel.Add( new SimpleReportViewModel
            {
                DimensionOne = "Marketing",
                Quantity = rnd.Next( 10 )
            } );
            lstModel.Add( new SimpleReportViewModel
            {
                DimensionOne = "Human Resource",
                Quantity = rnd.Next( 10 )
            } );
            lstModel.Add( new SimpleReportViewModel
            {
                DimensionOne = "Research and Development",
                Quantity = rnd.Next( 10 )
            } );
            lstModel.Add( new SimpleReportViewModel
            {
                DimensionOne = "Acconting",
                Quantity = rnd.Next( 10 )
            } );
            lstModel.Add( new SimpleReportViewModel
            {
                DimensionOne = "Support",
                Quantity = rnd.Next( 10 )
            } );
            lstModel.Add( new SimpleReportViewModel
            {
                DimensionOne = "Logistics",
                Quantity = rnd.Next( 10 )
            } );
            return View( lstModel );
        }

        public IActionResult Line()
        {
            //list of countries
            var lstModel = new List<SimpleReportViewModel>();
            lstModel.Add( new SimpleReportViewModel
            {
                DimensionOne = "Brazil",
                Quantity = rnd.Next( 10 )
            } );
            lstModel.Add( new SimpleReportViewModel
            {
                DimensionOne = "USA",
                Quantity = rnd.Next( 10 )
            } );
            lstModel.Add( new SimpleReportViewModel
            {
                DimensionOne = "Portugal",
                Quantity = rnd.Next( 10 )
            } );
            lstModel.Add( new SimpleReportViewModel
            {
                DimensionOne = "Russia",
                Quantity = rnd.Next( 10 )
            } );
            lstModel.Add( new SimpleReportViewModel
            {
                DimensionOne = "Ireland",
                Quantity = rnd.Next( 10 )
            } );
            lstModel.Add( new SimpleReportViewModel
            {
                DimensionOne = "Germany",
                Quantity = rnd.Next( 10 )
            } );
            return View( lstModel );
        }

        public IActionResult Pie()
        {
            //list of drinks
            var lstModel = new List<SimpleReportViewModel>();
            lstModel.Add( new SimpleReportViewModel
            {
                DimensionOne = "Beer",
                Quantity = rnd.Next( 10 )
            } );
            lstModel.Add( new SimpleReportViewModel
            {
                DimensionOne = "Wine",
                Quantity = rnd.Next( 10 )
            } );
            lstModel.Add( new SimpleReportViewModel
            {
                DimensionOne = "Whisky",
                Quantity = rnd.Next( 10 )
            } );
            lstModel.Add( new SimpleReportViewModel
            {
                DimensionOne = "Water",
                Quantity = rnd.Next( 10 )
            } );
            return View( lstModel );
        }

        public IActionResult Stacked()
        {
            var lstModel = new List<StackedViewModel>();
            //sales of product sales by quarter
            lstModel.Add( new StackedViewModel
            {
                StackedDimensionOne = "First Quarter",
                LstData = new List<SimpleReportViewModel>()
                {
                    new SimpleReportViewModel()
                    {
                        DimensionOne="TV",
                        Quantity = rnd.Next(10)
                    },
                    new SimpleReportViewModel()
                    {
                        DimensionOne="Games",
                        Quantity = rnd.Next(10)
                    },
                    new SimpleReportViewModel()
                    {
                        DimensionOne="Books",
                        Quantity = rnd.Next(10)
                    }
                }
            } );
            lstModel.Add( new StackedViewModel
            {
                StackedDimensionOne = "Second Quarter",
                LstData = new List<SimpleReportViewModel>()
                {
                    new SimpleReportViewModel()
                    {
                        DimensionOne="TV",
                        Quantity = rnd.Next(10)
                    },
                    new SimpleReportViewModel()
                    {
                        DimensionOne="Games",
                        Quantity = rnd.Next(10)
                    },
                    new SimpleReportViewModel()
                    {
                        DimensionOne="Books",
                        Quantity = rnd.Next(10)
                    }
                }
            } );
            lstModel.Add( new StackedViewModel
            {
                StackedDimensionOne = "Third Quarter",
                LstData = new List<SimpleReportViewModel>()
                {
                    new SimpleReportViewModel()
                    {
                        DimensionOne="TV",
                        Quantity = rnd.Next(10)
                    },
                    new SimpleReportViewModel()
                    {
                        DimensionOne="Games",
                        Quantity = rnd.Next(10)
                    },
                    new SimpleReportViewModel()
                    {
                        DimensionOne="Books",
                        Quantity = rnd.Next(10)
                    }
                }
            } );
            lstModel.Add( new StackedViewModel
            {
                StackedDimensionOne = "Fourth Quarter",
                LstData = new List<SimpleReportViewModel>()
                {
                    new SimpleReportViewModel()
                    {
                        DimensionOne="TV",
                        Quantity = rnd.Next(10)
                    },
                    new SimpleReportViewModel()
                    {
                        DimensionOne="Games",
                        Quantity = rnd.Next(10)
                    },
                    new SimpleReportViewModel()
                    {
                        DimensionOne="Books",
                        Quantity = rnd.Next(10)
                    }
                }
            } );
            return View( lstModel );
        }
    }
}