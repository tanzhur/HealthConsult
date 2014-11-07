namespace HealthConsult.Web.Infrastructure.Logging
{
    using System;
    using HealthConsult.Data;
    using HealthConsult.Data.Models;
    using HealthConsult.Data.Models.Enumerations;

    public class Logger : ILogger
    {
        private IApplicationData data;

        public void Log(IApplicationData data, ActionType action, string actionInfo, string userId)
        {
            this.data = data;
            var log = new Log()
            {
                ActionDate = DateTime.Now,
                Action = action,
                ActionInfo = actionInfo,
                UserId = userId
            };

            data.Logs.Add(log);

            data.SaveChanges();
        }
    }
}