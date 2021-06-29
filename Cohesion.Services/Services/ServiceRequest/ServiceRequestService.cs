using Cohesion.Services.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using ServiceRequestEntity = Cohesion.Entities.Entities.ServiceRequest;

namespace Cohesion.Services.Services.ServiceRequest
{
    public class ServiceRequestService : IServiceRequestService
    {
        private IRepository<ServiceRequestEntity> _serviceRequestRepository;

        public ServiceRequestService(IRepository<ServiceRequestEntity> serviceRequestRepository)
        {
            _serviceRequestRepository = serviceRequestRepository;
        }

        public List<ServiceRequestEntity> GetServiceRequests()
        {
            return _serviceRequestRepository.GetAll().ToList();
        }

        public ServiceRequestEntity GetById(Guid Id)
        {
            return _serviceRequestRepository.GetById(Id);
        }
    }
}
