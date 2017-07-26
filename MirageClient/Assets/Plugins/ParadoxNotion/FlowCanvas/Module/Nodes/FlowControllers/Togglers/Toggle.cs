﻿using ParadoxNotion.Design;

namespace FlowCanvas.Nodes{

	[Category("Flow Controllers/Togglers")]
	[Description("When In is called, calls On or Off depending on the current toggle state. Whenever Toggle input is called the state changes.")]
	public class Toggle : FlowControlNode {

		public bool open = true;
		
		public override string name {
			get {return base.name + " " + (open? "[ON]" : "[OFF]");}
		}
		protected override void RegisterPorts(){
			var tOut = AddFlowOutput("On");
			var fOut = AddFlowOutput("Off");
			AddFlowInput("In", (f)=> { Call( open? tOut : fOut, f ); });
			AddFlowInput("Toggle", (f)=> { open = !open; });
		}
	}
}