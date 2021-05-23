using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SSTFU_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SSTFU_V2.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace SSTFU_V2.Controllers
{
    public class LocationProfileController : Controller
    {
        // GET: LocationProfileController
        private readonly ILogger<HomeController> _logger;
        private readonly EFDBContext eFDBContext;
        //private readonly EUser currentUser;

        public LocationProfileController(ILogger<HomeController> logger, EFDBContext eFDBContext)
        {
            _logger = logger;
            this.eFDBContext = eFDBContext;
        }

        public async Task<ActionResult> Index(int Id,int OTM)
        {
            var model = new LocationProfileViewModel()
            {
                TypeMarker = OTM,
            };
            if (OTM==0)
            {
                var so = await (from s in eFDBContext.SportObjects.Include(o=>o.ObjectCategory) where s.Id == Id select s).FirstOrDefaultAsync();
                model.sportObject = so;
            }
            else
            {
                var rp = await (from r in eFDBContext.RentPlaces where r.Id == Id select r).FirstOrDefaultAsync();
                model.rentPlace = rp;
            }

            
            return View(model);
        }

    }
}
