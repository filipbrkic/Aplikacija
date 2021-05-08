using Application.Repository.Common;
using Application.Service.Common;

namespace Application.Service
{
    public class SeminarService : ISeminarService
    {
        private readonly ISeminarRepository seminarRepository;

        public SeminarService(ISeminarRepository seminarRepository)
        {
            this.seminarRepository = seminarRepository;
        }
    }
}
