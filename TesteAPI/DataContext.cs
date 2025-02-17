﻿using Microsoft.EntityFrameworkCore;
using TesteAPI;

namespace MyCrudAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Cliente>? Clientes { get; set; }

    }
}
