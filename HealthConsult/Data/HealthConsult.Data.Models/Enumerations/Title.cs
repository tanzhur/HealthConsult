namespace HealthConsult.Data.Models.Enumerations
{
    using System.ComponentModel;

    public enum Title
    {
        Md,
        Professor,
        [Description("Assistant profesor")]
        AssistantProfesor,
        [Description("Associate professor")]
        AssociateProfessor
    }
}
