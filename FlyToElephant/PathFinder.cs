using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyToElephant
{
	public class PathFinder
	{
		public static Path FindShortestPath(
			WordsGraph graph, Word start, Word finish)
		{
			if (!graph.ContainsKey(start))
				return null;
			Dictionary<int, Queue<Path>> paths = new Dictionary<int, Queue<Path>>();
			var curPath = new Path(null, start, finish);
			AddPathToStorage(paths, curPath);
			HashSet<Word> usedWords = new HashSet<Word>();
			usedWords.Add(start);
			int minPriority = curPath.Priority;
			while (curPath != null)
			{
				if (paths.Count == 0)
					return null;
				curPath = paths[minPriority].Dequeue();
				if (curPath.Last == finish)
					return curPath;
				if (paths[minPriority].Count == 0)
					paths.Remove(minPriority);
				var steps = graph[curPath.Last];
				if (steps != null)
					foreach (var word in steps)
					{
						if (usedWords.Contains(word))
							continue;
						usedWords.Add(word);
						AddPathToStorage(paths, new Path(curPath, word, finish));
					}
				if (paths.Count > 0)
					minPriority = paths.Keys.Min();
			}
			return null;
		}

		private static void AddPathToStorage(Dictionary<int, Queue<Path>> storage,
			Path path)
		{
			if (!storage.ContainsKey(path.Priority))
				storage.Add(path.Priority, new Queue<Path>());
			storage[path.Priority].Enqueue(path);
		}
	}
}
