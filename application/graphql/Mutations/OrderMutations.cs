using HotChocolate.Types;
using System;
using TestProjectGraphQL.application.inputType;
using TestProjectGraphQL.application.interfaces.ordercontrol;
using TestProjectGraphQL.data.interfaces;

namespace TestProjectGraphQL.application.graphql.Mutations
{
    [ExtendObjectType("Mutation")]
    public class OrderMutations : IOrderControlMutation
    {
        private readonly IOrderRepository _orders;

        public OrderMutations(IOrderRepository orders)
        {
            _orders = orders;
        }

        //Post запросы , связанные с заказами

        public bool CancelOrder(Guid id)
        {
            _orders.CancelOrder(id);
            return true;
        }

        public bool CompleteOrder(Guid id)
        {
            _orders.CompleteOrder(id);
            return true;
        }

        public bool CreateOrder(OrderInputType orderInputType)
        {
            _orders.CreateOrder(orderInputType);
            return true;
        }
    }
}
