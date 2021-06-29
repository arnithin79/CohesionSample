using Cohesion.Base.Enums;
using Cohesion.Services.Repositories.BaseRepository;
using Cohesion.Services.Services.EmailService;
using System;
using System.Collections.Generic;
using System.Linq;
using ServiceRequestEntity = Cohesion.Entities.Entities.ServiceRequest;

namespace Cohesion.Services.Services.ServiceRequest
{
    public class ServiceRequestService : IServiceRequestService
    {
        private IRepository<ServiceRequestEntity> _serviceRequestRepository;
        private IEmailService _emailService;

        public ServiceRequestService(IRepository<ServiceRequestEntity> serviceRequestRepository,
            IEmailService emailService)
        {
            _serviceRequestRepository = serviceRequestRepository;
            _emailService = emailService;
        }

        public List<ServiceRequestEntity> GetServiceRequests()
        {
            return _serviceRequestRepository.GetAll().ToList();
        }

        public ServiceRequestEntity GetById(Guid Id)
        {
            return _serviceRequestRepository.GetById(Id);
        }

        public ServiceRequestEntity CreateNewServiceRequest(ServiceRequestEntity serviceRequest)
        {
            serviceRequest.CreatedDate = DateTime.Now;
            serviceRequest.LastModifiedDate = DateTime.Now;
            serviceRequest.Id = Guid.NewGuid(); //We have to set Id rather than from UI or from end point
            serviceRequest = _serviceRequestRepository.Create(serviceRequest);
            if(serviceRequest.CurrentStatus == CurrentStatus.Complete)
            {
                _emailService.SendMail();
            }
            return serviceRequest;
        }

        public bool UpdateServiceRequest(Guid Id, ServiceRequestEntity serviceRequest)
        {
            ServiceRequestEntity existingRequest = _serviceRequestRepository.GetById(Id);
            if (existingRequest != null)
            {
                existingRequest.BuildingCode = serviceRequest.BuildingCode;
                existingRequest.Description = serviceRequest.Description;
                existingRequest.CurrentStatus = serviceRequest.CurrentStatus;
                existingRequest.LastModifiedBy = serviceRequest.LastModifiedBy;
                existingRequest.LastModifiedDate = DateTime.Now;
                _serviceRequestRepository.Update(existingRequest);

                if (existingRequest.CurrentStatus == CurrentStatus.Complete)
                {
                    _emailService.SendMail();
                }
                return true;
            }
            return false;
        }

        public bool DeleteServiceRequest(Guid Id)
        {
            return _serviceRequestRepository.Delete(Id);
        }
    }
}
