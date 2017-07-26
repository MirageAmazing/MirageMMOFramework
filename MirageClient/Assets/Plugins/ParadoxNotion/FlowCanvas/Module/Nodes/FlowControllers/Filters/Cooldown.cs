using System.Collections;
using UnityEngine;
using ParadoxNotion.Design;

namespace FlowCanvas.Nodes{
	
	[Category("Flow Controllers/Filters")]
	[Description("Filters OUT so that it can't be called very frequently")]
	[ContextDefinedInputs(typeof(float))]
	[ContextDefinedOutputs(typeof(float))]
	public class Cooldown : FlowControlNode {
		
		private float current = 0;
		private Coroutine routine;
		
		public override string name{
			get {return base.name + string.Format(" [{0}]", current.ToString("0.0"));}
		}

		protected override void RegisterPorts(){
			var o = AddFlowOutput("Out");
			var ready = AddFlowOutput("Ready");
			var time = AddValueInput<float>("Time");
			AddValueOutput<float>("Current", ()=>{ return Mathf.Max(current, 0); } );
			AddFlowInput("In", (f)=>
			{
				if (current <= 0 && routine == null){
					current = time.value;
					routine = StartCoroutine(CountDown(ready, f));
					o.Call(f);
				}
			});

			AddFlowInput("Cancel", (f)=>
			{
				if (routine != null){
					StopCoroutine(routine);
					routine = null;
					current = 0;
				}
			});
		}

		IEnumerator CountDown(FlowOutput ready, Flow f){
			while (current > 0){
				current -= Time.deltaTime;
				yield return null;
			}
			routine = null;
			ready.Call(f);
		}
	}
}