using TestMVCNetCore.Context;
using TestMVCNetCore.Interfaces;
using TestMVCNetCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestMVCNetCore.CustomRepository
{
    public class UserCompanyRepo : IUserCompany
    {
        private readonly TestMVCNetCoreContext _context; 
        public UserCompanyRepo(TestMVCNetCoreContext context) 
        {
            _context = context;
        }

        public UserCompany Create(UserCompany userCompa)
        {
            _context.UserCompany.Add(userCompa);
            _context.SaveChanges();
            return userCompa;
        }


        public UserCompany Delete(UserCompany userCompa)
        {
            _context.UserCompany.Attach(userCompa);
            _context.Entry(userCompa).State = EntityState.Deleted;
            _context.SaveChanges();
            return userCompa;
        }


        public UserCompany Edit(UserCompany userCompa)
        {
            _context.UserCompany.Attach(userCompa);
            _context.Entry(userCompa).State = EntityState.Modified;
            _context.SaveChanges();
            return userCompa;
        }


        private List<UserCompany> DoSort(List<UserCompany> items, string SortProperty, SortOrder sortOrder)
        {

            if (SortProperty.ToLower() == "UserComp_Id")
            {
                if (sortOrder == SortOrder.Ascending)
                    items = items.OrderBy(n => n.UserComp_Id).ToList(); //Act_Id
                else
                    items = items.OrderByDescending(n => n.UserComp_Id).ToList(); //Act_Id
            }
            //else
            //{
            //    if (sortOrder == SortOrder.Ascending)
            //        items = items.OrderBy(d => d.Description).ToList();
            //    else
            //        items = items.OrderByDescending(d => d.Description).ToList();
            //}

            return items;
        }


        public PaginatedList<UserCompany> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
        {
            List<UserCompany> items;

            if (SearchText != "" && SearchText != null)
            {
                items = _context.UserCompany.Where(n => n.UserComp_Id.ToString().Contains(SearchText)) //|| n.Description.Contains(SearchText)
                    .ToList();
            }
            else
                items = _context.UserCompany.ToList();

            items = DoSort(items, SortProperty, sortOrder);

            PaginatedList<UserCompany> retItems = new PaginatedList<UserCompany>(items, pageIndex, pageSize);

            return retItems;
        }


        public UserCompany GetItem(int id)
        {
            UserCompany item = _context.UserCompany.Where(u => u.UserComp_Id == id).FirstOrDefault();
            return item;
        }
        public UserCompanyVM GetUserCompany(int id)
        {
            UserCompanyVM item = _context.UserCompanyVM.Where(u => u.UserComp_Id == id).FirstOrDefault();
            return item;
        }

        public UserCompany GetUserCompanybyAspNetUser_Id(string AspNetUser_Id)
        {
            UserCompany item = _context.UserCompany.Where(u => u.AspNetUser_Id == AspNetUser_Id).FirstOrDefault();
            return item;
        }

        public bool IsItemExists(string name)
        {
            int ct = _context.UserCompany.Where(n => n.AspNetUser_Id.ToLower() == name.ToLower()).Count();
            if (ct > 0)
                return true;
            else
                return false;
        }


        public bool IsItemExists(string name, int Id)
        {
            int ct = _context.UserCompany.Where(n => n.AspNetUser_Id.ToLower() == name.ToLower() && n.Comp_Id != Id).Count();
            if (ct > 0)
                return true;
            else
                return false;
        }



        //public List<AspNetUserRolesVM> GetListUserRoles( string AspnetUser_Id)
        //{
        //    List<AspNetUserRolesVM> items;

        //    items = _context.AspNetUserRolesVM.Where(n => n.UserId == AspnetUser_Id) //|| n.Description.Contains(SearchText)
        //            .ToList();

        //    return items;
        //}

        //public AspNetUserRolesVM GetRolUserCompanybyAspNetUser_Id(string AspNetUser_Id)
        //{
        //    AspNetUserRolesVM item = _context.AspNetUserRolesVM.Where(u => u.UserId == AspNetUser_Id).FirstOrDefault();
        //    return item;
        //}


        public int countUserbyCompany(int Comp_Id, string AspnetUser_Id, string RoleName)
        {
            int count = 0;// _context.UserCompany.Where(u => u.UserComp_Active == true && u.Comp_Id == Comp_Id).Count();
         

            if (RoleName.Equals(Rol_Names.Rol_Administrador))
            {

                count = _context.UserCompany.Where(t => t.Comp_Id == Comp_Id).Count();//.Select(i => Convert.ToDouble(i.TotalSales)).Sum();
            }
            else if (RoleName.Equals(Rol_Names.Rol_User))
            {

                count = _context.UserCompany.Where(t => t.Comp_Id == Comp_Id).Count();
            }
        

            return count;
        }

        //public List<UserCompanyVM> GetListUsersCompany(int Comp_Id)//, string AspnetUser_Id, string RoleName)
        //{
        //    List<UserCompanyVM> listPrizeTypeGameTabulatorVM;
        //    List<UserCompanyVM> listDropDown = new List<UserCompanyVM>();

         
        //    listPrizeTypeGameTabulatorVM = _context.UserCompanyVM.Where(n => n.Comp_Id == Comp_Id ).OrderBy(a => a.Act_Name).ToList();
        //    foreach (var item in listPrizeTypeGameTabulatorVM)
        //    {

        //        UserCompanyVM uc = new UserCompanyVM();
        //        uc = GetUserCompany(item.UserComp_Id);

        //        uc.FullName = item.FullName;

        //        AspNetUserRolesVM rolesUser = new AspNetUserRolesVM();
        //        rolesUser = GetRolUserCompanybyAspNetUser_Id(uc.AspNetUser_Id);

        //        if (rolesUser.Rol_Name.Equals(Rol_Names.Rol_Taquillero))
        //        {
        //            listDropDown.Add(uc);
        //        }

        //    }

        //    return listDropDown;


        //}


    }
}
