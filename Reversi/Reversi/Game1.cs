using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using BloomPostprocess;

namespace Reversi
{

    #region Enums

    enum GameState
    {
        SplashScreen,
        MainMenu,
        Playing
    }

    enum PlayerColour
    {
        Red,
        Blue
    }

    #endregion

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        Rendering rendering;
        SpriteBatch spriteBatch;

        #region Fonts

        public SpriteFont titleFont;
        public SpriteFont normalFont;

        #endregion

        #region Graphics

        public Texture2D logoSKS;

        #endregion

        #region Sound

        public SoundEffect menuTheme;
        SoundEffectInstance menuMusic;

        #endregion

        #region Effects

        BloomComponent bloom;

        #endregion

        #region Global Variables

        GameState gameState;
        
        #endregion

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 600;
            graphics.PreferredBackBufferHeight = 600;

            bloom = new BloomComponent(this);
            Components.Add(bloom);
            bloom.Settings = new BloomSettings(null, 0, 4, 1, 1, 1.5f, 1);

            gameState = new GameState();
            gameState = GameState.SplashScreen;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            rendering = new Rendering(GraphicsDevice);

            #region Fonts

            titleFont = Content.Load<SpriteFont>(@"Fonts\TitleFont");
            normalFont = Content.Load<SpriteFont>(@"Fonts\GeneralText");

            #endregion

            #region Graphics

            logoSKS = Content.Load<Texture2D>(@"Graphics\SKS");

            #endregion

            #region Sound

            menuTheme = Content.Load<SoundEffect>(@"Sound\ReversiProgress2");
            menuMusic = menuTheme.CreateInstance();

            #endregion

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            switch (gameState)
            {
                case GameState.SplashScreen:
                    if (menuMusic.State == SoundState.Stopped)
                    {
                        menuMusic.IsLooped = true;
                        menuMusic.Play();
                    }
                    break;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            bloom.BeginDraw();

            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            switch (gameState)
            {
                case GameState.SplashScreen:
                    rendering.RenderSplashScreen(titleFont, normalFont, logoSKS);
                    break;
            }

            base.Draw(gameTime);
        }
    }
}
