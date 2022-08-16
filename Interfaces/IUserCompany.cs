using TestMVCNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestMVCNetCore.Interfaces
{
    public interface IUserCompany
    {
        PaginatedList<UserCompany> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); 
        UserCompany GetItem(int id);
        UserCompany GetUserCompanybyAspNetUser_Id(string AspNetUser_Id);

        UserCompany Create(UserCompany userCompany);

        UserCompany Edit(UserCompany userCompany);

        UserCompany Delete(UserCompany userCompany);

        public bool IsItemExists(string name);
        public bool IsItemExists(string name, int Id);

        public int countUserbyCompany(int Comp_Id, string AspnetUser_Id, string RoleName);

        //public List<AspNetUserRolesVM> GetListUserRoles(string AspnetUser_Id);
        //public List<UserCompanyVM> GetListUsersCompany(int Comp_Id);

    }
}
