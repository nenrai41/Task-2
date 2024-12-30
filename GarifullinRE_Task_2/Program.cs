using GarifullinRE_Task_2;

var data_1 = new int[] { 1, 2, 3 };
var equalityComparer = EqualityComparer<int>.Default;

//Сочетания с повторениями
var combinationsWithRepetition = data_1.CombinationsWithRepetition(2, equalityComparer);
Console.WriteLine("Сочетания с повторениями:");
foreach (var combination in combinationsWithRepetition)
{
    Console.WriteLine($"[{string.Join(", ", combination)}]");
}

//Сочетания без повторений
var combinationsWithoutRepetition = data_1.CombinationsWithoutRepetition(2, equalityComparer);
Console.WriteLine("Сочетания без повторений:");
foreach (var combination in combinationsWithoutRepetition)
{
    Console.WriteLine($"[{string.Join(", ", combination)}]");
}

var data_2 = new int[] { 1, 2 };

//Подмножества
var subsets = data_2.Subsets(equalityComparer);
Console.WriteLine("Подмножества:");
foreach (var subset in subsets)
{
    Console.WriteLine($"[{string.Join(", ", subset)}]");
}

//Перестановки
var permutations = data_1.Permutations(equalityComparer);
Console.WriteLine("Перестановки:");
foreach (var permutation in permutations)
{
    Console.WriteLine($"[{string.Join(", ", permutation)}]");
}
