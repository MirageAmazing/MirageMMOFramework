using System;
using System.Linq;
using System.Collections.Generic;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;


namespace FlowCanvas.Macros{

	[Serializable]
	public class MacroPortDefinition{
		
		[SerializeField]
		private string _ID;
		[SerializeField]
		private string _name;
		[SerializeField]
		private string _type;

		[NonSerialized]
		private Type resolvedType;

		public string ID{
			get
			{
				if (string.IsNullOrEmpty(_ID)){ //for correct update prior versions
					_ID = name;
				}
				return _ID;
			}
			private set {_ID = value;}
		}

		public Type type{
			get {return resolvedType != null? resolvedType : resolvedType = ReflectionTools.GetType(_type);}
			private set {_type = value.FullName;}
		}

		public string name{
			get {return _name;}
			set {_name = value;}
		}

		public MacroPortDefinition(string name, Type type){
			this.ID = System.Guid.NewGuid().ToString();
			this.type = type;
			this.name = name;
		}
	}



	public class Macro : FlowGraph {

		///The list of input port definition of the macro
		public List<MacroPortDefinition> inputDefinitions = new List<MacroPortDefinition>();
		///The list of output port definition of the macro
		public List<MacroPortDefinition> outputDefinitions = new List<MacroPortDefinition>();

		[NonSerialized]
		public Dictionary<string, Action<Flow>> entryActionMap   = new Dictionary<string, Action<Flow>>(StringComparer.Ordinal);
		[NonSerialized]
		public Dictionary<string, Action<Flow>> exitActionMap    = new Dictionary<string, Action<Flow>>(StringComparer.Ordinal);
		[NonSerialized]
		public Dictionary<string, Func<object>> entryFunctionMap = new Dictionary<string, Func<object>>(StringComparer.Ordinal);
		[NonSerialized]
		public Dictionary<string, Func<object>> exitFunctionMap  = new Dictionary<string, Func<object>>(StringComparer.Ordinal);

		private MacroInputNode _entry;
		private MacroOutputNode _exit;


		public override bool useLocalBlackboard{
			get {return true;}
		}

		///The entry node of the Macro (input ports)
		public MacroInputNode entry{
			get
			{
				if (_entry == null){
					_entry = allNodes.OfType<MacroInputNode>().FirstOrDefault();
					if (_entry == null){
						_entry = AddNode<MacroInputNode>(new Vector2(-translation.x + 200, -translation.y + 200));
					}
				}
				return _entry;
			}
		}

		///The exit node of the Macro (output ports)
		public MacroOutputNode exit
		{
			get
			{
				if (_exit == null){
					_exit = allNodes.OfType<MacroOutputNode>().FirstOrDefault();
					if (_exit == null){
						_exit = AddNode<MacroOutputNode>(new Vector2(-translation.x + 600, -translation.y + 200));
					}
				}
				return _exit;
			}
		}

		///validates the entry & exit references
		protected override void OnGraphValidate(){
			base.OnGraphValidate();
			_entry = null;
			_exit = null;
			_entry = entry;
			_exit = exit;
			//create initial ports in case there are none in both entry and exit
			if (inputDefinitions.Count == 0 && outputDefinitions.Count == 0){
				var defIn = new MacroPortDefinition("In", typeof(Flow));
				var defOut = new MacroPortDefinition("Out", typeof(Flow));
				inputDefinitions.Add( defIn );
				outputDefinitions.Add( defOut );
				entry.GatherPorts();
				exit.GatherPorts();
				var source = entry.GetOutputPort( defIn.ID );
				var target = exit.GetInputPort( defOut.ID );
				BinderConnection.Create(source, target);
			}
		}

		///Adds a new input port definition to the Macro
		public bool AddInputDefinition(MacroPortDefinition def){
			if (inputDefinitions.Find(d => d.ID == def.ID) == null){
				inputDefinitions.Add(def);
				return true;
			}
			return false;
		}

		///Adds a new output port definition to the Macro
		public bool AddOutputDefinition(MacroPortDefinition def){
			if (outputDefinitions.Find(d => d.ID == def.ID) == null){
				outputDefinitions.Add(def);
				return true;
			}
			return false;
		}
	}
}