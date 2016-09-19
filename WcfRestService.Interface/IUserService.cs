using System.ServiceModel;
using System.ServiceModel.Web;
using Model;
using Model.DataModel;
using Model.ServiceModel;

namespace WcfRestService.Interface
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        [WebGet(UriTemplate = "GetUserInfoList", ResponseFormat = WebMessageFormat.Json)]
        GetUserInfoListResult GetUserInfoList();

        [OperationContract]
        [WebGet(UriTemplate = "GetUserInfoById/{id}", ResponseFormat = WebMessageFormat.Json)]
        GetUserInfoResult GetUserInfoById(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "AddUserInfo/{userInfo}", Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
        ServiceResult AddUserInfo(UserInfo userInfo);

        [OperationContract]
        [WebInvoke(UriTemplate = "UpdateUserInfo/{userInfo}", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        ServiceResult UpdateUserInfo(UserInfo userInfo);

        [OperationContract]
        [WebInvoke(UriTemplate = "DeleteUserInfo/{id}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
        ServiceResult DeleteUserInfo(string id);
    }
}
