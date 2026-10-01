/*
** File           : NPCEventLogger.cs
** Student        : Nawriz Ibrahim
** Student Number : 301161181
** Course         : COMP396 - Game Programming 2
** Assignment     : Individual Assignment 1 - FSM and Factory Pattern
** Date           : September 30, 2026
** Description    : Listens for NPC events and displays them in the Console.
*/

using UnityEngine;

namespace Assignment1.Events
{
    public class NPCEventLogger : MonoBehaviour
    {
        private void OnEnable()
        {
            NPCEvents.StateChanged += HandleStateChanged;
            NPCEvents.PlayerDetected += HandlePlayerDetected;
            NPCEvents.AttackPerformed += HandleAttackPerformed;
            NPCEvents.NPCSpawned += HandleNPCSpawned;
        }

        private void OnDisable()
        {
            NPCEvents.StateChanged -= HandleStateChanged;
            NPCEvents.PlayerDetected -= HandlePlayerDetected;
            NPCEvents.AttackPerformed -= HandleAttackPerformed;
            NPCEvents.NPCSpawned -= HandleNPCSpawned;
        }

        private void HandleStateChanged(string stateName)
        {
            Debug.Log("NPC entered state: " + stateName);
        }

        private void HandlePlayerDetected()
        {
            Debug.Log("Event: The NPC detected the player.");
        }

        private void HandleAttackPerformed()
        {
            Debug.Log("Event: The NPC performed an attack.");
        }

        private void HandleNPCSpawned(GameObject npc)
        {
            Debug.Log("Factory created NPC: " + npc.name);
        }
    }
}