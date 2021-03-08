using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Cambium.MarsRover.Services;
using Cambium.MarsRover.Web.Exceptions;
using Cambium.MarsRover.Web.Helpers;
using Cambium.MarsRover.Web.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cambium.MarsRover.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private readonly ILogger<NavigationController> _logger;
        private readonly INavigationService _navigationService;
        private readonly IFileReaderHelper _fileReaderHelper;

        public FileController(ILogger<NavigationController> logger, INavigationService navigationService, IFileReaderHelper fileReaderHelper)
        {
            _logger = logger;
            _navigationService = navigationService;
            _fileReaderHelper = fileReaderHelper;
        }


        [HttpPost]
        public ActionResult Post([FromForm] RoverFiles file)
        {
            try
            {
                _navigationService.AssignPlateau(file.PlateauHeight, file.PlateauWidth);
                var fileBytes = file.ConvertToByteArray();
                var instructions = _fileReaderHelper.ReadInstructionsFile(fileBytes, file.FileName);
                var stringBuilder = new StringBuilder();
                stringBuilder.AppendLine(string.Format("for Plateau ( {0} , {1} )   File: {2} ", file.PlateauHeight,
                    file.PlateauWidth, file.FileName));

                stringBuilder.Append(_navigationService.ReceiveMultipleInstructions(instructions));
                /*foreach (var inst in instructions)
                {
                    stringBuilder.AppendLine("--> " + _navigationService.ReceiveInstructions(inst));
                }*/
                return Ok(stringBuilder.ToString());
            }
            catch (InvalidFileException e)
            {
                return BadRequest("Invalid File. Please Update a .csv file with 1 column named Instruction");
            }
        }
    }
}
