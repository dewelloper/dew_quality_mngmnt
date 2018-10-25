using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Presenter.Interfaces
{
    public interface ILoginView
    {
        int Id { get; set; }

        string Username { get; set; }

        string Password { get; set; }
    }
}
