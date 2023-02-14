using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    /// <summary>
    /// Конфигуратор контекста.
    /// </summary>
    public interface DbContextOptionsConfigurator<TContext> where TContext : DbContext
    {
        void Configure(DbContextOptionsBuilder<TContext> opions);
    }
}
