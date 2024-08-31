using System;
using Katio.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace katio_net.Data;

public class KatioContext : DbContext
{
    public KatioContext(DbContextOptions<KatioContext> options) : base(options)
    {

    }
    public DbSet<Books> Books{get; set;} = null;
    public DbSet<Author> Author{get; set;} = null;

}
