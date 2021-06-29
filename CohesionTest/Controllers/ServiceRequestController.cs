using Cohesion.Entities.Entities;
using Cohesion.Services.Services.ServiceRequest;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CohesionTest.Controllers
{
    [Route("api/servicerequest")]
    [ApiController]
    public class ServiceRequestController : ControllerBase
    {
        private IServiceRequestService _serviceRequestService;

        public ServiceRequestController(IServiceRequestService serviceRequestService)
        {
            _serviceRequestService = serviceRequestService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetServiceRequests()
        {
            List<ServiceRequest> serviceRequests = _serviceRequestService.GetServiceRequests();
            if(serviceRequests.Count > 0)
            {
                return Ok(serviceRequests);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetServiceRequestById(Guid id)
        {
            ServiceRequest serviceRequest = _serviceRequestService.GetById(id);
            if(serviceRequest != null)
            {
                return Ok(serviceRequest);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
