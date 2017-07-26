﻿using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace FlowCanvas.Nodes{

	[Name("Visibility")]
	[Category("Events/Object")]
	[Description("Calls events based on object's render visibility")]
	public class VisibilityEvents : EventNode<Transform> {

		private FlowOutput onVisible;
		private FlowOutput onInvisible;


		protected override string[] GetTargetMessageEvents(){
			return new string[]{ "OnBecameVisible", "OnBecameInvisible" };
		}

		protected override void RegisterPorts(){
			onVisible = AddFlowOutput("Became Visible");
			onInvisible = AddFlowOutput("Became Invisible");
		}

		void OnBecameVisible(){
			onVisible.Call(new Flow(1));
		}

		void OnBecameInvisible(){
			onInvisible.Call(new Flow(1));
		}
	}
}