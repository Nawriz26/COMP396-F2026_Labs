/*
** File           : NPCEvents.cs
** Student        : Nawriz Ibrahim
** Student Number : 301161181
** Course         : COMP396 - Game Programming 2
** Assignment     : Individual Assignment 1 - FSM and Factory Pattern
** Date           : September 30, 2026
** Description    : Defines events used by the FSM and NPC Factory systems.
*/

using System;
using UnityEngine;

namespace Assignment1.Events
{
    public static class NPCEvents
    {
        public static event Action<string> StateChanged;
        public static event Action PlayerDetected;
        public static event Action AttackPerformed;
        public static event Action<GameObject> NPCSpawned;

        public static void RaiseStateChanged(string stateName)
        {
            StateChanged?.Invoke(stateName);
        }

        public static void RaisePlayerDetected()
        {
            PlayerDetected?.Invoke();
        }

        public static void RaiseAttackPerformed()
        {
            AttackPerformed?.Invoke();
        }

        public static void RaiseNPCSpawned(GameObject npc)
        {
            NPCSpawned?.Invoke(npc);
        }
    }
}