using BLL.Infrastructure;
using BLL.Interfaces;
using DataAccessLayer.Interfaces;
using BLL.DTO;
using AutoMapper;
using DataAccessLayer.Entities;
using BLL.Infrastructure.Exceptions;
using System.Linq;


namespace BLL.Services
{
    public class BargainingService : IBargainingService
    {
        IUnitOfWork Database { get; set; }

        public BargainingService(IUnitOfWork uow)
        {
            Database = uow;
        }


        public void BuyNow(int id)
        {

            using (Database)
            {
                Lot lot = Database.Lots.Get(id);
                if (lot == null)
                {
                    throw new ItemNotFoundException($"Item {id} not found");
                }
                if (lot.IsAllowed && lot.IsOpen)
                {
                    lot.IsOpen = false;
                    lot.CurrPrice = lot.BuyNowPrice;
                    Database.Lots.Update(lot);
                    Database.Save();
                }
                else throw new ValidationException("Лот закрыт или неподтвержден...");
            }
        }


        public void PlaceBet(BetDTO bet)
        {
            using (Database)
            {
                Lot lot = Database.Lots.Get(bet.LotId);
                if (lot == null)
                {
                    throw new ItemNotFoundException($"Item {bet.LotId} not found");
                }
                if (lot.IsAllowed && lot.IsOpen)
                {
                    if (lot.CurrPrice < bet.Price)
                    {
                        lot.CurrPrice = bet.Price;
                        Database.Lots.Update(lot);
                        Database.Save();
                    }
                    else throw new BargainingException("Ставка не может быть ниже текущей цены лота...");
                }
                else throw new ValidationException("Лот закрыт или неподтвержден...");

            }
        }
    }
}
