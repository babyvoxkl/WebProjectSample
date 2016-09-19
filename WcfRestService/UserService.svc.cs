using System;
using BizLogic;
using Model;
using Model.DataModel;
using Model.ServiceModel;
using WcfRestService.Interface;

namespace WcfRstService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service1.svc.cs，然后开始调试。
    public class UserService : IUserService
    {
        public ServiceResult AddUserInfo(UserInfo userInfo)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                UserInfoBl bl = new UserInfoBl();
                bl.AddUserInfo(userInfo);
                result.ErrorCode = 1;
                result.ErrorMessage = "用户添加成功";
            }
            catch (Exception ex)
            {
                result.ErrorCode = 0;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public ServiceResult DeleteUserInfo(string id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                int intId;
                if (int.TryParse(id,out intId))
                {
                    UserInfoBl bl = new UserInfoBl();
                    bl.DeleteUserInfo(intId);
                    result.ErrorCode = 1;
                    result.ErrorMessage = "用户删除成功";
                }
                else
                {
                    result.ErrorCode = 0;
                    result.ErrorMessage = "用户ID不是数字";
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = 0;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public GetUserInfoResult GetUserInfoById(string id)
        {
            GetUserInfoResult result = new GetUserInfoResult();
            try
            {
                int intId;
                if (int.TryParse(id, out intId))
                {
                    UserInfoBl bl = new UserInfoBl();
                    result.UserInfo = bl.GetUserInfo(intId);
                    result.ErrorCode = 1;
                    result.ErrorMessage = "用户获取成功";
                }
                else
                {
                    result.ErrorCode = 0;
                    result.ErrorMessage = "用户ID不是数字";
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = 0;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public GetUserInfoListResult GetUserInfoList()
        {
            GetUserInfoListResult result = new GetUserInfoListResult();

            try
            {
                UserInfoBl bl = new UserInfoBl();
                result.UserInfoList = bl.GetUserinfoList();
                result.ErrorCode = 1;
                result.ErrorMessage = "用户列表获取成功";
            }
            catch (Exception ex)
            {
                result.ErrorCode = 0;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public ServiceResult UpdateUserInfo(UserInfo userInfo)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                UserInfoBl bl = new UserInfoBl();
                bl.AddUserInfo(userInfo);
                result.ErrorCode = 1;
                result.ErrorMessage = "用户更新成功";
            }
            catch (Exception ex)
            {
                result.ErrorCode = 0;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
    }
}
