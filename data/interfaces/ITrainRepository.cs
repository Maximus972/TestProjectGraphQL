using System;
using System.Collections.Generic;
using TestProjectGraphQL.application.inputType;
using TestProjectGraphQL.domain.models;

namespace TestProjectGraphQL.data.interfaces
{
    public interface ITrainRepository
    {
        public void ChangeTrain(Guid id, TrainInputType trainInputType);
        public void CreateTrain(TrainInputType trainInputType);
        public void DeleteTrain(Guid id);
        public IEnumerable<Train> GetAllTrain();
        public IEnumerable<Train> GetAllTrainInOrder();
    }
}
