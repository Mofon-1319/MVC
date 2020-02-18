using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Entity;

namespace WebApp.DAL
{
    public class BusRepository
    {
        static List<BusEntity> busList = new List<BusEntity>();

        static void BusRepositary()
        {
            BusEntity Bus = new BusEntity("Sleeper", 25, "Chennai", "Bangalore", "10:00PM","5:00AM",750);
            busList.Add(Bus);
            Bus = new BusEntity("Semi-Sleeper", 35, "Chennai", "Trichy", "10:00AM", "1:00PM", 550);
            busList.Add(Bus);
        }

        public IEnumerable<BusEntity> Display()
        {
            return busList;
        }
        public void AddBus(BusEntity busEntity)
        {
            busList.Add(busEntity);
        }
        public BusEntity GetBus(string type)
        {
            return busList.Find(id => id.BusType == type);
        }
        public void DeleteBus(string type)
        {
            BusEntity bus = GetBus(type);
            if (bus != null)
            {
                busList.Remove(bus);
            }
        }
        public void UpdateBus(BusEntity entity)
        {
            BusEntity bus = GetBus(entity.BusType);
            bus.seats = entity.seats;
            bus.source = entity.source;
            bus.destination = entity.destination;
            bus.arrivalTime = entity.arrivalTime;
            bus.departureTime = entity.departureTime;
            bus.rate = entity.rate;
        }
    }
}
