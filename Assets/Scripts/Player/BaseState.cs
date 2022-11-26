using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleFoxLite
{
    public abstract class BaseState
    {
        public abstract void EnterState(PlayerController player);
        public abstract void UpdateState(PlayerController player);
        public abstract void ExitState(PlayerController player);
    }
    public class EventState : BaseState
    {
        public override void EnterState(PlayerController player)
        {
        }
        public override void UpdateState(PlayerController player)
        {

        }
        public override void ExitState(PlayerController player)
        {
        }
    }
    public class NormalState : BaseState
    {
        public override void EnterState(PlayerController player)
        {
            player.jumpAction += player.HandleJump;

        }
        public override void UpdateState(PlayerController player)
        {
            player.HandleMovement();
        }
        public override void ExitState(PlayerController player)
        {
            player.jumpAction -= player.HandleJump;
        }
    }
    public class ShootState : BaseState
    {
        public override void EnterState(PlayerController player)
        {
            player.ChangeAnimatorState(true);
            player.ShowGun();
            player.jumpAction += player.HandleJumpInShoot;
        }
        public override void UpdateState(PlayerController player)
        {
            player.HandleMovementShoot();
        }
        public override void ExitState(PlayerController player)
        {
            player.StartCoroutine(player.HideGun());
            player.jumpAction -= player.HandleJumpInShoot;
            player.ChangeAnimatorState(false);

        }
    }
}
