using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SSTFU_V2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SSTFU_V2.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace SSTFU_V2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EFDBContext eFDBContext;
        //private readonly EUser currentUser;

        public HomeController(ILogger<HomeController> logger, EFDBContext eFDBContext)
        {
            _logger = logger;
            this.eFDBContext = eFDBContext;
        }

        public async Task<IActionResult> Index()
        {
            //DEV
           await PrefillPlaces();
            //DEV

            var mod = new HomeViewModel();
            mod.RentPlaces = eFDBContext.RentPlaces.ToList<ERentPlace>();
            mod.SportObjects = eFDBContext.SportObjects.ToList<ESportObject>();

            if(User.Identity.IsAuthenticated)
            mod.currentUser = await (from e in eFDBContext.Users where e.Token == User.Identity.Name select e).FirstOrDefaultAsync();

            return View(mod);
        }

        public async Task PrefillPlaces()
        {
           
            if (eFDBContext.SportObjects.Count<ESportObject>() == 0)
            {
                EObjectCategory oc1 = new EObjectCategory()
                {
                    Name = "Футбольный стадион"
                };
                eFDBContext.ObjectCategories.Add(oc1);

                EObjectCategory oc2 = new EObjectCategory()
                {
                    Name = "Баскетбольная площадка"
                };
                eFDBContext.ObjectCategories.Add(oc2);

                EObjectCategory oc3 = new EObjectCategory()
                {
                    Name = "Каток"
                };
                eFDBContext.ObjectCategories.Add(oc3);

                EObjectCategory oc4 = new EObjectCategory()
                {
                    Name = "Пустырь с кустами и пеньками"
                };
                eFDBContext.ObjectCategories.Add(oc4);

                ESportObject s1 = new ESportObject()
                {
                    Name = "Стадион Заря",
                    Description = "Спортивный объект,  оборудованный по последнему слову техники",
                    Address = "Спортивная 21",
                    ObjectCategory=oc1,
                    MaxMinRentalUnitsType=0,
                    MinRentalTime=1,
                    MaxRentalTime=10,
                    ImageLink = "",
                    MaxPerson=100
                };
                eFDBContext.SportObjects.Add(s1);
                ESportObject s2 = new ESportObject()
                {
                    Name = "Каток ЛЁД",
                    Description = "Спортивный объект,  оборудованный по последнему слову техники",
                    Address = "Спортивная 22",
                    ObjectCategory=oc2,
                    MaxMinRentalUnitsType = 0,
                    MinRentalTime = 1,
                    MaxRentalTime = 10,
                    ImageLink = "",
                    MaxPerson = 100
                };
                eFDBContext.SportObjects.Add(s2);
                ESportObject s3 = new ESportObject()
                {
                    Name = "Стадион Рассвет",
                    Description = "Спортивный объект,  оборудованный по последнему слову техники",
                    Address = "Спортивная 23",
                    ObjectCategory=oc1,
                    MaxMinRentalUnitsType = 0,
                    MinRentalTime = 1,
                    MaxRentalTime = 10,
                    ImageLink = "",
                    MaxPerson = 100
                };
                eFDBContext.SportObjects.Add(s3);


               
            }
            if(eFDBContext.RentPlaces.Count<ERentPlace>()==0)
            {
                ERentPlace r1 = new ERentPlace()
                {
                    Name = "Прокат самокатов",
                    Description = "Здесь можно взять самокат на прокат",
                    Address = "Самокатная 11",
                };
                eFDBContext.RentPlaces.Add(r1);

                ERentPlace r2 = new ERentPlace()
                {
                    Name = "Прокат велосипедов",
                    Description = "Здесь можно взять велосипед на прокат",
                    Address = "Педальная 31",
                };
                eFDBContext.RentPlaces.Add(r2);

                ERentPlace r3 = new ERentPlace()
                {
                    Name = "Прокат лыж",
                                    Description = "Здесь можно взять лыжи на прокат",
                    Address = "Лыжная 41",
                };
                eFDBContext.RentPlaces.Add(r3);


                ERentPlace r4 = new ERentPlace()
                {
                    Name = "Прокат сноубордов",
                    Description = "Здесь можно взять сноуборд на прокат",
                    Address = "Спусковая 12",
                };
                eFDBContext.RentPlaces.Add(r4);

                ERentPlace r5 = new ERentPlace()
                {
                    Name = "Прокат коньков",
                    Description = "Здесь можно взять коньки на прокат",
                    Address = "Конькобежная 56",
                };
                eFDBContext.RentPlaces.Add(r5);
            }
            await eFDBContext.SaveChangesAsync();

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
