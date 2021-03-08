using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cambium.MarsRover.Services;
using Cambium.MarsRover.Services.Exceptions;
using Cambium.MarsRover.Web.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cambium.MarsRover.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NavigationController : ControllerBase
    {
        private readonly ILogger<NavigationController> _logger;
        private readonly INavigationService _navigationService;

        public NavigationController(ILogger<NavigationController> logger, INavigationService navigationService)
        {
            _logger = logger;
            _navigationService = navigationService;
        }

        [HttpPost]
        public string Post([FromBody] RoverInstructions roverInstructions)
        {
            var stringBuilder = new StringBuilder();

            _navigationService.AssignPlateau(roverInstructions.PlateauHeight, roverInstructions.PlateauWidth);
            stringBuilder.AppendLine(string.Format("for Plateau ( {0} , {1} )", roverInstructions.PlateauHeight,
                roverInstructions.PlateauWidth));
            stringBuilder.AppendLine("-->" + _navigationService.ReceiveInstructions(roverInstructions.Instructions));
            return stringBuilder.ToString();

        }

    }
}