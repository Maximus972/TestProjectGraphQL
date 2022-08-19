using HotChocolate.Types;
using System;
using TestProjectGraphQL.application.inputType;
using TestProjectGraphQL.application.interfaces.traincontrol;
using TestProjectGraphQL.data.interfaces;
using TestProjectGraphQL.domain.models;

namespace TestProjectGraphQL.application.graphql.Mutations
{
    [ExtendObjectType("Mutation")]
    public class TrainMutations : ITrainControlMutation
    {
        private readonly ITrainRepository _trains;

        public TrainMutations(ITrainRepository trains)
        {
            _trains = trains;
        }

        //Post запросы , связанные с поездами

        public bool ChangeTrain(Guid id, TrainInputType trainInputType)
        {
            _trains.ChangeTrain(id, trainInputType);
            return true;
        }

        public bool CreateTrain(TrainInputType trainInputType)
        {
            _trains.CreateTrain(trainInputType);
            return true;
        }

        public bool DeleteTrain(Guid id)
        {
            _trains.DeleteTrain(id);
            return true;
        }
    }
}
