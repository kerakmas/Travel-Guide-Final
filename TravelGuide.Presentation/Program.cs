
using TravelGuide.Data.Repositories;
using TravelGuide.Domain.Entities;
using TravelGuide.Domain.Enums;
using TravelGuide.Service.DTOs;
using TravelGuide.Service.Repositories;


namespace TravelGuide.Presentation
{
    class Program
    {
        static async Task Main(string[] args)
        {
            UserService userService = new UserService();
            GenericRepository<City> cityRepository = new GenericRepository<City>();
            GenericRepository<ToDoList> toDoListRepository = new GenericRepository<ToDoList>();
            while (true)
            {
                Console.WriteLine(" \t\t\tWelcome to TravelGuide!\t\t\t");
                Console.WriteLine("Click 1 to register");
                Console.WriteLine("Click 2 to login");
                Console.WriteLine("*********************************************");
                Console.WriteLine("*********************************************");

                int n = int.Parse(Console.ReadLine());
                if (n == 1)
                {
                    Console.Write("Enter your first name: ");
                    string firstname = Console.ReadLine();
                    Console.Write("Enter your last name: ");
                    string lastname = Console.ReadLine();
                    Console.Write("Enter your email: ");
                    string email = Console.ReadLine();
                    Console.Write("Enter your password: ");
                    string password = Console.ReadLine();
                    Console.Write("Enter your city: ");
                    string city = Console.ReadLine();
                    Console.Write("Enter your count of days: ");
                    int countOfDays = int.Parse(Console.ReadLine());
                    Console.Write("Enter your count of members: ");
                    int countOfMembers = int.Parse(Console.ReadLine());

                    UserCreationDto userCreationDto = new UserCreationDto()
                    {
                        FirstName = firstname,
                        LastName = lastname,
                        Email = email,
                        Password = password,
                        CityName = city,
                        CountOfDays = countOfDays,
                        CountOfMembers = countOfMembers
                    };
                    var res = await userService.CreateAsync(userCreationDto);
                    if (res.StatusCode == 200)
                    {
                        Console.WriteLine("You have successfully registered!");
                    }
                    else
                    {
                        Console.WriteLine("You have already registered!");
                        Console.WriteLine("Please login!");
                    }

                }
                if (n == 2)
                {
                    Console.Write("Enter your email: ");
                    string email = Console.ReadLine();
                    Console.Write("Enter your password: ");
                    string password = Console.ReadLine();
                    var res = await userService.GetByIdAsync(x => x.Email == email && x.Password == password);
                    if (res.StatusCode == 200)
                    {
                        var city = await cityRepository.GetByIdAsync(x => x.Name == res.Value.CityName);
                        Console.WriteLine("You have successfully logged in!");
                        Console.WriteLine("Welcome " + res.Value.FirstName + " " + res.Value.LastName);
                        Console.WriteLine("Your city is " + res.Value.CityName);
                        Console.WriteLine("Your count of days is " + res.Value.CountOfDays);
                        Console.WriteLine("Your count of members is " + res.Value.CountOfMembers);
                        Console.WriteLine("*********************************************");
                        Console.WriteLine("*********************************************");
                        Console.WriteLine($"Click 1 to see all retaurants in  {res.Value.CityName} ");
                        Console.WriteLine($"Click 2 to see all TravelTips in  {res.Value.CityName} ");
                        Console.WriteLine($"Click 3 to see all attractions in  {res.Value.CityName} ");
                        Console.WriteLine($"Click 4 to see all toDoList");
                        int n1 = int.Parse(Console.ReadLine());
                        if (n1 == 1)
                        {
                            foreach (var item in city.Restaraunts)
                            {
                                Console.WriteLine($"Name: {item.Name}");
                                Console.WriteLine($"Location: {item.Location}");
                                Console.WriteLine($"Contact Number: {item.ContactNumber}");
                                foreach (var detail in item.Menus)
                                {
                                    Console.WriteLine($"Meal Name {detail.MealName}");
                                    Console.WriteLine($"Meal Type {detail.TypeMeal}");
                                    Console.WriteLine($"Meal Price {detail.Price}");

                                }



                            }
                            Console.WriteLine("*********************************************");
                            Console.WriteLine("*********************************************");
                            Console.WriteLine("Enter information about your restaurant to add it to your ToDoList");
                            Console.Write("Enter Number of Day: ");
                            int num = int.Parse(Console.ReadLine());
                            Console.Write("Enter day of week in Capital Letters: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter Name of Restaurant: ");
                            string nameOfRestaurant = Console.ReadLine();
                            Console.Write("Enter how many hours you will spend in restaurant: ");
                            int hours = int.Parse(Console.ReadLine());
                            Console.Write("Enter your comment: ");
                            string comment = Console.ReadLine();
                            ToDoListCreationDto toDoListCreationDto = new ToDoListCreationDto()
                            {
                                CityName = res.Value.CityName,
                                UserId = res.Value.Id,
                                NumberOfDay = num,
                                HoursSpend = hours,
                                Comment = comment,
                                TripStatus = StausOfTrip.uncompleated,
                                PlaceType = TypePlace.restaraunt,
                                DayOfWeek = WeekDays.MONDAY

                            };
                            Review s = new Review()
                            {
                                PlacceType = TypePlace.restaraunt,
                                Comment = comment,
                                Id = res.Value.Id,
                                Rating = Status.exelent,

                            };
                            var review = new GenericRepository<Review>();
                            await review.CreateAsync(s);
                            TodolistService todolistService = new TodolistService();
                            var res1 = await todolistService.CreateAsync(toDoListCreationDto);
                            if (res1.StatusCode == 200)
                            {
                                Console.WriteLine("You have successfully added to your to do list");
                            }
                            else
                            {
                                Console.WriteLine("You have already added this attraction to your to do list");
                            }




                        }
                        else if (n1 == 2)
                        {
                            foreach (var item in city.TravelTips)
                            {
                                Console.WriteLine($"Tittle: {item.Name}");
                                Console.WriteLine($"Description: {item.Description}");

                            }
                        }
                        else if (n1 == 3)
                        {
                            foreach (var item in city.Attractions)
                            {
                                Console.WriteLine($"Name: {item.Name}");
                                Console.WriteLine($"Location: {item.Location}");
                                Console.WriteLine($"Contact Number: {item.Contact}");
                                Console.WriteLine($"Description: {item.Description}");
                                Console.WriteLine($"Price: {item.TicketPrice}");

                            }

                            Console.WriteLine("*********************************************");
                            Console.WriteLine("*********************************************");
                            Console.WriteLine("Enter information about your attraction to ad to your to do list");
                            Console.Write("Enter Number of Day: ");
                            int num = int.Parse(Console.ReadLine());
                            Console.Write("Enter day of week in Capital Letters: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter Name of Attraction: ");
                            string nameOfRestaurant = Console.ReadLine();
                            Console.Write("Enter how many hours you will spend in Attracttion: ");
                            int hours = int.Parse(Console.ReadLine());
                            Console.Write("Enter your comment: ");
                            string comment = Console.ReadLine();
                            ToDoListCreationDto toDoListCreationDto = new ToDoListCreationDto()
                            {
                                CityName = res.Value.CityName,
                                UserId = res.Value.Id,
                                NumberOfDay = num,
                                HoursSpend = hours,
                                Comment = comment,
                                TripStatus = StausOfTrip.uncompleated,
                                PlaceType = TypePlace.attraction,
                                DayOfWeek = WeekDays.TUESDAY

                            };
                            Review review1 = new Review()
                            {
                                PlacceType = TypePlace.restaraunt,
                                Comment = comment,
                                Rating = Status.exelent,
                                Id = 1
                            };
                            var revyu = new GenericRepository<Review>();
                            await revyu.CreateAsync(review1);
                            TodolistService todolistService = new TodolistService();
                            var res1 = await todolistService.CreateAsync(toDoListCreationDto);
                            if (res1.StatusCode == 200)
                            {
                                Console.WriteLine("You have successfully added to your to do list");
                            }
                            else
                            {
                                Console.WriteLine("You have already added this attraction to your to do list");
                            }

                        }
                        else if (n1 == 4)
                        {
                            var toDoList = await toDoListRepository.GetAllAsync(x => x.UserId > 0);
                            foreach (var item in toDoList)
                            {
                                Console.WriteLine($"Number of Day: {item.NumberOfDay}");
                                Console.WriteLine($"Day of Week: {item.DayOfWeek}");
                                Console.WriteLine($"Place Type: {item.PlaceType}");
                                Console.WriteLine($"Hours Spend: {item.HoursSpend}");
                                Console.WriteLine($"Comment: {item.Comment}");
                                Console.WriteLine($"Trip Status: {item.TripStatus}");
                                Console.WriteLine($"City Name: {item.CityName}");
                                Console.WriteLine($"User Id: {item.UserId}");
                                Console.WriteLine("*********************************************");
                                Console.WriteLine("*********************************************");

                            }


                        }



                    }

                }

            }
        }
    }
}
