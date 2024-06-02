namespace BashMaistoriBG.ViewModels
{
    public class RequestDetailsViewModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int SpecialtyId { get; set; }
        public string SpecialistType { get; set; }

        public string Status { get; set; }

        public decimal Budget { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string RequestorName { get; set; }
    }
}
