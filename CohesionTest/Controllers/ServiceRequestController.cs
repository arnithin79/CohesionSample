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

        [HttpPost]
        [Route("")]
        public IActionResult CreateServiceRequest(ServiceRequest serviceRequest)
        {
            serviceRequest = _serviceRequestService.CreateNewServiceRequest(serviceRequest);
            if(serviceRequest != null)
            {
                return Created(typeof(ServiceRequestController).Name, serviceRequest.Id);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateServiceRequest(Guid id, ServiceRequest serviceRequest)
        {
            if(id == Guid.Empty || serviceRequest == null || serviceRequest.Id == Guid.Empty)
            {
                return BadRequest();
            }

            bool isServiceRequestUpdated = _serviceRequestService.UpdateServiceRequest(id, serviceRequest);
            if(isServiceRequestUpdated)
            {
                return Ok("Updated Service Request");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteServiceRequest(Guid id)
        {
            bool isServiceRequestDeleted = _serviceRequestService.DeleteServiceRequest(id);
            if(isServiceRequestDeleted)
            {
                return Created("DeleteServiceRequest", "Successfully deleted service request");
            }
            return NotFound();
        }
    }
}
