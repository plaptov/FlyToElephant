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
	public class WordsGraph : Dictionary<Word, Word[]>
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
			WordsGraph gr = new WordsGraph(dict.Length);
			var filteredStrings = Array.FindAll(dict, s => s != null && s.Length == wordLength);
			var words = Array.ConvertAll(filteredStrings, s => new Word(s));
			words.AsParallel().ForAll(w =>
				{
					var steps = Array.FindAll(words, w2 => w.IsOnlyOneLetterDiffWith(w2));
					lock (gr)
						gr.Add(w, steps);
				});
			return gr;
		}
	}
}
