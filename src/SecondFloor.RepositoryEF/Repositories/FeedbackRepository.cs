using System;
using SecondFloor.Infrastructure.Repository;
using SecondFloor.Model;

namespace SecondFloor.RepositoryEF.Repositories
{
    public class FeedbackRepository : RepositoryBase<Feedback, Guid>, IFeedbackRepository
    {
        public FeedbackRepository(EFUnitOfWork<Feedback> unitOfWork)
            : base(unitOfWork)
        {
        }

        public void InserirFeedback(Feedback feedback)
        {
            this.Insert(feedback);
        }
    }
}