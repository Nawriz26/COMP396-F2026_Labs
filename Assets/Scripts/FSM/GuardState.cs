using UnityEngine;

namespace Core.FSM
{
    public class GuardState : BaseState
    {
        public GuardState(MeshRenderer renderer, UnityEngine.AI.NavMeshAgent agent) : base(renderer, agent)
        {
        }

        public override void Enter()
        {
            // The guard arrives at the watch post, stops walking, and becomes alert.
            meshRenderer.material.color = Color.blue;
            agent.isStopped = true;
        }

        public override void Update()
        {
            // The guard slowly turns to scan the village for possible danger.
            meshRenderer.transform.Rotate(0f, 30f * Time.deltaTime, 0f);
        }

        public override void Exit()
        {
            // The guard ends the watch shift and stops before enetring another state.
            base.Exit();
        }
    }

}