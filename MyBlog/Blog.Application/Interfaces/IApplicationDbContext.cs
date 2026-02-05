using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
       // Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
