using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserGroupSite.Api.ViewModels;
using UserGroupSite.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserGroupSite.Api.Controllers
{
    [Route("api/[controller]")]
    public class LocationsController : Controller
    {
        private ApplicationDbContext DbContext { get; }
        private IMapper Mapper { get; }
        public LocationsController(ApplicationDbContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]LocationInputViewModel viewModel)
        {
            var locationToAdd = Mapper.Map<Location>(viewModel);

            DbContext.Locations.Add(locationToAdd);
            await DbContext.SaveChangesAsync();

            return Ok(Mapper.Map<LocationViewModel>(locationToAdd));
        }
    }
}
