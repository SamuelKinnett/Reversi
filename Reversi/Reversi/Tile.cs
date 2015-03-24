using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Reversi
{
    /// <summary>
    /// The tile class describes a single tile on the reversi board.
    /// </summary>
    class Tile
    {
        Player owner;

        public Tile()
        {
            owner = null;
        }

        public void DrawTile(SpriteBatch spriteBatch, int x, int y)
        {
            if (owner != null)
            {

            }
        }

    }
}
