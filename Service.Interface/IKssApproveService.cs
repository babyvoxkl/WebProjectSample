using System.ServiceModel;
using System.ServiceModel.Web;
using Model;

namespace Service
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IKssApproveService
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "GetApproveList", ResponseFormat = WebMessageFormat.Json, Method = "GET")]
        GetApproveListResponse GetApproveListService(GetApproveListRequest request);
    }
}
