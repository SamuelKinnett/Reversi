using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Reversi
{
    class LineDrawer
    {
        Texture2D lineTexture;

        public LineDrawer(GraphicsDevice graphicsDevice, Color colour)
        {
            lineTexture = new Texture2D(graphicsDevice, 1, 1);
            lineTexture.SetData<Color>(new Color[] {Color.White});
        }

        /// <summary>
        /// This method draws a line with a specified thickness given 
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="lineThickness"></param>
        public void DrawLine(SpriteBatch spriteBatch, Vector2 start, Vector2 end, int lineThickness, Color colour)
        {
            //credit to Ken from StackExchange for the following code
            Vector2 edge = end - start;
            float angle = (float)Math.Atan2(edge.Y, edge.X);

            spriteBatch.Begin();
            spriteBatch.Draw(lineTexture, new Rectangle((int)start.X, (int)start.Y, (int)edge.Length(), lineThickness), null, colour, angle, new Vector2(0, 0), SpriteEffects.None, 0);
            spriteBatch.End();
        }
    }
}
