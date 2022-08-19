using System;
using System.Collections.Generic;
using TestProjectGraphQL.application.inputType;
using TestProjectGraphQL.domain.models;

namespace TestProjectGraphQL.data.interfaces
{
    public interface IOrderRepository
    {
        public void CancelOrder(Guid id);
        public void CompleteOrder(Guid id);
        public void CreateOrder(OrderInputType orderInputType);
        public IEnumerable<Order> GetAllOrder();
        public IEnumerable<Order> GetAllOrderCompleted();
        public IEnumerable<Order> GetAllOrderCanceled();
        public IEnumerable<Order> GetAllOrderInProgress();
        public IEnumerable<Order> GetAllOrderCompletedByTrain(Guid id);
    }
}
