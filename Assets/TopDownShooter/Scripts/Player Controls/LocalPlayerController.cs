using System;
using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Inventory;
using TopDownShooter.PlayerInput;
using UnityEngine;

namespace TopDownShooter
{
    public class LocalPlayerController : PlayerController
    {
        [SerializeField] private AbstractInputData shootInputData;

        private void Update()
        {
            if (shootInputData.Horizontal > 0)
            {
                playerInventoryController.ReactiveShootCommand.Execute();
            }
        }
    }

}
