﻿using System;
using System.Linq;
using ParadoxNotion;
using ParadoxNotion.Serialization;
using ParadoxNotion.Serialization.FullSerializer;

namespace NodeCanvas.Framework.Internal{

	///Handles missing Connection serialization and recovery
	public class fsConnectionProcessor : fsObjectProcessor {

		public override bool CanProcess(Type type){
			return typeof(Connection).RTIsAssignableFrom(type);
		}

		public override void OnBeforeDeserialize(Type storageType, ref fsData data){

			if (data.IsNull){
				return;
			}

			var json = data.AsDictionary;

			fsData typeData;
			if (json.TryGetValue("$type", out typeData)){

				var serializedType = ReflectionTools.GetType( typeData.AsString );

				//Handle missing serialized Connection type
				if (serializedType == null){

					serializedType = TryGetReplacement(typeData.AsString);
					if (serializedType != null){
						json["$type"] = new fsData(serializedType.FullName);
						return;
					}

					//inject the 'MissingConnection' type and store recovery serialization state.
					//recoveryState and missingType are serializable members of MissingConnection.
					json["recoveryState"] = new fsData( data.ToString() );
					json["missingType"] = new fsData( typeData.AsString );
					json["$type"] = new fsData( typeof(MissingConnection).FullName );
				}

				//Recover possible found serialized type
				if (serializedType == typeof(MissingConnection)){

					//Does the missing type now exists? If so recover
					var missingType = ReflectionTools.GetType( json["missingType"].AsString );
					
					if (missingType == null){
						missingType = TryGetReplacement( json["missingType"].AsString );
					}

					if (missingType != null){

						var recoveryState = json["recoveryState"].AsString;
						var recoverJson = fsJsonParser.Parse(recoveryState).AsDictionary;

						//merge the recover state *ON TOP* of the current state, thus merging only Declared recovered members
						json = json.Concat( recoverJson.Where( kvp => !json.ContainsKey(kvp.Key) ) ).ToDictionary( c => c.Key, c => c.Value );
						json["$type"] = new fsData( missingType.FullName );
						data = new fsData( json );
					}
				}
			}
		}

		Type TryGetReplacement(string targetFullTypeName){
			var typeNameWithoutNS = targetFullTypeName.Split('.').LastOrDefault();
			foreach(var type in ReflectionTools.GetAllTypes()){
				if (type.Name == typeNameWithoutNS && type.RTIsSubclassOf(typeof(NodeCanvas.Framework.Connection))){
					return type;
				}
			}

			return null;		
		}
	}
}