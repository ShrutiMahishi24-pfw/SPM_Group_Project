///Backend Data Connection built-up  
using System;
using System.Collections.Generic;
using Appointments_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Appointments_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Appointments> Appointments { get; set; }
    }
}
