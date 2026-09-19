using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace Core.FSM
{
    [RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
    public class NPCStateMachine : MonoBehaviour
    {
        StateMachine stateMachine;

        private void Awake()
        {
            // Creation of the StateMachine
            stateMachine = new StateMachine();
            MeshRenderer renderer = GetComponent<MeshRenderer>();
            UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

            // Create instances for concrete stateNodes
            PatrolState patrol = new PatrolState(renderer, agent, new GameObject[2]);
            HarvestState harvest = new HarvestState(renderer, agent);
            RestState rest = new RestState(renderer, agent);

            // Two extra village states required by the Lab 2 challenge
            GuardState guard = new GuardState(renderer, agent);
            BlacksmithState blacksmith = new BlacksmithState(renderer, agent);

            stateMachine.AddTransition(
                rest,
                patrol,
                new FuncPredicate(() =>
                    Keyboard.current.pKey.wasPressedThisFrame));

            stateMachine.AddTransition(
                rest,
                harvest,
                new FuncPredicate(() =>
                    Keyboard.current.hKey.wasPressedThisFrame));

            stateMachine.AddTransition(
                harvest,
                rest,
                new FuncPredicate(() =>
                    Keyboard.current.rKey.wasPressedThisFrame));
            stateMachine.AddTransition(
                patrol,
                rest,
                new FuncPredicate(() =>
                    Keyboard.current.rKey.wasPressedThisFrame));

            // Guard state transitions
           stateMachine.AddTransition(
                rest,
                guard,
                new FuncPredicate(() =>
                    Keyboard.current.gKey.wasPressedThisFrame));
            stateMachine.AddTransition(
                guard,
                rest,
                new FuncPredicate(() =>
                    Keyboard.current.rKey.wasPressedThisFrame));

            // Blacksmith state transitions
            stateMachine.AddTransition(
                rest,
                blacksmith,
                new FuncPredicate(() =>
                    Keyboard.current.bKey.wasPressedThisFrame));
            stateMachine.AddTransition(
                blacksmith,
                rest,
                new FuncPredicate(() =>
                    Keyboard.current.rKey.wasPressedThisFrame));

            stateMachine.SetState(rest);
        }

        private void Update()
        {
            stateMachine.Update();
        }
    }
}