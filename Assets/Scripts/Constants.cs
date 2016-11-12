using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    class Constants
    {
        public static int NB_MAX_PLAYERS = 4;
    }

	public enum Direction
	{
		TOP,
		LEFT,
		DOWN,
		RIGHT
	}

	public enum GameState
	{
		PAUSE, PLAY, WARMUP
	}
}
