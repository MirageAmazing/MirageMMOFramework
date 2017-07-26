using UnityEngine;
using System.Collections;
using ParadoxNotion.Design;
using UnityEngine.AI;

namespace FlowCanvas.Nodes{

	[Category("Functions/Navigation")]
	[Description("Moves a NavMeshAgent object with pathfinding to target destination")]
	public class MoveTo : LatentActionNode<NavMeshAgent, Vector3, float, float>{
		public override IEnumerator Invoke(NavMeshAgent agent, Vector3 destination, float speed, float stoppingDistance){
			agent.speed = speed;
			agent.stoppingDistance = stoppingDistance;
			if (agent.speed > 0){
				agent.SetDestination(destination);
			} else {
				agent.Warp(destination);
			}
			while (agent.pathPending || agent.remainingDistance > stoppingDistance){
				yield return null;
			}
		}
	}
}