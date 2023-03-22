using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Data.Contexts;
using TravelGuide.Data.IRepositories;
using TravelGuide.Domain.Entities;

namespace TravelGuide.Data.Repositories
{
    public class TodolistRepository : ITodoListRepository
    {
        private readonly AppDbContext appDbCOntext = new AppDbContext();

        public async Task<ToDoList> InsertAsync(ToDoList todolist)
        {
            EntityEntry<ToDoList> entity = await appDbCOntext.ToDoLists.AddAsync(todolist);
            await appDbCOntext.SaveChangesAsync();
            return entity.Entity;
        }
        
        public async Task<ToDoList> UpdateAsync(ToDoList todolist)
        {
            EntityEntry<ToDoList> entity = appDbCOntext.ToDoLists.Update(todolist);
            await appDbCOntext.SaveChangesAsync();
            return entity.Entity;
        }

        public async Task<bool> DeleteAsync(long Id)
        {
            var entity = await appDbCOntext.ToDoLists.FirstOrDefaultAsync(todolist => todolist.Id.Equals(Id));
            if (entity is null)
            {
                return false;
            }
            appDbCOntext.ToDoLists.Remove(entity);
            await appDbCOntext.SaveChangesAsync();
            return true;
        }

        public IQueryable<ToDoList> SelectAllAsync(Predicate<ToDoList> predicate = null)
        {
            if (predicate is null)
            {
                return appDbCOntext.ToDoLists;
            }
            return this.appDbCOntext.ToDoLists.AsEnumerable().Where(todolist => predicate(todolist)).AsQueryable();
        }
        public async Task<ToDoList> SelectAsync(Predicate<ToDoList> predicate)
        {
            var todolists = await appDbCOntext.ToDoLists.ToListAsync();
            return todolists.FirstOrDefault(todolist => predicate(todolist));
        }
    }
}
