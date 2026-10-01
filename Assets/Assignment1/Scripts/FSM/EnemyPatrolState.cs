/*
** File           : EnemyPatrolState.cs
** Student        : Nawriz Ibrahim
** Student Number : 301161181
** Course         : COMP396 - Game Programming 2
** Assignment     : Individual Assignment 1 - FSM and Factory Pattern
** Date           : September 30, 2026
** Description    : Moves the NPC continuously between assigned patrol points.
*/

using Assignment1.Events;
using UnityEngine;
using UnityEngine.AI;

namespace Core.FSM
{
    public class EnemyPatrolState : BaseState
    {
        private readonly Transform[] waypoints;
        private int waypointIndex;

        public EnemyPatrolState(
            MeshRenderer renderer,
            NavMeshAgent agent,
            Transform[] waypoints)
            : base(renderer, agent)
        {
            this.waypoints = waypoints;
        }

        public override void Enter()
        {
            // Start moving toward the current patrol point.
            meshRenderer.material.color = Color.yellow;
            agent.isStopped = false;

            NPCEvents.RaiseStateChanged("Patrol");
            MoveToCurrentWaypoint();
        }

        public override void Update()
        {
            // Move to the next waypoint after reaching the current one.
            if (waypoints == null || waypoints.Length == 0)
            {
                return;
            }

            if (!agent.pathPending &&
                agent.remainingDistance <= agent.stoppingDistance)
            {
                waypointIndex = (waypointIndex + 1) % waypoints.Length;
                MoveToCurrentWaypoint();
            }
        }

        public override void Exit()
        {
            // Stop patrolling before another state begins.
            base.Exit();
        }

        private void MoveToCurrentWaypoint()
        {
            if (waypoints == null || waypoints.Length == 0)
            {
                return;
            }

            agent.SetDestination(waypoints[waypointIndex].position);
        }
    }
}