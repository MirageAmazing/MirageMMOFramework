using ParadoxNotion.Design;

namespace FlowCanvas.Nodes{

	[Category("Flow Controllers")]
	abstract public class FlowControlNode : FlowNode {

		public override string name{
			get{return string.Format("<color=#bf7fff>{0}</color>", base.name);}
		}
	}
}