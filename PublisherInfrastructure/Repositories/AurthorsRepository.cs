using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublisherDomain;
using PublisherInfrastructure.Repositories.Interfaces;

namespace PublisherInfrastructure.Repositories
{
    public class AurthorsRepository : IAurthorsRepository
    {
        public IQueryable<Author> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
