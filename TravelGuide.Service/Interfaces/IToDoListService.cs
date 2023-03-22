using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Domain.Entities;
using TravelGuide.Service.DTOs;
using TravelGuide.Service.Helpers;

namespace TravelGuide.Service.Interfaces
{
    public interface IToDoListService
    {
        Task<Responce<ToDoList>> CreateAsync(ToDoListCreationDto list);
        Task<Responce<ToDoList>> UpdateAsync(Predicate<ToDoList> predicate, ToDoListCreationDto list);
        Task<Responce<bool>> DeleteAsync(Predicate<ToDoList> predicate);
        Task<Responce<ToDoList>> GetAsync(Predicate<ToDoList> predicate);
        Task<Responce<List<ToDoList>>> GetAllAsync(Predicate<ToDoList> predicate = null);
    }
}
