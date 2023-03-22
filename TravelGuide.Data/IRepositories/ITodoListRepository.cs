using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Domain.Entities;

namespace TravelGuide.Data.IRepositories
{
    public interface ITodoListRepository 
    {
        Task<ToDoList> InsertAsync(ToDoList todoList);
        Task<ToDoList> UpdateAsync(ToDoList todoList);
        Task<bool> DeleteAsync(long Id);
        Task<ToDoList> SelectAsync(Predicate<ToDoList> predicate);
        IQueryable<ToDoList> SelectAllAsync(Predicate<ToDoList> predicate);
    }


}
