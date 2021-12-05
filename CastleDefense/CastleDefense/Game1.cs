using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;

namespace CastleDefense
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;

        /* Scene */
        //private StartScene startScene;
        //private HelpScene helpScene;
        //public ActionScene actionScene;
        public const int QUIT = 4;

        bool paused = false;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1300;
            _graphics.PreferredBackBufferHeight = 600;
            Content.RootDirectory = "Content";
            _graphics.GraphicsProfile = GraphicsProfile.HiDef;
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            Shared.stage = new Vector2(_graphics.PreferredBackBufferWidth,
                _graphics.PreferredBackBufferHeight);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content

            Art.Load(Content);
            Sound.Load(Content);

            EntityManager.Add(Castle.Instance);
            EntityManager.Add(Archer.Instance);

            // Music Player
            //try
            //{
            //    MediaPlayer.IsRepeating = true;
            //    MediaPlayer.Play(Sound.Music);
            //}
            //catch { }

            ///* Scene */
            //startScene = new StartScene(this);
            //this.Components.Add(startScene);

            //helpScene = new HelpScene(this);
            //this.Components.Add(helpScene);

            //actionScene = new ActionScene(this);
            //this.Components.Add(actionScene);

            //startScene.show();
        }

        //private void hideAllScenes()
        //{
        //    foreach (GameScene item in Components)
        //    {
        //        item.hide();
        //    }
        //}

        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();

            // TODO: Add your update logic here

            Input.Update();

            //MouseState ms = Mouse.GetState();

            //Debug.WriteLine($"x: {ms.X} y: {ms.Y}");

            //int selectedIndex = 0;
            //KeyboardState ks = Keyboard.GetState();
            //if (startScene.Enabled)
            //{
            //    selectedIndex = startScene.Menu.SelectedIndex;
            //    if (selectedIndex == 0 && ks.IsKeyDown(Keys.Enter))
            //    {
            //        startScene.hide();
            //        actionScene.show();
            //    }
            //    else if (selectedIndex == 1 && ks.IsKeyDown(Keys.Enter))
            //    {
            //        startScene.hide();
            //        helpScene.show();
            //    }
            //    else if (selectedIndex == QUIT && ks.IsKeyDown(Keys.Enter))
            //    {
            //        Exit();
            //    }
            //}

            //if (helpScene.Enabled || actionScene.Enabled)
            //{
            //    if (ks.IsKeyDown(Keys.Escape))
            //    {
            //        hideAllScenes();
            //        startScene.show();
            //    }
            //}

            //Input.Update();

            //// Allows the game to exit
            //if (Input.WasButtonPressed(Buttons.Back) || Input.WasKeyPressed(Keys.Escape))
            //    this.Exit();

            //if (Input.WasKeyPressed(Keys.P))
            //    paused = !paused;
            //if (Input.WasKeyPressed(Keys.B))
            //    useBloom = !useBloom;

            if (!paused)
            {
                // PlayerStatus.Update();
                EntityManager.Update();
                EnemySpawner.Update();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            EntityManager.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
