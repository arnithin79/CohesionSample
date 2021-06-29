using System;
using System.Collections.Generic;
using ServiceRequestEntity = Cohesion.Entities.Entities.ServiceRequest;

namespace Cohesion.Services.Services.ServiceRequest
{
    public interface IServiceRequestService
    {
        List<ServiceRequestEntity> GetServiceRequests();

        ServiceRequestEntity GetById(Guid Id);

        ServiceRequestEntity CreateNewServiceRequest(ServiceRequestEntity serviceRequest);

        bool UpdateServiceRequest(Guid Id, ServiceRequestEntity serviceRequest);

        bool DeleteServiceRequest(Guid Id);
    }
}
