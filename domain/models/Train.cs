using System;
using TestProjectGraphQL.domain.enums;

namespace TestProjectGraphQL.domain.models
{
    public class Train
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; } 
        public TrainType TrainType { get; set; }
        public int Capacity { get; set; }
        public bool Deleted { get; set; } = false;
        public bool InOrder { get; set; } = false;
    }
}
