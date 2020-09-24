using Microsoft.EntityFrameworkCore;
using System;

namespace Films.Data
{
    public interface IDatabaseContext : IDisposable
    {
        DbSet<Film> Films { get; set; }
        int SaveChanges();
    }
}
