using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakenplannerData.Models;

namespace TakenplannerData.Services
{
    public class InMemoryChoreData : IChoreData
    {
        readonly List<Chore> chores;
        private static InMemoryChoreData _inMemoryChoreData;

        //TODO Add real database
        private InMemoryChoreData() 
        {
            chores = new List<Chore>()
            {
                new Chore {Id = 1, Name = "Class aanmaken", Description = "Class maken voor dieren", Note = "Graag feedback geven", 
                    StartDate = new DateTime(2021, 5, 31), EndDate = new DateTime(2021, 6, 15), Status = Status.ToDo },
                new Chore {Id = 2, Name = "Enum aanmaken", Description = "Enum maken voor dierentuinen", 
                    StartDate = new DateTime(2021, 5, 26), EndDate = new DateTime(2021, 6, 3), Status = Status.Doing },                
                new Chore {Id = 3, Name = "Databinding toevoegen", Description = "Databinding toevoegen aan XAML", 
                    StartDate = new DateTime(2021, 6, 24), EndDate = new DateTime(2021, 7, 30), Status = Status.Backlog },
                new Chore {Id = 4, Name = "Project aanmaken", Description = "Project starten voor dierentuinopdracht", 
                    StartDate = new DateTime(2021, 7, 2), EndDate = new DateTime(2021, 7, 25), Status = Status.Done },
                new Chore {Id = 5, Name = "Toevoegen aan Git", Description = "Repository aanmaken",
                    StartDate = new DateTime(2021, 8, 4), EndDate = new DateTime(2021, 8, 21), Status = Status.Backlog }
            };
        }

        public static InMemoryChoreData GetInstance() 
        {
            if (_inMemoryChoreData == null)
            {
                _inMemoryChoreData = new InMemoryChoreData();
            }
            return _inMemoryChoreData;
        }

        public void Add(Chore chore)
        {
            chores.Add(chore);
            chore.Id = chores.Max(r => r.Id) + 1;
        }

        public void Update(Chore chore)
        {
            var existing = Get(chore.Id);
            if (existing != null)
            {
                existing.Name = chore.Name;
                existing.Description = chore.Description;
                existing.StartDate = chore.StartDate;
                existing.EndDate = chore.EndDate;
                existing.Status = chore.Status;
            }
        }

        public Chore Get(int Id)
        {
            return chores.FirstOrDefault(r => r.Id == Id);
        }

        public IEnumerable<Chore> GetAll()
        {
            return chores.OrderBy(r => r.Name);
        }

        public void Delete(int Id) 
        {
            var chore = Get(Id);
            if (chore != null)
            {
                chores.Remove(chore);
            }
        }



    }
}
