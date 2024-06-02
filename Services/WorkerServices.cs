using BashMaistoriBG.Contracts;
using BashMaistoriBG.Data.Models;
using BashMaistoriBG.Data.Repositories;

namespace BashMaistoriBG.Services
{
    public class WorkerServices : IWorkerServices
    {
        private IApplicationDbRepository repo;

        public WorkerServices(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }
        public async Task AcceptRequest(int id)
        {
            var request = await repo.GetByIdAsync<Request>(id);

            request.Status = "Accepted";

            await repo.SaveChangesAsync();
        }

        public async Task FinishRequest(int id)
        {
            var request = await repo.GetByIdAsync<Request>(id);

            request.Status = "Finished";

            await repo.SaveChangesAsync();
        }
    }
}
