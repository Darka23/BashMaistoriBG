namespace BashMaistoriBG.Contracts
{
    public interface IWorkerServices
    {
        Task AcceptRequest(int id);

        Task FinishRequest(int id);
    }
}
