using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Reversi
{

    enum SplashScreenState
    {
        Logo,
        TitleFade,
        Normal
    }

    class Rendering
    {
        SpriteBatch spriteBatch;
        GraphicsDevice graphics;

        SplashScreenState splashScreenState = new SplashScreenState();

        int ticks;              //Used to nicely fade in the splash screen
        double decimalTicks;    //Used for finer fading (muh sine curve)
        bool fadeAscending;     //Used for fading


        public Rendering(GraphicsDevice graphicsDevice)
        {
            this.graphics = graphicsDevice;
            this.spriteBatch = new SpriteBatch(graphicsDevice);
            splashScreenState = SplashScreenState.Logo;
            ticks = 275;
        }

        public void RenderSplashScreen(SpriteFont titleFont, SpriteFont normalFont, Texture2D logo)
        {
            switch (splashScreenState)
            {
                case SplashScreenState.Logo:
                    if (ticks > 1)
                    {
                        spriteBatch.Begin();
                        spriteBatch.Draw(logo, new Rectangle(100, 100, 400, 400), Color.White * (0.0036f * (275 - ticks)));
                        spriteBatch.End();
                        --ticks;
                    }
                    else
                    {
                        ticks = 275;
                        splashScreenState = SplashScreenState.TitleFade;
                    }
                    break;

                case SplashScreenState.TitleFade:
                    if (ticks > 1)
                    {
                        spriteBatch.Begin();
                        spriteBatch.DrawString(titleFont, "Reversi", new Vector2(70, 25), Color.Cyan * (0.0036f * (275 - ticks)));
                        spriteBatch.End();
                        --ticks;
                    }
                    else
                    {
                        splashScreenState = SplashScreenState.Normal;
                        decimalTicks = 0;
                        fadeAscending = true;
                    }
                    break;

                case SplashScreenState.Normal:
                    spriteBatch.Begin();
                    spriteBatch.DrawString(titleFont, "Reversi", new Vector2(70, 25), Color.Cyan);
                    if (decimalTicks == 0 && fadeAscending == false)
                    {
                        fadeAscending = true;
                        decimalTicks += 0.05;
                    }
                    else if (decimalTicks == 3.14 && fadeAscending == true)
                    {
                        fadeAscending = false;
                        decimalTicks -= 0.05;
                    }
                    else
                    {
                        if (fadeAscending)
                            decimalTicks += 0.05;
                        else
                            decimalTicks -= 0.05;
                    }
                    spriteBatch.DrawString(normalFont, "Press Enter to Begin", new Vector2(150, 200), Color.Cyan * (float)Math.Sin(decimalTicks));

                    spriteBatch.End();
                    break;
            }
        }

    }
}
