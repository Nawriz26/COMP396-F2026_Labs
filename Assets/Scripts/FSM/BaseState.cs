using UnityEngine;
using UnityEngine.AI;

namespace Core.FSM
{
    public abstract class BaseState : IState
    {
        protected MeshRenderer meshRenderer;

        protected UnityEngine.AI.NavMeshAgent agent;
        protected BaseState(MeshRenderer meshRenderer, UnityEngine.AI.NavMeshAgent agent)
        {
            this.meshRenderer = meshRenderer;
            this.agent = agent;
        }
        public virtual void Enter() { }
        public virtual void Update() {
        
            
        }
        public virtual void Exit() {

            agent.isStopped = true;
        }
    }

}