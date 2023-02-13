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
        /// <summary>
        /// Выполняет конфигурацию контекста.
        /// </summary>
        /// <param name="opions">настройки</param>
        void Configure(DbContextOptionsBuilder<TContext> opions);
    }
}
