using UnityEngine;

namespace Core.FSM
{
    public class  BlacksmithState : BaseState
    {
        private float workTimer;

        public BlacksmithState(MeshRenderer renderer, UnityEngine.AI.NavMeshAgent agent) : base(renderer, agent) { }

        public override void Enter()
        {
            // The blacksmith begins a work order, stays at the forge, and heats the metal.
            workTimer = 0f;
            agent.isStopped = true;
            meshRenderer.material.color = new Color(1f, 0.4f, 0f);
        }

        public override void Update()
        {
            // The pulsing color represents reapeated hammer strikes on hot metal.
            workTimer += Time.deltaTime;
            float heat = Mathf.PingPong(workTimer * 2f, 1f);
            meshRenderer.material.color = Color.Lerp(Color.red, Color.yellow, heat);
        }
        public override void Exit()
        {
            // The blacksmith finishes the current item and safely stops work at the forge.
            base.Exit();
            workTimer = 0f;
        }

    }

}