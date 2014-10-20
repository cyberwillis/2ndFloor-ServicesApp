using System;
using SecondFloor.Infrastructure.Repository;

namespace SecondFloor.Model
{
    public interface IFeedbackRepository : IRepository<Feedback,Guid>
    {
        void InserirFeedback(Feedback feedback);
    }
}