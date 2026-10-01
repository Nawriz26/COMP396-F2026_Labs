/*
** File           : EnemyChaseState.cs
** Student        : Nawriz Ibrahim
** Student Number : 301161181
** Course         : COMP396 - Game Programming 2
** Assignment     : Individual Assignment 1 - FSM and Factory Pattern
** Date           : September 30, 2026
** Description    : Makes the NPC follow the player after detecting them.
*/

using Assignment1.Events;
using UnityEngine;
using UnityEngine.AI;

namespace Core.FSM
{
    public class EnemyChaseState : BaseState
    {
        private readonly Transform player;

        public EnemyChaseState(
            MeshRenderer renderer,
            NavMeshAgent agent,
            Transform player)
            : base(renderer, agent)
        {
            this.player = player;
        }

        public override void Enter()
        {
            // Begin chasing after the NPC detects the player.
            meshRenderer.material.color = new Color(1f, 0.5f, 0f);
            agent.isStopped = false;

            NPCEvents.RaiseStateChanged("Chase");
            NPCEvents.RaisePlayerDetected();
        }

        public override void Update()
        {
            // Continuously update the destination to the player's position.
            if (player != null)
            {
                agent.SetDestination(player.position);
            }
        }

        public override void Exit()
        {
            // Stop chasing before entering Attack or Return.
            base.Exit();
        }
    }
}