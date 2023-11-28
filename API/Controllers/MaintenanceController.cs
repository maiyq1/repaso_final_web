using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Request;
using API.Response;
using AutoMapper;
using Data;
using Data.Model;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceController : ControllerBase
    {
        private IMaintenanceData _maintenanceData;
        private IMaintenanceActivityDomain _maintenanceActivityDomain;
        private IMapper _mapper;
        
        public MaintenanceController(IMapper mapper, IMaintenanceActivityDomain maintenanceActivityDomain,IMaintenanceData maintenanceData)
        {
            _maintenanceData = maintenanceData;
            _maintenanceActivityDomain = maintenanceActivityDomain;
            _mapper = mapper;
        }
        
        // GET: api/Maintenance
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        /*
        // GET: api/Maintenance/uwu
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        */

        // POST: api/Maintenance
        [HttpPost]
        public ActionResult<MaintenanceRequest> Post([FromBody] MaintenanceRequest maintenanceRequest)
        {
            var maintenance = _mapper.Map<MaintenanceRequest, MaintenanceActivity>(maintenanceRequest);
            if (_maintenanceActivityDomain.create(maintenance))
            {
                return _mapper.Map<MaintenanceActivity, MaintenanceRequest>(maintenance);
            }

            return StatusCode(404);
        }

        // PUT: api/Maintenance/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Maintenance/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
