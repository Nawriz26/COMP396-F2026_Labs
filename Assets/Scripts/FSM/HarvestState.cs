using UnityEngine;
using UnityEngine.AI;

namespace Core.FSM
{
    public class HarvestState : BaseState
    {
        private GameObject harvestingPlot;

        //private UnityEngine.AI.NavMeshAgent agent;


        public HarvestState(MeshRenderer renderer, UnityEngine.AI.NavMeshAgent agent) : base(renderer, agent)
        {
        }

        public override void Enter()
        {
            meshRenderer.material.color = Color.green;
            harvestingPlot = GameObject.FindWithTag("HarvestingPlot");
            agent.SetDestination(harvestingPlot.transform.position);
            agent.isStopped = false;
        }

        public override void Update()
        {
            
        }

        public override void Exit()
        {
            base.Exit();
            harvestingPlot = null;
            
        }
    }
}