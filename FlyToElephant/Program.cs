using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyToElephant
{
    class Program
    {
        static void Main(string[] args)
        {
			// Создаём ридер файлов
			var reader = new Reader();
			// Считываем начальное и конечное слова
			var sf = reader.ReadStartAndFinish(args[0]);
			// Нужно два слова
			if (sf == null || sf.Length < 2)
			{
				Console.WriteLine("Error! Incorrect file with start and finish words.");
				Console.ReadKey();
				return;
			}
			// Слова должны быть одинаковой длины
			if (sf[0].Length != sf[1].Length)
			{
				Console.WriteLine("Error! Start and finish words has different lenght.");
				Console.ReadKey();
				return;
			}
			// Считываем словарь
			var dict = reader.ReadDictionary(args[1]);
			// Словарь должен быть непустой
			if (dict == null || dict.Length == 0)
			{
				Console.WriteLine("Error! Incorrect file with dictionary.");
				Console.ReadKey();
				return;
			}
			// Генерируе граф по словарю
			var graph = WordsGraph.Generate(dict, sf[0].Length);
			// Ищем кратчайший путь в графе
			var path = PathFinder.FindShortestPath(graph, new Word(sf[0]), new Word(sf[1]));
			// Выводим результат
			if (path != null)
				Console.WriteLine(path.ToString());
			else
				Console.WriteLine("Cannot find path");
			Console.ReadKey();
        }
    }
}
