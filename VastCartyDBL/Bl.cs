using VastCartyDBL.Repositories;
using VastCartyDBL.UOW;

namespace VastCartyDBL
{
    public class Bl
    {
        private readonly string _ConnectionString;
        private readonly UnitOfWork _db;

        public Bl(string connectionString)
        {
            _ConnectionString = connectionString;
            _db = new UnitOfWork(_ConnectionString);

            UserRepository = new UserRepository(connectionString);
        }

        public string ConnectionString => _ConnectionString;

        public UserRepository UserRepository { get; }

    }
}
