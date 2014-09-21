using System;
using System.Collections.Generic;

namespace SavannahGame
{
    internal static class ActionExtensions
    {
        public static Action Combine(this IEnumerable<Action> actions)
        {
            if (actions == null)
            {
                throw new ArgumentNullException("actions");
            }

            return () =>
            {
                foreach (var action in actions)
                {
                    action();
                }
            };
        }
    }
}