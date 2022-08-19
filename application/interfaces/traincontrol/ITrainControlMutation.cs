using System;
using TestProjectGraphQL.application.inputType;

namespace TestProjectGraphQL.application.interfaces.traincontrol
{
    public interface ITrainControlMutation
    {
        public bool CreateTrain(TrainInputType trainInputType);
        public bool ChangeTrain(Guid id, TrainInputType trainInputType);
        public bool DeleteTrain(Guid id);
    }
}
