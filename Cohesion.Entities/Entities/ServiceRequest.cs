using Cohesion.Base.Enums;
using Cohesion.Base.Utils;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Text.Json.Serialization;

namespace Cohesion.Entities.Entities
{
    public class ServiceRequest : BaseEntity
    {
        public string BuildingCode { get; set; }

        public string Description { get; set; }

        [RequiredEnumField(ErrorMessage = "Enter valid current Status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CurrentStatus CurrentStatus { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime LastModifiedDate { get; set; }
    }
}
