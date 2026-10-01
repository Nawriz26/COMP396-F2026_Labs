/*
** File           : FactoryDemoManager.cs
** Student        : Nawriz Ibrahim
** Student Number : 301161181
** Course         : COMP396 - Game Programming 2
** Assignment     : Individual Assignment 1 - FSM and Factory Pattern
** Date           : September 30, 2026
** Description    : Demonstrates the NPC Factory using keyboard input.
*/

using UnityEngine;
using UnityEngine.InputSystem;

namespace Assignment1.Factory
{
    public class FactoryDemoManager : MonoBehaviour
    {
        [SerializeField] private NPCFactory npcFactory;
        [SerializeField] private Transform guardSpawnPoint;
        [SerializeField] private Transform scoutSpawnPoint;
        [SerializeField] private Transform heavySpawnPoint;

        private void Update()
        {
            if (Keyboard.current == null || npcFactory == null)
            {
                return;
            }

            if (Keyboard.current.digit1Key.wasPressedThisFrame)
            {
                CreateNPC(NPCType.Guard, guardSpawnPoint);
            }
            else if (Keyboard.current.digit2Key.wasPressedThisFrame)
            {
                CreateNPC(NPCType.Scout, scoutSpawnPoint);
            }
            else if (Keyboard.current.digit3Key.wasPressedThisFrame)
            {
                CreateNPC(NPCType.Heavy, heavySpawnPoint);
            }
        }

        private void CreateNPC(
            NPCType npcType,
            Transform spawnPoint)
        {
            if (spawnPoint == null)
            {
                Debug.LogError(
                    npcType + " spawn point has not been assigned.");
                return;
            }

            npcFactory.CreateNPC(
                npcType,
                spawnPoint.position);
        }
    }
}