namespace CRUD_API.Entities
{
    public class CrudEvents
    {
        public CrudEvents()
        {
            Speakers = new List<CrudEventsSpeaker>();
            IsDeleted = false;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<CrudEventsSpeaker> Speakers { get; set; }
        public bool IsDeleted { get; set; }

        public void Update(string title, string description, DateTime startDate, DateTime endDate)
        {
            Title = title;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
