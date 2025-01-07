using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublisherDomain;

namespace PublisherInfrastructure.Repositories.Interfaces
{
    public interface IAurthorsRepository
    {
        IQueryable<Author> GetAll();
    }
}
