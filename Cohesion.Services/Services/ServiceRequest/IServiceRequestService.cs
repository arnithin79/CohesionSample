using System;
using System.Collections.Generic;
using ServiceRequestEntity = Cohesion.Entities.Entities.ServiceRequest;

namespace Cohesion.Services.Services.ServiceRequest
{
    public interface IServiceRequestService
    {
        List<ServiceRequestEntity> GetServiceRequests();

        ServiceRequestEntity GetById(Guid Id);
    }
}
