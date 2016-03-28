using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyToElephant
{
	/// <summary>
	/// Путь в графе
	/// </summary>
	public class Path : IComparable<Path>
	{
		// Список слов в пути
		private readonly Word[] words;
		// Приоритет пути
		private readonly int _priority;
		/// <summary>
		/// Создать экземпляр пути в графе.
		/// </summary>
		/// <param name="prevPath">Предыдущий путь (может быть null)</param>
		/// <param name="newWord">Новое слово, добавляемое к предыдущему пути</param>
		/// <param name="finish">Конечное слово для вычисления приоритета</param>
		public Path(Path prevPath, Word newWord, Word finish)
		{
			if (prevPath != null)
			{
				// Если предыдущий путь задан, копируем слова из него и добавляем новое
				words = new Word[prevPath.Length + 1];
				Array.Copy(prevPath.words, words, prevPath.Length);
			}
			else
				// Иначе создаём список из одного слова
				words = new Word[1];
			// Записываем новое слово в конец пути
			words[words.Length - 1] = newWord;
			// Приоритет равен пройденному расстоянию и 
			// оценочному оставшемуся расстоянию до конечного слова
			// Т.о. при сортировке по возрастанию в начале всегда лучший элемент
			_priority = newWord.DistanceTo(finish) + words.Length;
		}
		/// <summary>
		/// Длина пройденного пути
		/// </summary>
		public int Length
		{
			get { return words.Length; }
		}
		/// <summary>
		/// Последнее слово в пути
		/// </summary>
		public Word Last
		{
			get
			{
				return words.Length > 0
					? words[words.Length - 1]
					: default(Word);
			}
		}
		/// <summary>
		/// Приоритет пути
		/// </summary>
		public int Priority
		{
			get { return _priority; }
		}
		/// <summary>
		/// Метод сравнения для сортировки в списке
		/// </summary>
		public int CompareTo(Path other)
		{
			// Сортируем по возрастанию приоритета
			return Priority - other.Priority;
		}
		/// <summary>
		/// Строковое представление пути
		/// </summary>
		/// <returns>Список слов через перевод строки</returns>
		public override string ToString()
		{
			StringBuilder bld = new StringBuilder();
			foreach (var item in words)
			{
				bld.AppendLine(item.Text);
			}
			return bld.ToString();
		}
	}
}
