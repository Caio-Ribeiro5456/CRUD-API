using CRUD_API.Entities;

namespace CRUD_API.Persistence
{
    public class CrudEventsDbContext
    {
        // Usando uma lista para simular o banco de dados
        public List<CrudEvents> CrudEvents { get; set; }

        public CrudEventsDbContext()
        {
            CrudEvents = new List<CrudEvents>();
        }
    }
}
