namespace HealthConsult.Web.Infrastructure.Logging
{
    using HealthConsult.Data;
    using HealthConsult.Data.Models;
    using HealthConsult.Data.Models.Enumerations;

    public interface ILogger
    {
        void Log(IApplicationData data, ActionType action, string actionInfo, string userId);
    }
}
