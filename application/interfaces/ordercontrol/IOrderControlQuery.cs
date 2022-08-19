using System;
using System.Collections.Generic;
using TestProjectGraphQL.application.inputType;
using TestProjectGraphQL.domain.models;

namespace TestProjectGraphQL.application.interfaces.ordercontrol
{
    public interface IOrderControlQuery
    {
        public IEnumerable<Order> GetAllOrder();
        public IEnumerable<Order> GetAllOrderCompleted();
        public IEnumerable<Order> GetAllOrderCanceled();
        public IEnumerable<Order> GetAllOrderInProgress();
        public IEnumerable<Order> GetAllOrderCompletedByTrain(Guid id);
    }
}
