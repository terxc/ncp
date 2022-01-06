using Microsoft.EntityFrameworkCore;
using Navigation.API.Data;
using Navigation.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Navigation.API.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly DataContext _dbContext;

        public MenuRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Menu> GetMenu(int id)
        {
            return await _dbContext.Menus.FindAsync(id);
        }
        public async Task<Menu> CreateMenu(Menu menu)
        {
            _dbContext.Menus.Add(menu);
            await _dbContext.SaveChangesAsync();
            return menu;
        }
        public async Task UpdateMenu(Menu menu)
        {
            _dbContext.Entry(menu).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteMenu(int id)
        {
            var menuToDelete = await _dbContext.Menus.FindAsync(id);
            _dbContext.Menus.Remove(menuToDelete);
            await _dbContext.SaveChangesAsync();
        }
    }
}
