using WUG.BehaviorTreeVisualizer;

namespace Sources.BoundedContexts.AI
{
	public class Sequence : Composite
	{
		public Sequence(string displayName, params Node[] childNodes) : base(displayName, childNodes)
		{
		}

		protected override NodeStatus OnRun()
		{
			NodeStatus childNodeStatus = (ChildNodes[CurrentChildIndex] as Node).Run();

			switch (childNodeStatus)
			{
				case NodeStatus.Failure:
					return childNodeStatus;
				case NodeStatus.Success:
					CurrentChildIndex++;
					break;
			}

			if (CurrentChildIndex >= ChildNodes.Count)
				return NodeStatus.Success;

			return childNodeStatus == NodeStatus.Success ? OnRun() : NodeStatus.Running;
		}

		protected override void OnReset()
		{
			CurrentChildIndex = 0;

			for (int i = 0; i < ChildNodes.Count; i++)
				(ChildNodes[i] as Node)?.Reset();
		}
	}
}