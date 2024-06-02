namespace BashMaistoriBG.ViewModels
{
    public class RequestListViewModel
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string SpecialistType { get; set; }

        public string Status { get; set; }

        public DateTime StartDate { get; set; }
        public decimal Budget { get; set; }

    }
}
