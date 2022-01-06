using Navigation.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Navigation.API.Repositories
{
    public interface IMenuRepository
    {
        Task<Menu> GetMenu(int id);
        Task<Menu> CreateMenu(Menu menu);
        Task UpdateMenu(Menu menu);
        Task DeleteMenu(int id);
    }
}
