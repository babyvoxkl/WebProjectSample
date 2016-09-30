using System.ServiceModel;
using System.ServiceModel.Web;
using Model.DataModel;
using Model.ServiceModel;

namespace WcfRstService
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        [WebGet(UriTemplate = "UserInfo/GetUserInfoList", ResponseFormat = WebMessageFormat.Json)]
        GetUserInfoListResult GetUserInfoList();

        [OperationContract]
        [WebGet(UriTemplate = "UserInfo/GetUserInfoById/{id}", ResponseFormat = WebMessageFormat.Json)]
        GetUserInfoResult GetUserInfoById(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "UserInfo/AddUserInfo", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        void AddUserInfo(UserInfo userInfo);

        [OperationContract]
        [WebInvoke(UriTemplate = "UserInfo/UpdateUserInfo", Method = "PUT", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        void UpdateUserInfo(UserInfo userInfo);

        [OperationContract]
        [WebInvoke(UriTemplate = "UserInfo/DeleteUserInfo/{id}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
        void DeleteUserInfo(string id);
    }
}
