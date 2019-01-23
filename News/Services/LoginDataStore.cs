using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using News.Models;
using System.Linq;

[assembly: Xamarin.Forms.Dependency(typeof(News.Services.LoginDataStore))]
namespace News.Services
{
    public class LoginDataStore : IDataStore<UserInfo>
    {
        List<UserInfo> userInfo;
        
        public LoginDataStore()
        {
            UserInfo user = new UserInfo() { UserId = 1, UserName = "admin@m.com", Password = "1qaz2@" };
            userInfo = new List<UserInfo>();
            userInfo.Add(user);
        }

        public async Task<bool> AddItemAsync(UserInfo item)
        {
            userInfo.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            int intId = Convert.ToInt32(id);
            var _item = userInfo.Where((UserInfo arg) => arg.UserId == intId).FirstOrDefault();
            userInfo.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<UserInfo> GetItemAsync(string id)
        {
            int intId = Convert.ToInt32(id);
            return await Task.FromResult(userInfo.FirstOrDefault(s => s.UserId == intId));
        }

        public async Task<IEnumerable<UserInfo>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(userInfo);
        }

        public async Task<bool> UpdateItemAsync(UserInfo item)
        {
            var _item = userInfo.Where((UserInfo arg) => arg.UserId == item.UserId).FirstOrDefault();
            userInfo.Remove(_item);
            userInfo.Add(item);

            return await Task.FromResult(true);
        }


    }
}
