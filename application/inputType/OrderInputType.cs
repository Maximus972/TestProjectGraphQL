using System;
using TestProjectGraphQL.domain.enums;

namespace TestProjectGraphQL.application.inputType
{
    public class OrderInputType
    {
        public string? CargoDescription { get; set; }
        public int CargoCount { get; set; }
        public OrderType OrderType { get; set; }
        public OrderProgress OrderProgress { get; set; } = OrderProgress.InProgress;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? CompletedAt { get; set; }

        public OrderInputType(string? cargoDescription, int cargoCount, OrderType orderType)
        {
            CargoDescription = cargoDescription;
            CargoCount = cargoCount;
            OrderType = orderType;
        }
    }
}
