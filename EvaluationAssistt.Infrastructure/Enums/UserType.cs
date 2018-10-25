using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace EvaluationAssistt.Infrastructure.Enums
{
    public enum UserType
    {
        [Description("Admin")]
        Admin = 1,
        [Description("Asistan")]
        Agent = 5,
        [Description("Grup Lideri")]
        GroupLeader = 3,
        [Description("Kalite Uzmanı")]
        QualityExpert = 2,
        [Description("Takım Lideri")]
        TeamLeader = 4
    }
}
