using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakenplannerData.Models;

namespace TakenplannerData.Services
{
    public interface IChoreData
    {
        IEnumerable<Chore> GetAll();
        Chore Get(int Id);
        void Add(Chore chore);
        void Update(Chore chore);
        void Delete(int Id);
        void UpdateNote(Chore chore);
    }
}
