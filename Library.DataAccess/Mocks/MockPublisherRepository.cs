using Library.DataAccess.Entities;
using Library.DataAccess.Repositories;

namespace Library.DataAccess.Mocks;
public class MockPublisherRepository : IPublisherRepository
{
    public PublisherEntity[] GetAll()
    {
        return new PublisherEntity[]
        {
            new()
            {
                Id=1,
                Name="Эксмо",
            },
        };
    }

    public PublisherEntity GePublisherById(int publisherId)
    {
        return null;
    }
}
