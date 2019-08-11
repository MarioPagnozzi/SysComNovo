namespace Cadastros.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Cadastros.DataBase.Cadastro_DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Cadastros.DataBase.Cadastro_DBContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Cadastros.DataBase.Cadastro_DBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
