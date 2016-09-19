using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Model.DataModel;

namespace Model.ServiceModel
{
    [DataContract]
    [Serializable]
    public class GetUserInfoListResult : ServiceResult
    {
        [DataMember]
        public List<UserInfo> UserInfoList { get; set; }
    }
}
