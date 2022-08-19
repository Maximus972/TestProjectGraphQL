using HotChocolate.Types;
using System.Collections.Generic;
using TestProjectGraphQL.application.interfaces.traincontrol;
using TestProjectGraphQL.data.interfaces;
using TestProjectGraphQL.domain.models;

namespace TestProjectGraphQL.application.graphql.Queries
{
    [ExtendObjectType("Query")]
    public class TrainQueries : ITrainControlQuery
    {
        private readonly ITrainRepository _trains;

        public TrainQueries(ITrainRepository trains)
        {
            _trains = trains;
        }

        //Get запросы связанные с поездами

        public IEnumerable<Train> GetAllTrain() => _trains.GetAllTrain();

        public IEnumerable<Train> GetAllTrainInOrder() => _trains.GetAllTrainInOrder();
    }
}
