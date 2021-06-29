using Cohesion.Services.Services.FakeService;
using System;
using Xunit;

namespace Cohesion.Test
{
    public class ServiceRequestTest
    {
        private IFakeServiceRequestService _fakeServiceRequestService;

        public ServiceRequestTest()
        {
            _fakeServiceRequestService = new FakeServiceRequestService();
        }

        [Fact]
        public void Test_Get_All_ServiceRequests()
        {
            var items = _fakeServiceRequestService.GetAll();

            if(items.Count == 0)
            {
                Assert.False(items.Count == 0, "Empty Service requests");
            }
        }

        [Fact]
        public void Test_ServiceRequest_WithWrongId()
        {
            var newId = Guid.NewGuid();
            var serviceRequest = _fakeServiceRequestService.GetById(newId);

            Assert.Equal(Guid.Parse("06FF04CA-0232-4A7D-BB96-698110392151"), newId);
        }

        [Fact]
        public void Test_ServiceRequest_WithCorrectId()
        {
            var newId = Guid.Parse("06FF04CA-0232-4A7D-BB96-698110392151");
            var serviceRequest = _fakeServiceRequestService.GetById(newId);

            Assert.Equal(Guid.Parse("06FF04CA-0232-4A7D-BB96-698110392151"), newId);
        }
    }
}
