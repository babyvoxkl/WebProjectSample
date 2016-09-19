using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Model.DataModel;

namespace BizLogic
{
    public class UserInfoBl
    {
        private readonly UserInfoDa _da;

        public UserInfoBl()
        {
            _da = new UserInfoDa();
        }

        public void AddUserInfo(UserInfo userInfo)
        {
            _da.AddUserInfo(userInfo);
        }

        public void UpdateUserInfo(UserInfo userInfo)
        {
            _da.UpdateUserInfo(userInfo);
        }

        public void DeleteUserInfo(int id)
        {
            _da.DeleteUserInfo(id);
        }

        public UserInfo GetUserInfo(int id)
        {
            return _da.GetUserInfo(id);
        }

        public List<UserInfo> GetUserinfoList()
        {
            return _da.GetUserInfoList();
        } 
    }
}
