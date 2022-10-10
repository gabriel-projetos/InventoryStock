using Interface.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Stock.Models
{
    public class CourseUserRegister : BaseData, ICourseUserRegister
    {
        [JsonProperty("user_uid")]
        public Guid UserUid { get; set; }

        [JsonProperty("access_status")]
        public ContentStatus AccessStatus { get; set; }
        
        [JsonProperty("register_status")]
        public UserRegisterStatus RegisterStatus { get; set; }

        [JsonProperty("completed_at")]
        public DateTime? CompletedAt { get; set; }

        [JsonProperty("register_uid")]
        public Guid DbRegisterUid { get; set; }
    }
}
