/*
** File           : EnemyAttackState.cs
** Student        : Nawriz Ibrahim
** Student Number : 301161181
** Course         : COMP396 - Game Programming 2
** Assignment     : Individual Assignment 1 - FSM and Factory Pattern
** Date           : September 30, 2026
** Description    : Makes the NPC face the player and attack repeatedly.
*/

using Assignment1.Events;
using UnityEngine;
using UnityEngine.AI;

namespace Core.FSM
{
    public class EnemyAttackState : BaseState
    {
        private readonly Transform player;
        private readonly float attackCooldown;
        private float attackTimer;

        public EnemyAttackState(
            MeshRenderer renderer,
            NavMeshAgent agent,
            Transform player,
            float attackCooldown)
            : base(renderer, agent)
        {
            this.player = player;
            this.attackCooldown = attackCooldown;
        }

        public override void Enter()
        {
            // Stop moving and prepare to attack the nearby player.
            agent.isStopped = true;
            attackTimer = 0f;
            meshRenderer.material.color = Color.red;

            NPCEvents.RaiseStateChanged("Attack");
        }

        public override void Update()
        {
            // Face the player and perform an attack after each cooldown.
            FacePlayer();

            attackTimer += Time.deltaTime;

            if (attackTimer >= attackCooldown)
            {
                attackTimer = 0f;
                NPCEvents.RaiseAttackPerformed();
            }
        }

        public override void Exit()
        {
            // Stop attacking before chasing or returning to patrol.
            base.Exit();
            attackTimer = 0f;
        }

        private void FacePlayer()
        {
            if (player == null)
            {
                return;
            }

            Vector3 direction =
                player.position - meshRenderer.transform.position;

            direction.y = 0f;

            if (direction.sqrMagnitude > 0.001f)
            {
                Quaternion targetRotation =
                    Quaternion.LookRotation(direction);

                meshRenderer.transform.rotation =
                    Quaternion.Slerp(
                        meshRenderer.transform.rotation,
                        targetRotation,
                        5f * Time.deltaTime);
            }
        }
    }
}