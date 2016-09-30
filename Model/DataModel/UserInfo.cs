using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Model.DataModel
{
    [DataContract]
    [Table("UserInfo")]
    public class UserInfo
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string UserCode { get; set; }
        [DataMember]
        public string UserName { get; set; }
    }
}
