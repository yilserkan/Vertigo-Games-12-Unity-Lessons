using System;
using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Inventory;
using TopDownShooter.PlayerControls;
using UnityEngine;

namespace TopDownShooter.AI
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] private PlayerMovementController playerMovementController;
        [SerializeField] private TowerRotationController towerRotationController;
        [SerializeField] private PlayerInventoryController playerInventoryController;
        
        [SerializeField] private InputDataAI aiMovementInputData;
        [SerializeField] private InputDataAI aiRotationInputData;

        [SerializeField] private Transform movementTarget;
        [SerializeField] private Transform rotationTarget;
        
        private void Awake()
        {
            aiMovementInputData = Instantiate(aiMovementInputData);
            aiRotationInputData = Instantiate(aiRotationInputData);
            
            playerMovementController.InitializeInputData(aiMovementInputData);
            towerRotationController.InitializeInputData(aiRotationInputData);
            
        
        }

        private void Update()
        {
            aiMovementInputData.SetTarget(transform, movementTarget.position);
            aiRotationInputData.SetTarget(towerRotationController.Tower, rotationTarget.position);
            
            aiMovementInputData.ProcessInput();
            aiRotationInputData.ProcessInput();

            if (Mathf.Abs(aiRotationInputData.Horizontal) < .25f && Vector3.Distance(rotationTarget.position, transform.position ) < 5)
            {
                playerInventoryController.ReactiveShootCommand.Execute();
            }
            
        }
    }
}