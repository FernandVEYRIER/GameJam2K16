using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    class PowerUpShield:APowerUp
    {
        override public bool Use(Direction dir, int sender = -1, int target = -1)
        {
            if (base.Use(dir, sender, target))
            {
                ((GameManager)GameManager.GM).GiveShield(dir, sender);
                return true;
            }
            return false;
        }
    }
}
