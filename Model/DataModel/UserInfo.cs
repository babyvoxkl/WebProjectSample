using System;
using System.Runtime.Serialization;

namespace Model.DataModel
{
    [DataContract]
    [Serializable]
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
