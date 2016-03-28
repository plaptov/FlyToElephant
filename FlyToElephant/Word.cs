using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyToElephant
{
	/// <summary>
	/// Класс, описывающий слово (узел) в графе
	/// </summary>
	public class Word
	{
		/// <summary>
		/// Создать экземпляр слова
		/// </summary>
		/// <param name="word">Текстовое значение слова</param>
		public Word(string word)
		{
			Text = word;
		}
		/// <summary>
		/// Текстовое значение слова
		/// </summary>
		public string Text { get; private set; }
		/// <summary>
		/// Хэш-код слова равен хэш-коду текстового значения.
		/// Необходим для хэш-таблиц.
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return Text.GetHashCode();
		}

		public override string ToString()
		{
			return Text;
		}
		/// <summary>
		/// Сравнение слов производится по текстовым значениям
		/// </summary>
		public override bool Equals(object obj)
		{
			if (obj is Word)
				return this == (Word)obj;
			return base.Equals(obj);
		}
		/// <summary>
		/// Сравнение слов производится по текстовым значениям
		/// </summary>
		public static bool operator ==(Word w1, Word w2)
		{
			return w1.Text == w2.Text;
		}
		/// <summary>
		/// Сравнение слов производится по текстовым значениям
		/// </summary>
		public static bool operator !=(Word w1, Word w2)
		{
			return w1.Text != w2.Text;
		}
		/// <summary>
		/// Рассчитыть расстояние между словами.
		/// Расстояние равно кол-ву различающихся букв.
		/// </summary>
		/// <param name="word">Другое слово</param>
		public int DistanceTo(Word word)
		{
			int dist = 0;
			for (int i = 0; i < Text.Length; i++)
			{
				if (Text[i] != word.Text[i])
					dist++;
			}
			return dist;
		}
		/// <summary>
		/// Определяет, разница между словами только в одну букву или нет.
		/// </summary>
		/// <param name="word">Другое слово</param>
		public bool IsOnlyOneLetterDiffWith(Word word)
		{
			int dist = 0;
			for (int i = 0; i < Text.Length; i++)
			{
				if (Text[i] != word.Text[i])
					// Экономия времени за счёт того, что нет необходимости
					// Пробегать всё слово целиком
					if (dist == 1)
						return false;
					else
						dist++;
			}
			return dist == 1;
		}
	}
}
