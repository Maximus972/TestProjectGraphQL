using Bogus;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;
using System.Collections.Generic;
using TestProjectGraphQL.application.interfaces.ordercontrol;
using TestProjectGraphQL.data.interfaces;
using TestProjectGraphQL.data.models;
using TestProjectGraphQL.domain.models;
using TestProjectGraphQL.domain.enums;
using System;

namespace TestProjectGraphQL.application.graphql.Queries
{
    [ExtendObjectType("Query")]
    public class OrderQueries : IOrderControlQuery
    {
        private readonly IOrderRepository _orders;

        public OrderQueries(IOrderRepository orders)
        {
            _orders = orders;
        }

        //Get запросы связанные с заказами

        public IEnumerable<Order> GetAllOrder() => _orders.GetAllOrder();

        public IEnumerable<Order> GetAllOrderCanceled() => _orders.GetAllOrderCanceled();

        public IEnumerable<Order> GetAllOrderCompleted() => _orders.GetAllOrderCompleted();

        public IEnumerable<Order> GetAllOrderCompletedByTrain(Guid id) => _orders.GetAllOrderCompletedByTrain(id);

        public IEnumerable<Order> GetAllOrderInProgress() => _orders.GetAllOrderInProgress();
    }
}
