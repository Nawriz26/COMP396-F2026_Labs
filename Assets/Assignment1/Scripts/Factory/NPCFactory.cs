/*
** File           : NPCFactory.cs
** Student        : Nawriz Ibrahim
** Student Number : 301161181
** Course         : COMP396 - Game Programming 2
** Assignment     : Individual Assignment 1 - FSM and Factory Pattern
** Date           : September 30, 2026
** Description    : Creates and configures different NPC types using a factory method.
*/

using Assignment1.Events;
using UnityEngine;

namespace Assignment1.Factory
{
    public class NPCFactory : MonoBehaviour
    {
        [SerializeField] private FactoryNPC npcPrefab;

        public FactoryNPC CreateNPC(
            NPCType npcType,
            Vector3 spawnPosition)
        {
            if (npcPrefab == null)
            {
                Debug.LogError("NPC Factory is missing its NPC prefab.");
                return null;
            }

            FactoryNPC newNPC = Instantiate(
                npcPrefab,
                spawnPosition,
                Quaternion.identity);

            switch (npcType)
            {
                case NPCType.Guard:
                    newNPC.Initialize(
                        NPCType.Guard,
                        100,
                        3f,
                        Color.blue,
                        new Vector3(1f, 1f, 1f));
                    break;

                case NPCType.Scout:
                    newNPC.Initialize(
                        NPCType.Scout,
                        60,
                        6f,
                        Color.green,
                        new Vector3(0.75f, 0.85f, 0.75f));
                    break;

                case NPCType.Heavy:
                    newNPC.Initialize(
                        NPCType.Heavy,
                        180,
                        1.5f,
                        Color.red,
                        new Vector3(1.3f, 1.3f, 1.3f));
                    break;

                default:
                    Debug.LogWarning("Unknown NPC type requested.");
                    Destroy(newNPC.gameObject);
                    return null;
            }

            NPCEvents.RaiseNPCSpawned(newNPC.gameObject);
            return newNPC;
        }
    }
}