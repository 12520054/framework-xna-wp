using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using Microsoft.Phone.Shell;
using System.Windows;
using FrameWork.Global;
using FrameWork.Manager;
using FrameWork.ManagerResoure;
using FrameWork.StateManger;
using FrameWork.StateGame;

namespace FrameWork
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GInputState Input;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Frame rate is 30 fps by default for Windows Phone.
            TargetElapsedTime = TimeSpan.FromTicks(333333 / 2);

            // Extend battery life under lock.
            InactiveSleepTime = TimeSpan.FromSeconds(1);
            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = GGlobalSetting.ScreenWidth;
            graphics.PreferredBackBufferHeight = GGlobalSetting.ScreenHeight;
            graphics.ApplyChanges();

            // setup auto sleep
            //PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
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

            Input = new GInputState();
            if (!MediaPlayer.GameHasControl)
            {
                MessageBoxResult res = MessageBox.Show("Media is currently playing, do you want to stop it?", "Stop Player!", MessageBoxButton.OKCancel);
                if (res == MessageBoxResult.OK)
                {
                    MediaPlayer.Pause();
                    GGlobalSetting.IsSound = true;
                }
                if (res == MessageBoxResult.Cancel)
                {
                    GGlobalSetting.IsSound = false;
                }
            }

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

            // TODO: use this.Content to load your game content here
            //GSoundManager.LoadContent(Content);
            GSpriteFactory.getInstance().Init(Content);
            GStateManager.getInstance().Content = Content;
            GStateManager.getInstance().AddState(new GIntroState(eGStateGame.INTRO));

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
            if (GGlobalSetting.IsExit == true)
                this.Exit();

            // TODO: Add your update logic here

            Input.Update();
            GStateManager.getInstance().Update(gameTime);
            GStateManager.getInstance().HandleInput(gameTime, Input);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            spriteBatch.Begin();
            GStateManager.getInstance().Render(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
