/*
** File           : EnemyFSMController.cs
** Student        : Nawriz Ibrahim
** Student Number : 301161181
** Course         : COMP396 - Game Programming 2
** Assignment     : Individual Assignment 1 - FSM and Factory Pattern
** Date           : September 30, 2026
** Description    : Creates and controls the enemy NPC's five-state FSM.
*/

using UnityEngine;
using UnityEngine.AI;

namespace Core.FSM
{
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyFSMController : MonoBehaviour
    {
        [Header("Required References")]
        [SerializeField] private Transform player;
        [SerializeField] private Transform[] waypoints;
        [SerializeField] private Transform returnPoint;

        [Header("FSM Settings")]
        [SerializeField] private float idleDuration = 2f;
        [SerializeField] private float detectionRange = 8f;
        [SerializeField] private float attackRange = 2.5f;
        [SerializeField] private float losePlayerRange = 12f;
        [SerializeField] private float attackCooldown = 1.5f;

        private StateMachine stateMachine;

        private void Awake()
        {
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            NavMeshAgent agent = GetComponent<NavMeshAgent>();

            stateMachine = new StateMachine();

            EnemyIdleState idle = new EnemyIdleState(
                meshRenderer,
                agent,
                idleDuration);

            EnemyPatrolState patrol = new EnemyPatrolState(
                meshRenderer,
                agent,
                waypoints);

            EnemyChaseState chase = new EnemyChaseState(
                meshRenderer,
                agent,
                player);

            EnemyAttackState attack = new EnemyAttackState(
                meshRenderer,
                agent,
                player,
                attackCooldown);

            EnemyReturnState returnState = new EnemyReturnState(
                meshRenderer,
                agent,
                returnPoint);

            // Idle -> Patrol when the waiting timer finishes.
            stateMachine.AddTransition(
                idle,
                patrol,
                new FuncPredicate(() => idle.IsFinished));

            // Patrol -> Chase when the player enters detection range.
            stateMachine.AddTransition(
                patrol,
                chase,
                new FuncPredicate(() =>
                    GetPlayerDistance() <= detectionRange));

            // Chase -> Attack when the player is close enough.
            stateMachine.AddTransition(
                chase,
                attack,
                new FuncPredicate(() =>
                    GetPlayerDistance() <= attackRange));

            // Attack -> Chase when the player moves away but is still visible.
            stateMachine.AddTransition(
                attack,
                chase,
                new FuncPredicate(() =>
                    GetPlayerDistance() > attackRange &&
                    GetPlayerDistance() <= losePlayerRange));

            // Chase -> Return when the NPC loses the player.
            stateMachine.AddTransition(
                chase,
                returnState,
                new FuncPredicate(() =>
                    GetPlayerDistance() > losePlayerRange));

            // Attack -> Return if the player escapes completely.
            stateMachine.AddTransition(
                attack,
                returnState,
                new FuncPredicate(() =>
                    GetPlayerDistance() > losePlayerRange));

            // Return -> Patrol after reaching the patrol area.
            stateMachine.AddTransition(
                returnState,
                patrol,
                new FuncPredicate(() =>
                    returnState.HasReachedReturnPoint));

            stateMachine.SetState(idle);
        }

        private void Update()
        {
            stateMachine.Update();
        }

        private float GetPlayerDistance()
        {
            if (player == null)
            {
                return Mathf.Infinity;
            }

            return Vector3.Distance(transform.position, player.position);
        }
    }
}