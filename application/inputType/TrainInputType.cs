using TestProjectGraphQL.domain.enums;

namespace TestProjectGraphQL.application.inputType
{
    public class TrainInputType
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public TrainType TrainType { get; set; }
        public int Capacity { get; set; }

        public TrainInputType(string? name, string? description, TrainType trainType, int capacity)
        {
            Name = name;
            Description = description;
            TrainType = trainType;
            Capacity = capacity;
        }
    }
}
