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
    public class CompanyRepo : ICompany
    {
        private readonly TestMVCNetCoreContext _context; 
        public CompanyRepo(TestMVCNetCoreContext context) 
        {
            _context = context;
        }

        public Company Create(Company company)
        {
            _context.Company.Add(company);
            _context.SaveChanges();
            return company;
        }


        public Company Delete(Company company)
        {
            _context.Company.Attach(company);
            _context.Entry(company).State = EntityState.Deleted;
            _context.SaveChanges();
            return company;
        }


        public Company Edit(Company company)
        {
            _context.Company.Attach(company);
            _context.Entry(company).State = EntityState.Modified;
            _context.SaveChanges();
            return company;
        }


        private List<Company> DoSort(List<Company> items, string SortProperty, SortOrder sortOrder)
        {

            if (SortProperty.ToLower() == "Comp_Name")
            {
                if (sortOrder == SortOrder.Ascending)
                    items = items.OrderBy(n => n.Comp_Name).ToList();
                else
                    items = items.OrderByDescending(n => n.Comp_Name).ToList();
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


        public PaginatedList<Company> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
        {
            List<Company> items;

            if (SearchText != "" && SearchText != null)
            {
                items = _context.Company.Where(n => n.Comp_Name.Contains(SearchText)) //|| n.Description.Contains(SearchText)
                    .ToList();
            }
            else
                items = _context.Company.ToList();

            items = DoSort(items, SortProperty, sortOrder);

            PaginatedList<Company> retItems = new PaginatedList<Company>(items, pageIndex, pageSize);

            return retItems;
        }


        public Company GetItem(int id)
        {
            Company item = _context.Company.Where(u => u.Comp_Id == id).FirstOrDefault();
            return item;
        }


        public bool IsItemExists(string name)
        {
            int ct = _context.Company.Where(n => n.Comp_Name.ToLower() == name.ToLower()).Count();
            if (ct > 0)
                return true;
            else
                return false;
        }


        public bool IsItemExists(string name, int Id)
        {
            int ct = _context.Company.Where(n => n.Comp_Name.ToLower() == name.ToLower() && n.Comp_Id != Id).Count();
            if (ct > 0)
                return true;
            else
                return false;
        }

        public List<Company> GetListCompanybyId(int Comp_Id)
        {
            List<Company> items;

            items = _context.Company.Where(n => n.Comp_Id == Comp_Id && n.Comp_Active==true).OrderBy(a => a.Comp_Name).ToList();

            return items;
        }

        public List<Company> GetListCompany()
        {
            List<Company> items;

            items = _context.Company.Where(n => n.Comp_Active == true).OrderBy(a => a.Comp_Name).ToList();

            return items;
        }
    }

}
