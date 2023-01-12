using Jwt.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwt.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly DbContext _context;

        public UnitOfWork(AppDbContext appcontext)
        {
            _context = appcontext;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommmitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
