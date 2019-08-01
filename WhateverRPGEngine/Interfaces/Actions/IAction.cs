namespace WhateverRPGEngine.Interfaces.Actions
{
    using System;
    using WhateverRPGEngine.Models;

    public interface IAction
    {
        event EventHandler<string> OnActionPerformed;

        void Execute(LivingEntity actor, LivingEntity target);
    }
}
