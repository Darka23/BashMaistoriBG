namespace BashMaistoriBG.Contracts
{
    public interface ICloudinaryService
    {
        public string Image(IFormFile file, string folder);
    }
}
