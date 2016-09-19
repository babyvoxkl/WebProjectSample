using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace WcfMicroService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service1.svc.cs，然后开始调试。
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(Name = "Service1",InstanceContextMode = InstanceContextMode.Single,Namespace = "MicroService")]
    public class Service1
    {
        [OperationContract]
        [WebGet(UriTemplate = "GetData/{value}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]

        public string GetData(int value)
        {
            return $"You entered: {value}";
        }

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException(nameof(composite));
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}
    }
}
