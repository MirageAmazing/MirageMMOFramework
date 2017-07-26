﻿using UnityEngine;
using System.Collections;
using ParadoxNotion.Design;

namespace FlowCanvas.Nodes{

	[Name("OR")]
	[Category("Flow Controllers/Flow Merge")]
	[Description("Calls Out when either input is called")]
	public class ORMerge : FlowControlNode, IMultiPortNode {

		private FlowOutput fOut;

		[SerializeField]
		private int _portCount = 2;
		public int portCount{
			get {return _portCount;}
			set {_portCount = value;}
		}
		
		protected override void RegisterPorts(){
			fOut = AddFlowOutput("Out");
			for (var _i = 0; _i < portCount; _i++){
				var i = _i;
				AddFlowInput(i.ToString(), (f)=> { fOut.Call(f); } );
			}
		}
	}
}