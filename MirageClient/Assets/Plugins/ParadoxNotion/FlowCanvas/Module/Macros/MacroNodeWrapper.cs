﻿using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace FlowCanvas.Macros{

	[DoNotList]
	public class MacroNodeWrapper : FlowNode, IGraphAssignable{

		[SerializeField]
		private Macro _macro = null;
		private bool instantiated = false;

		public override string name{
			get {return string.Format("<color=#CCFFFF>{0}</color>", macro != null? macro.name : "No Macro" );}
		}

		public override string description{
			get {return _macro != null? _macro.graphComments : null;}
		}

		public Macro macro{
			get {return _macro;}
			set
			{
				if (_macro != value){
					_macro = value;
					if (value != null){
						GatherPorts();
					}
				}
			}
		}

		Graph IGraphAssignable.nestedGraph{
			get {return macro;}
			set {macro = (Macro)value;}
		}

		Graph[] IGraphAssignable.GetInstances(){ return instantiated? new Graph[]{_macro} : new Graph[0]; }

		////////

		public void CheckInstance(){

			if (macro == null){
				return;
			}
			
			if (!instantiated){
				instantiated = true;
				macro = Graph.Clone<Macro>(macro);
			}			
		}

		protected override void RegisterPorts(){

			this.nodeComment = macro != null? macro.graphComments : null;
			
			if (macro == null){
				return;
			}

			foreach (var _defIn in macro.inputDefinitions){
				var defIn = _defIn;
				if (defIn.type == typeof(Flow)){
					AddFlowInput(defIn.name, (f)=> {macro.entryActionMap[defIn.ID](f);}, defIn.ID );
				} else {
					macro.entryFunctionMap[defIn.ID] = AddValueInput(defIn.name, defIn.type, defIn.ID).GetValue;
				}
			}

			foreach (var _defOut in macro.outputDefinitions){
				var defOut = _defOut;
				if (defOut.type == typeof(Flow)){
					macro.exitActionMap[defOut.ID] = AddFlowOutput(defOut.name, defOut.ID).Call;
				} else {
					AddValueOutput(defOut.name, defOut.type, ()=> { return macro.exitFunctionMap[defOut.ID](); }, defOut.ID);
				}
			}

		}


		////////////////////////////////////////
		///////////GUI AND EDITOR STUFF/////////
		////////////////////////////////////////
		#if UNITY_EDITOR

		protected override void OnNodeInspectorGUI(){

			if (!Application.isPlaying){
				if (macro != null){
					if (GUILayout.Button("REFRESH PORTS")){
						GatherPorts();
					}
				} else {
					macro = (Macro)UnityEditor.EditorGUILayout.ObjectField("Macro", macro, typeof(Macro), false);
				}
			}

			base.OnNodeInspectorGUI();
		}

		#endif
	}
}