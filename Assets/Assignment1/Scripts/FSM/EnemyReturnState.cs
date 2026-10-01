/*
** File           : EnemyReturnState.cs
** Student        : Nawriz Ibrahim
** Student Number : 301161181
** Course         : COMP396 - Game Programming 2
** Assignment     : Individual Assignment 1 - FSM and Factory Pattern
** Date           : September 30, 2026
** Description    : Returns the NPC to its patrol area after losing the player.
*/

using Assignment1.Events;
using UnityEngine;
using UnityEngine.AI;

namespace Core.FSM
{
    public class EnemyReturnState : BaseState
    {
        private readonly Transform returnPoint;

        public bool HasReachedReturnPoint
        {
            get
            {
                return !agent.pathPending &&
                       agent.remainingDistance <= agent.stoppingDistance;
            }
        }

        public EnemyReturnState(
            MeshRenderer renderer,
            NavMeshAgent agent,
            Transform returnPoint)
            : base(renderer, agent)
        {
            this.returnPoint = returnPoint;
        }

        public override void Enter()
        {
            // Begin moving back to the NPC's patrol area.
            meshRenderer.material.color = Color.blue;
            agent.isStopped = false;

            NPCEvents.RaiseStateChanged("Return");

            if (returnPoint != null)
            {
                agent.SetDestination(returnPoint.position);
            }
        }

        public override void Update()
        {
            // Continue updating the destination until the return point is reached.
            if (returnPoint != null)
            {
                agent.SetDestination(returnPoint.position);
            }
        }

        public override void Exit()
        {
            // Finish returning before the NPC resumes patrolling.
            base.Exit();
        }
    }
}