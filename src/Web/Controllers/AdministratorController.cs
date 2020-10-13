﻿using ApplicationCoreInterface.Services;
using Microsoft.AspNetCore.Mvc;
using Web.Filters;
using Web.Models.AdministratorModels;

namespace Web.Controllers
{
    [Route("api/administrators")]
    [ServiceFilter(typeof(AuthorizationAttributeFilter))]
    public class AdministratorController : Controller
    {
        private IAdministratorService _administratorService;

        public AdministratorController(IAdministratorService administratorService)
        {
            _administratorService = administratorService;
        }

        [HttpPost]
        public IActionResult CreateAdministrator([FromBody] AdministratorCreatingModel administratorModel)
        {
            var adminToReturn = new AdministratorBaseCreateModel(_administratorService.Add(administratorModel.ToEntity()));
            return Ok(adminToReturn);
        }
    }
}