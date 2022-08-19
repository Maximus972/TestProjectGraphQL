using System.Linq;
using System;
using System.Collections.Generic;
using TestProjectGraphQL.application.inputType;
using TestProjectGraphQL.data.interfaces;
using TestProjectGraphQL.domain.enums;
using TestProjectGraphQL.domain.models;

namespace TestProjectGraphQL.data.models
{
    public class SQLRepository : IOrderRepository, ITrainRepository
    {
        private readonly dbContext _dbContext;

        public SQLRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //Функциональность связанная с поездами 

        //Изменения в БД связанные с поездами 
        public void CreateTrain(TrainInputType trainInputType)
        {
            Train train = new Train()
            {
                ID = Guid.NewGuid(),
                Name = trainInputType.Name,
                Description = trainInputType.Description,
                TrainType = trainInputType.TrainType,
                Capacity = trainInputType.Capacity
            };
            _dbContext.Trains.Add(train);
            _dbContext.SaveChanges();
        }

        public void ChangeTrain(Guid id, TrainInputType trainInputType)
        {
            var result = (from p in _dbContext.Trains
                          where p.ID == id
                          select p).ToList();

            result[0].Name = trainInputType.Name;
            result[0].Description = trainInputType.Description;
            result[0].TrainType = trainInputType.TrainType;
            result[0].Capacity = trainInputType.Capacity;
            _dbContext.SaveChanges();
        }

        public void DeleteTrain(Guid id)
        {
            var result = (from p in _dbContext.Trains
                          where p.ID == id
                          select p).ToList();
            result[0].Deleted = true;
            _dbContext.SaveChanges();
        }

        public void ChangeTrainInOrder(Guid? id, bool isInOrder)
        {
            var result = _dbContext.Trains.FirstOrDefault(p => p.ID == id);
            result.InOrder = isInOrder;
            _dbContext.SaveChanges();
        }

        //Получение данных , связанных с поездами 

        public IEnumerable<Train> GetAllTrain()
        {
            return _dbContext.Trains;
        }

        public IEnumerable<Train> GetAllTrainInOrder()
        {
            var result = from p in _dbContext.Trains
                         where p.InOrder == true
                         select p;
            return result;
        }

        /// <summary>
        /// Метод , который возвращает TrainID при создании заказа
        /// </summary>
        public Guid GetTrainID(OrderType orderType, int cargoCount)
        {
            var result = _dbContext.Trains
                          .FirstOrDefault(p => p.InOrder == false 
                                            && p.Deleted == false 
                                            && (byte)p.TrainType == (byte)orderType
                                            && p.Capacity >= cargoCount);

            if (result == null)
            {
                throw new Exception("Подходящих поездов в БД не найдено.");
            }


            return result.ID;
        }

        //Функциональность связанная с заказами

        //Изменения в БД связанные с заказами
        public void CreateOrder(OrderInputType orderInputType)
        {
            Order order = new Order()
            {
                ID = Guid.NewGuid(),
                TrainID = GetTrainID(orderInputType.OrderType, orderInputType.CargoCount),
                CargoDescription = orderInputType.CargoDescription,
                CargoCount = orderInputType.CargoCount,
                OrderType = orderInputType.OrderType,
                OrderProgress = orderInputType.OrderProgress,
                CreatedAt = orderInputType.CreatedAt
            };
            ChangeTrainInOrder(order.TrainID, true);
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }

        public void CancelOrder(Guid id)
        {
            var order = _dbContext.Orders.FirstOrDefault(p => p.ID == id);
            order.OrderProgress = OrderProgress.Canceled;
            ChangeTrainInOrder(order.TrainID, false);
            _dbContext.SaveChanges();
        }

        public void CompleteOrder(Guid id)
        {
            var order = _dbContext.Orders.FirstOrDefault(p => p.ID == id);
            order.OrderProgress = OrderProgress.Completed;
            order.CompletedAt = DateTime.Now;
            ChangeTrainInOrder(order.TrainID, false);
            _dbContext.SaveChanges();
        }

        //Получение данных , связанных с заказами

        public IEnumerable<Order> GetAllOrder()
        {
            return _dbContext.Orders;
        }

        public IEnumerable<Order> GetAllOrderCompleted()
        {
            var result = from p in _dbContext.Orders
                         where p.OrderProgress == OrderProgress.Completed
                         select p;
            return result;
        }

        public IEnumerable<Order> GetAllOrderCanceled()
        {
            var result = from p in _dbContext.Orders
                         where p.OrderProgress == OrderProgress.Canceled
                         select p;
            return result;
        }

        public IEnumerable<Order> GetAllOrderInProgress()
        {
            var result = from p in _dbContext.Orders
                         where p.OrderProgress == OrderProgress.InProgress
                         select p;
            return result;
        }

        public IEnumerable<Order> GetAllOrderCompletedByTrain(Guid id)
        {
            var result = from p in _dbContext.Orders
                         where p.TrainID == id && p.OrderProgress == OrderProgress.Completed
                         select p;
            return result;
        }
    }
}
