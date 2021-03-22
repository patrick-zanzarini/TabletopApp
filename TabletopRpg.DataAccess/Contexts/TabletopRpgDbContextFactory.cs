﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TabletopRpg.Infra.Contexts
{
    public class TabletopRpgDbContextFactory: IDesignTimeDbContextFactory<TabletopRpgDbContext>
    {
        public TabletopRpgDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TabletopRpgDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=TabletopRpg;User Id=appuser;Password=Teste123;");

            return new TabletopRpgDbContext(optionsBuilder.Options);

        }
    }
}