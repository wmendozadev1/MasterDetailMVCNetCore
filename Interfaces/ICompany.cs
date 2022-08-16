using TestMVCNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestMVCNetCore.Interfaces
{
    public interface ICompany
    {
        PaginatedList<Company> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5);
        Company GetItem(int id); 

        Company Create(Company unit);

        Company Edit(Company unit);

        Company Delete(Company unit);

        public bool IsItemExists(string name);
        public bool IsItemExists(string name, int Id);

        List<Company> GetListCompanybyId(int Comp_Id);
        List<Company> GetListCompany();

    }
}
