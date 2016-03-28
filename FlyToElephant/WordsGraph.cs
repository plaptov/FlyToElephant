using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyToElephant
{
	/// <summary>
	/// Граф слов с возможными переходами
	/// </summary>
	public class WordsGraph : Dictionary<Word, List<Word>>
	{
		/// <summary>
		/// Приватный конструктор для использования извне только Generate
		/// </summary>
		private WordsGraph(int capacity) : base(capacity) { }
		/// <summary>
		/// Сгенерировать граф слов
		/// </summary>
		/// <param name="dict">Словарь слов</param>
		/// <param name="wordLength">Длина слов, которые должны войти в граф</param>
		/// <returns>Словарь слово-возможные слова для перехода</returns>
		public static WordsGraph Generate(string[] dict, int wordLength)
		{
			// Сразу берём кол-во элементов максимално возможное, чтобы не тратить ресурсы на расширение
			WordsGraph gr = new WordsGraph(dict.Length);
			// Отбираем только строки нужной длины
			var filteredStrings = Array.FindAll(dict, s => s != null && s.Length == wordLength);
			// Создаём список узлов графа для всех слов
			var words = Array.ConvertAll(filteredStrings, s => new Word(s));
			Parallel.For(0, words.Length, i =>
				{
					// Берём слово из списка
					var w = words[i];
					var steps = new List<Word>();
					// Находим все слова, отличающиеся только на одну букву
					// Ищем только среди слов после текущего,т.к. см. ниже
					for (int k = i + 1; k < words.Length; k++)
					{
						var w2 = words[k];
						if (w.IsOnlyOneLetterDiffWith(w2))
							steps.Add(w2);
					}
					// Потоки со списком работают по очереди
					lock (gr)
					{
						// Добавляем слово и его переходы в граф
						if (!gr.ContainsKey(w))
							gr.Add(w, steps);
						else
							gr[w].AddRange(steps);
						// Т.к. граф неориентированный, для переходов сразу добавляем 
						// текущее слово как возможный переход (обратный)
						foreach (var w2 in steps)
						{
							if (!gr.ContainsKey(w2))
								gr.Add(w2, new List<Word>() { w });
							else
								gr[w2].Add(w);
						}
					}
				});
			return gr;
		}
	}
}
