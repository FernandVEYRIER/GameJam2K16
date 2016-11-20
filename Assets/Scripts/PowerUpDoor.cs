using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class PowerUpDoor : APowerUp {

    override public bool Use(Direction dir = Direction.RIGHT, int sender = -1, int target = -1)
    {
        if (base.Use(dir, sender, target))
        {
            ((GameManager)GameManager.GM).CloseDoor(sender);
            return true;
        }
        return false;
    }
}
