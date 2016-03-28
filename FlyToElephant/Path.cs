using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyToElephant
{
	public class Path : IComparable<Path>
	{
		private readonly Word[] words;
		private readonly int _priority;

		public Path(Path prevPath, Word newWord, Word finish)
		{
			if (prevPath != null)
			{
				words = new Word[prevPath.Length + 1];
				Array.Copy(prevPath.words, words, prevPath.Length);
			}
			else
				words = new Word[1];
			words[words.Length - 1] = newWord;
			_priority = newWord.DistanceTo(finish) + words.Length;
		}

		public int Length
		{
			get { return words.Length; }
		}

		public Word Last
		{
			get
			{
				return words.Length > 0
					? words[words.Length - 1]
					: default(Word);
			}
		}

		public int Priority
		{
			get { return _priority; }
		}

		public int CompareTo(Path other)
		{
			return Priority - other.Priority;
		}

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
