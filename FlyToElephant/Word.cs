using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyToElephant
{
	public class Word
	{
		public Word(string word)
		{
			Text = word;
		}

		public string Text { get; private set; }

		public override int GetHashCode()
		{
			return Text.GetHashCode();
		}

		public override string ToString()
		{
			return Text;
		}

		public override bool Equals(object obj)
		{
			if (obj is Word)
				return this == (Word)obj;
			return base.Equals(obj);
		}

		public static bool operator ==(Word w1, Word w2)
		{
			return w1.Text == w2.Text;
		}

		public static bool operator !=(Word w1, Word w2)
		{
			return w1.Text != w2.Text;
		}

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

		public bool IsOnlyOneLetterDiffWith(Word word)
		{
			int dist = 0;
			for (int i = 0; i < Text.Length; i++)
			{
				if (Text[i] != word.Text[i])
					if (dist == 1)
						return false;
					else
						dist++;
			}
			return dist == 1;
		}
	}
}
