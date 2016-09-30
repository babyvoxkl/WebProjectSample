using System;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class ServiceResult
    {
        [DataMember]
        public int ErrorCode { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }
    }
}
