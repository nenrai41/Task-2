using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarifullinRE_Task_2
{
    public static class Methods
    {
        public static IEnumerable<IEnumerable<T>> CombinationsWithRepetition<T>(this IEnumerable<T> source, int k, IEqualityComparer<T> comparer)
        {
            var elements = source.ToList();
            ValidateDistinctness(elements, comparer);

            return CombinationsWithRepetitionInternal(elements, k);
        }

        public static IEnumerable<IEnumerable<T>> CombinationsWithoutRepetition<T>(this IEnumerable<T> source, int k, IEqualityComparer<T> comparer)
        {
            var elements = source.ToList();
            ValidateDistinctness(elements, comparer);

            return CombinationsWithoutRepetitionInternal(elements, k);
        }

        public static IEnumerable<IEnumerable<T>> Subsets<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer)
        {
            var elements = source.ToList();
            ValidateDistinctness(elements, comparer);

            return SubsetsInternal(elements);
        }

        public static IEnumerable<IEnumerable<T>> Permutations<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer)
        {
            var elements = source.ToList();
            ValidateDistinctness(elements, comparer);

            return PermutationsInternal(elements);
        }

        private static void ValidateDistinctness<T>(IEnumerable<T> elements, IEqualityComparer<T> comparer)
        {
            if (elements.Distinct(comparer).Count() != elements.Count())
            {
                throw new ArgumentException("Элементы входного перечисления должны быть попарно неравными.");
            }
        }

        private static IEnumerable<IEnumerable<T>> CombinationsWithRepetitionInternal<T>(List<T> elements, int k)
        {
            var result = new List<IEnumerable<T>>();
            var combination = new T[k];

            void Generate(int index, int start)
            {
                if (index == k)
                {
                    result.Add(combination.ToArray());
                    return;
                }

                for (int i = start; i < elements.Count; i++)
                {
                    combination[index] = elements[i];
                    Generate(index + 1, i); // Позволяем использовать тот же элемент снова
                }
            }

            Generate(0, 0);
            return result;
        }

        private static IEnumerable<IEnumerable<T>> CombinationsWithoutRepetitionInternal<T>(List<T> elements, int k)
        {
            var result = new List<IEnumerable<T>>();
            var combination = new T[k];

            void Generate(int index, int start)
            {
                if (index == k)
                {
                    result.Add(combination.ToArray());
                    return;
                }

                for (int i = start; i < elements.Count; i++)
                {
                    combination[index] = elements[i];
                    Generate(index + 1, i + 1); // Не позволяем использовать тот же элемент снова
                }
            }

            Generate(0, 0);
            return result;
        }

        private static IEnumerable<IEnumerable<T>> SubsetsInternal<T>(List<T> elements)
        {
            var result = new List<IEnumerable<T>>();
            result.Add(Enumerable.Empty<T>()); // Сначала добавляем пустое подмножество

            foreach (var element in elements)
            {
                // Сохраняем текущую длину результата
                int currentSize = result.Count;

                for (int i = 0; i < currentSize; i++)
                {
                    // Создаем новое подмножество, добавляя элемент к существующему
                    var newSubset = result[i].Append(element);
                    result.Add(newSubset);
                }
            }

            return result;
        }

        private static IEnumerable<IEnumerable<T>> PermutationsInternal<T>(List<T> elements)
        {
            var result = new List<IEnumerable<T>>();

            void Generate(IEnumerable<T> current, IEnumerable<T> remaining)
            {
                if (!remaining.Any())
                {
                    result.Add(current);
                    return;
                }

                foreach (var element in remaining)
                {
                    var newRemaining = remaining.Where(e => !e.Equals(element));
                    Generate(current.Concat(new[] { element }), newRemaining);
                }
            }

            Generate(Enumerable.Empty<T>(), elements);
            return result;
        }
    }

}

