using System;
using System.Collections.Generic;
using System.Linq;
using ServiceRequestEntity = Cohesion.Entities.Entities.ServiceRequest;


namespace Cohesion.Services.Services.FakeService
{
    public class FakeServiceRequestService : IFakeServiceRequestService
    {
        private List<ServiceRequestEntity> serviceRequests = new List<ServiceRequestEntity>
        {
            new ServiceRequestEntity{Id =  Guid.Parse("06FF04CA-0232-4A7D-BB96-698110392151"), BuildingCode = "COH", Description = "Test"}
        };

        public List<ServiceRequestEntity> GetAll()
        {
            return serviceRequests;
        }

        public ServiceRequestEntity GetById(Guid id)
        {
            return serviceRequests.FirstOrDefault(x => x.Id == id);
        }
    }
}
