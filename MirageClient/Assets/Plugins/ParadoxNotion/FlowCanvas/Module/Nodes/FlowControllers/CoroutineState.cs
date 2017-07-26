using System.Collections;
using ParadoxNotion.Design;

namespace FlowCanvas.Nodes{

	[Name("Coroutine")]
	[Description("Start a Coroutine that will repeat until Break is signaled")]
	public class CoroutineState : FlowControlNode {

		private bool activated = false;

		protected override void RegisterPorts(){
			var fStarted = AddFlowOutput("Start");
			var fUpdate = AddFlowOutput("Update");
			var fFinish = AddFlowOutput("Finish");
			AddFlowInput("Start", (f)=> {
				if (!activated){
					activated = true;
					StartCoroutine(DoRepeat(fStarted, fUpdate, fFinish, f));
				}
			});
			AddFlowInput("Break", (f)=> {
				activated = false;
			});
		}


		IEnumerator DoRepeat(FlowOutput fStarted, FlowOutput fUpdate, FlowOutput fFinish, Flow f){
			fStarted.Call(f);
			while(activated){
				fUpdate.Call(f);
				yield return null;
			}
			fFinish.Call(f);
		}
	}
}