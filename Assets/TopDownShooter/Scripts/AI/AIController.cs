using System;
using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Inventory;
using TopDownShooter.PlayerControls;
using UnityEngine;
using UniRx;

namespace TopDownShooter.AI
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] private PlayerMovementController playerMovementController;
        [SerializeField] private TowerRotationController towerRotationController;
        [SerializeField] private PlayerInventoryController playerInventoryController;
        
        [SerializeField] private InputDataAI aiMovementInputData;
        [SerializeField] private InputDataAI aiRotationInputData;

        // [SerializeField] private Transform movementTarget;
        // [SerializeField] private Transform rotationTarget;

        [SerializeField] private List<AITarget> targetsList = new List<AITarget>();

        private CompositeDisposable _targetDispose;
        
        private Transform _targetTransform;
        private bool _hasTarget;

        private void Awake()
        {
            aiMovementInputData = Instantiate(aiMovementInputData);
            aiRotationInputData = Instantiate(aiRotationInputData);
            
            playerMovementController.InitializeInputData(aiMovementInputData);
            towerRotationController.InitializeInputData(aiRotationInputData);

            
            UpdateTarget();
        }

        private void OnTargetdeath(Unit obj)
        {
            targetsList.RemoveAt(0);
            _targetDispose.Dispose();

            if (targetsList.Count > 0)
            {
                UpdateTarget();
            }
            else
            {
                _targetTransform = null;
                _hasTarget = false;
            }
        }
        
        private void UpdateTarget()
        {
            if (targetsList.Count == 0 ) { return; }

            _hasTarget = true;
            
            _targetTransform = targetsList[0].transform;
            aiMovementInputData.SetTarget(transform, _targetTransform);
            aiRotationInputData.SetTarget(towerRotationController.Tower, _targetTransform);
            
            _targetDispose = new CompositeDisposable();
            targetsList[0].OnDeath.Subscribe(OnTargetdeath).AddTo(_targetDispose);
        }
        
        
        private void Update()
        {
            // ADD BOOL CHECK FOR PERFORMANCE
            if(!_hasTarget) { return; }
            
            aiMovementInputData.ProcessInput();
            aiRotationInputData.ProcessInput();

            if (Mathf.Abs(aiRotationInputData.Horizontal) < .25f && Vector3.Distance(_targetTransform.position, transform.position ) < 7)
            {
                playerInventoryController.ReactiveShootCommand.Execute();
            }
            
        }
    }
}