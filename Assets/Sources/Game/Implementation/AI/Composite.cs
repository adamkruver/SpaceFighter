using System.Linq;

namespace Sources.Implementation.AI
{
	public abstract class Composite : Node
	{
		protected int CurrentChildIndex = 0;

		public Composite(string displayName, params Node[] childNodes)
		{
			Name = displayName;
			ChildNodes.AddRange(childNodes.ToList());
		}
	}
}