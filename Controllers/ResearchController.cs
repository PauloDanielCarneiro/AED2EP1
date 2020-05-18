using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ep1.Models;
using ep1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace ep1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResearchController : ControllerBase
    {
        private readonly ILogger<ResearchController> _logger;

        public ResearchController(ILogger<ResearchController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Dictionary<long, Research> placeList = new Dictionary<long, Research>();
            ProcessCsv.StartProcess(placeList);
            return Ok(placeList.ToList());
        }
    }
}