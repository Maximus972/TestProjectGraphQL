using System.Collections.Generic;
using TestProjectGraphQL.application.inputType;
using TestProjectGraphQL.domain.models;

namespace TestProjectGraphQL.application.interfaces.traincontrol
{
    public interface ITrainControlQuery
    {
        public IEnumerable<Train> GetAllTrain();
        public IEnumerable<Train> GetAllTrainInOrder();
    }    
}
