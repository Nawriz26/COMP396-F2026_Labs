/*
** File           : EnemyIdleState.cs
** Student        : Nawriz Ibrahim
** Student Number : 301161181
** Course         : COMP396 - Game Programming 2
** Assignment     : Individual Assignment 1 - FSM and Factory Pattern
** Date           : September 30, 2026
** Description    : Controls the NPC while it waits before patrolling.
*/

using Assignment1.Events;
using UnityEngine;
using UnityEngine.AI;

namespace Core.FSM
{
    public class EnemyIdleState : BaseState
    {
        private readonly float idleDuration;
        private float idleTimer;

        public bool IsFinished => idleTimer >= idleDuration;

        public EnemyIdleState(
            MeshRenderer renderer,
            NavMeshAgent agent,
            float idleDuration)
            : base(renderer, agent)
        {
            this.idleDuration = idleDuration;
        }

        public override void Enter()
        {
            // Stop the NPC and begin its waiting period.
            idleTimer = 0f;
            agent.isStopped = true;
            meshRenderer.material.color = Color.gray;

            NPCEvents.RaiseStateChanged("Idle");
        }

        public override void Update()
        {
            // Count the time until the NPC is ready to patrol.
            idleTimer += Time.deltaTime;
        }

        public override void Exit()
        {
            // Finish waiting before moving to the next state.
            base.Exit();
        }
    }
}