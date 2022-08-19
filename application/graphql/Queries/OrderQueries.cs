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

        public IEnumerable<Order> GetAllOrder()
        {
            var result = _orders.GetAllOrder();
            return result;
        }

        public IEnumerable<Order> GetAllOrderCanceled()
        {
            var result = _orders.GetAllOrderCanceled();
            return result;
        }

        public IEnumerable<Order> GetAllOrderCompleted()
        {
            var result = _orders.GetAllOrderCompleted();
            return result;
        }

        public IEnumerable<Order> GetAllOrderCompletedByTrain(Guid id)
        {
            var result = _orders.GetAllOrderCompletedByTrain(id);
            return result;
        }

        public IEnumerable<Order> GetAllOrderInProgress()
        {
            var result = _orders.GetAllOrderInProgress();
            return result;
        }
    }
}
