using System;
using System.Threading.Tasks;
using Jellyfin.Database.Providers.PgSql;
using Jellyfin.Server.Implementations.Migrations;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Jellyfin.Server.Implementations.Tests.EfMigrations;

public class EfMigrationTests
{
    [Fact]
    public void CheckForUnappliedMigrations_PgSQL()
    {
        var dbDesignContext = new PgSqlDesignTimeJellyfinDbFactory();
        var context = dbDesignContext.CreateDbContext([]);
        Assert.False(context.Database.HasPendingModelChanges(), "There are unapplied changes to the EfCore model for PgSQL. Please create a Migration.");
    }

    [Fact]
    public void CheckForUnappliedMigrations_SqLite()
    {
        var dbDesignContext = new SqliteDesignTimeJellyfinDbFactory();
        var context = dbDesignContext.CreateDbContext([]);
        Assert.False(context.Database.HasPendingModelChanges(), "There are unapplied changes to the EfCore model for PgSQL. Please create a Migration.");
    }
}
