using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Infrastructure.Exceptions;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;


namespace BLL.Services
{
    public class AllowDeclineService : IAllowDeclineService
    {
        IUnitOfWork Database { get; set; }

        public AllowDeclineService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void AllowLot(int id)
        {
            using(Database){
                Lot lot = Database.Lots.Get(id);
                if (lot == null)
                    throw new ItemNotFoundException($"Item {id} not found");
                lot.IsAllowed = true;
                lot.IsOpen = true;
                Database.Lots.Update(lot);
                Database.Save();
            }
        }

        public void DeclineLot(int id)
        {
            using (Database)
            {
                Database.Lots.Delete(id);
                Database.Save();
            }
        }
    }
}
