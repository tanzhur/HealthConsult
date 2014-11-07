namespace HealthConsult.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web.Hosting;
    using HealthConsult.Common;
    using HealthConsult.Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<HealthConsult.Data.ApplicationDbContext>
    {
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
            var user = new User { UserName = GlobalConstants.AdministratorRoleName };

            manager.Create(user, GlobalConstants.InitialPassword);
            manager.AddToRole(user.Id, GlobalConstants.AdministratorRoleName);

            context.SaveChanges();
        }

        private void SeedRoles(ApplicationDbContext context)
        {
            if (context.Roles.Any())
            {
                return;
            }

            context.Roles.Add(new IdentityRole { Name = GlobalConstants.AdministratorRoleName });
            context.Roles.Add(new IdentityRole { Name = GlobalConstants.SpecialistRoleName });
            context.SaveChanges();
        }

        private string MapPath(string seedFile)
        {
            if (HttpContext.Current != null)
            {
                return HostingEnvironment.MapPath(seedFile);
            }

            var absolutePath = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
            var directoryName = Path.GetDirectoryName(absolutePath);
            var path = Path.Combine(directoryName, string.Format("..{0}", seedFile.TrimStart('~').Replace('/', '\\')));

            return path;
        }
    }
}