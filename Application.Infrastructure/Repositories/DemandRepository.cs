using Application.Data.Entities;
using Application.Infrastructure.Abstracts;
using Application.Infrastructure.Bases;
using Application.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Infrastructure.Repositories
{
    public class DemandRepository : GenericRepository<Demand>, IDemandRepository
    {
        private readonly DbSet<Demand> _demand;

        public DemandRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _demand = dBContext.Set<Demand>();
        }

    }
}
