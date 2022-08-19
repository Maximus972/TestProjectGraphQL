using System;
using TestProjectGraphQL.domain.enums;

namespace TestProjectGraphQL.domain.models
{
    public class Order
    {
        public Guid ID { get; set; }
        public Guid? TrainID { get; set; }
        public string? CargoDescription { get; set; }
        public int CargoCount { get; set; }
        public OrderType OrderType { get; set; }
        public OrderProgress OrderProgress { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
