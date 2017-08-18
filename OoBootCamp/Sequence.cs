/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */


using System.Collections.Generic;
using System.Linq;
// ReSharper disable PossibleMultipleEnumeration

namespace OoBootCamp
{
    public static class Sequence
    {
        public static T Best<T>(this IEnumerable<T> elements) where T : Sequenceable<T>
        {
            return elements.Aggregate(elements.First(),
                (champion, challenger) => challenger.IsBetterThan(champion) ? challenger : champion);
        }
    }

    // Understands rules to be ordered elements
    // ReSharper disable once InconsistentNaming
    public interface Sequenceable<T>
    {
        bool IsBetterThan(T other);
    }
}