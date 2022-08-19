using System;
using TestProjectGraphQL.application.inputType;

namespace TestProjectGraphQL.application.interfaces.ordercontrol
{
    public interface IOrderControlMutation
    {
        public bool CreateOrder(OrderInputType orderInputType);
        public bool CompleteOrder(Guid id);
        public bool CancelOrder(Guid id);
    }
}
