using System;
using System.Collections.Generic;
using ServiceRequestEntity = Cohesion.Entities.Entities.ServiceRequest;

namespace Cohesion.Services.Services.FakeService
{
    public interface IFakeServiceRequestService
    {
        List<ServiceRequestEntity> GetAll();

        ServiceRequestEntity GetById(Guid id);
    }
}
