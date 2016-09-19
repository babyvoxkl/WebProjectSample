using System.Runtime.Serialization;
using Model.DataModel;

namespace Model.ServiceModel
{
    [DataContract]
    public class GetUserInfoResult : ServiceResult
    {
        [DataMember]
        public UserInfo UserInfo { get; set; }
    }
}
