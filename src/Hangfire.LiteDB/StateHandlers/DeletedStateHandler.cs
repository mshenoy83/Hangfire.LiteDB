﻿using Hangfire.States;
using Hangfire.Storage;

namespace Hangfire.LiteDB.StateHandlers
{
#pragma warning disable 1591
    public class DeletedStateHandler : IStateHandler
    {
        public void Apply(ApplyStateContext context, IWriteOnlyTransaction transaction)
        {
            transaction.InsertToList("deleted", context.BackgroundJob.Id);
            transaction.TrimList("deleted", 0, 99);
        }

        public void Unapply(ApplyStateContext context, IWriteOnlyTransaction transaction)
        {
            transaction.RemoveFromList("deleted", context.BackgroundJob.Id);
        }

        public string StateName => DeletedState.StateName;
    }
#pragma warning restore 1591
}