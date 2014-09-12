using System;

namespace SavannahGame
{
    static class EnumerableExtensions
    {
        public static void ForEach<T>(this T[,] seq, Action<T, int, int> action)
        {
            for (int i = 0; i < seq.GetLength(0); i++)
            {
                for (int j = 0; j < seq.GetLength(1); j++)
                {
                    action(seq[i, j], i, j);
                }
            }
        }
    }
}