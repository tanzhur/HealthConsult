namespace HealthConsult.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web;
    using HealthConsult.Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.OleDb;
    using System.Data;
    using System.Web.Hosting;
    using System.Reflection;
    using System.IO;


    internal sealed class Configuration : DbMigrationsConfiguration<HealthConsult.Data.ApplicationDbContext>
    {
        private const string AdminRole = "Admin";
        private const string AdminUserName = "Admin";
        private const string SpecialistRole = "Specialist";
        private const string InitialPassword = "123456";

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            this.SeedRoles(context);
            this.SeedUsers(context);
            this.SeedDiagnosis(context);
        }

        private void SeedDiagnosis(ApplicationDbContext context)
        {
            if (context.Diagnosis.Any())
            {
                return;
            }

            int count = 0;

            using (var streamReader = new StreamReader(this.MapPath("~/App_Data/Seed/Diagnosis.csv"), System.Text.Encoding.UTF8, true))
            {
                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine().Split(';');
                    var diagnosis = new Diagnosis();
                    diagnosis.Code = line[0];
                    diagnosis.Description = line[1];
                    context.Diagnosis.Add(diagnosis);

                    if (count % 200 == 0)
                    {
                        count = 0;
                        context.SaveChanges();
                    }

                    count++;
                }
            }
        }

        private void SeedUsers(ApplicationDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var store = new UserStore<User>(context);
            var manager = new UserManager<User>(store);
            var user = new User { UserName = AdminUserName };

            manager.Create(user, InitialPassword);
            manager.AddToRole(user.Id, AdminRole);

            context.SaveChanges();
        }

        private void SeedRoles(ApplicationDbContext context)
        {
            if (context.Roles.Any())
            {
                return;
            }

            context.Roles.Add(new IdentityRole { Name = AdminRole });
            context.Roles.Add(new IdentityRole { Name = SpecialistRole });
            context.SaveChanges();
        }

        private string MapPath(string seedFile)
        {
            if (HttpContext.Current != null)
                return HostingEnvironment.MapPath(seedFile);

            var absolutePath = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
            var directoryName = Path.GetDirectoryName(absolutePath);
            var path = Path.Combine(directoryName, ".." + seedFile.TrimStart('~').Replace('/', '\\'));

            return path;
        }
    }
}