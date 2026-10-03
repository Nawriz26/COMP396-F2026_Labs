/*
** File           : FactoryNPC.cs
** Student        : Nawriz Ibrahim
** Student Number : 301161181
** Course         : COMP396 - Game Programming 2
** Assignment     : Individual Assignment 1 - FSM and Factory Pattern
** Date           : September 30, 2026
** Description    : Stores and applies the properties of an NPC created by the factory.
*/

using UnityEngine;

namespace Assignment1.Factory
{
    [RequireComponent(typeof(MeshRenderer))]
    public class FactoryNPC : MonoBehaviour
    {
        [SerializeField] private NPCType npcType;
        [SerializeField] private int health;
        [SerializeField] private float movementSpeed;

        public NPCType Type => npcType;
        public int Health => health;
        public float MovementSpeed => movementSpeed;

        public void Initialize(
            NPCType type,
            int startingHealth,
            float speed,
            Color displayColor,
            Vector3 displayScale)
        {
            npcType = type;
            health = startingHealth;
            movementSpeed = speed;

            gameObject.name = type + " NPC";
            transform.localScale = displayScale;

            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            meshRenderer.material.color = displayColor;

            Debug.Log(
                type + " configured — Health: " +
                health + ", Speed: " + movementSpeed);
        }

        private void Update()
        {
            // Slowly rotate the NPC so its factory-created appearance is visible.
            //transform.Rotate(
            //    Vector3.up,
            //    movementSpeed * 15f * Time.deltaTime);
            transform.Rotate(
                Vector3.forward,
                movementSpeed * 15f * Time.deltaTime);
        }
    }
}