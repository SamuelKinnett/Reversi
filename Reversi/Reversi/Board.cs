using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Reversi
{
    class Board
    {
        Tile[,] gameBoard;
        LineDrawer lineDrawer;
        SpriteBatch spriteBatch;

        public Board(GraphicsDevice graphics, SpriteBatch spriteBatch)
        {
            gameBoard = new Tile[8, 8];
            lineDrawer = new LineDrawer(graphics, Color.Cyan);
            this.spriteBatch = spriteBatch;
        }

        /// <summary>
        /// This method draws the game board grid to the screen
        /// </summary>
        /// <param name="opacity"> A float between 0 and 1 to specify the opacity of the board, with 0 being transparent and 1 being opaque (Default 1) </param>
        public void DrawBoard(float opacity = 1)
        {
            for (float y = 50; y <= 550; y+= 62.5f)
            {
                lineDrawer.DrawLine(spriteBatch, new Vector2(50, y), new Vector2(550, y), 3, Color.Cyan * opacity);
            }
            for (float x = 50; x <= 550; x+= 62.5f)
            {
                lineDrawer.DrawLine(spriteBatch, new Vector2(x, 50), new Vector2(x, 553), 3, Color.Cyan * opacity);
            }
        }

    }
}
