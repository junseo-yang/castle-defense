using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace CastleDefense
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;

        /* Scene */
        private StartScene startScene;
        private HelpScene helpScene;
        public ActionScene actionScene;
        public const int QUIT = 4;

        public static string PlayerName { get; set; }
        public static string FileName { get; set; }

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

            do
            {
                SetDirectory();
            } while (string.IsNullOrEmpty(PlayerName) || string.IsNullOrEmpty(FileName));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content

            Art.Load(Content);
            Sound.Load(Content);

            //// Music Player
            //try
            //{
            //    MediaPlayer.IsRepeating = true;
            //    MediaPlayer.Play(Sound.Music);
            //}
            //catch { }

            /* Scene */
            startScene = new StartScene(this);
            this.Components.Add(startScene);

            helpScene = new HelpScene(this);
            this.Components.Add(helpScene);

            actionScene = new ActionScene(this);
            this.Components.Add(actionScene);

            startScene.show();
        }

        private void hideAllScenes()
        {
            foreach (GameScene item in Components)
            {
                item.hide();
            }
        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here

            Input.Update();

            //MouseState ms = Mouse.GetState();
            //if (EntityManager.enemies.Count > 0)
            //{
            //    Debug.WriteLine($"x: {EntityManager.enemies[0].Position.X} y: {EntityManager.enemies[0].Position.Y}");
            //}


            int selectedIndex = 0;
            KeyboardState ks = Keyboard.GetState();
            if (startScene.Enabled)
            {
                selectedIndex = startScene.Menu.SelectedIndex;
                if (selectedIndex == 0 && ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Enter))
                {
                    startScene.hide();
                    actionScene.show();
                }
                else if (selectedIndex == 1 && ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Enter))
                {
                    startScene.hide();
                    helpScene.show();
                }
                else if (selectedIndex == QUIT && ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Enter))
                {
                    Exit();
                }
            }

            if (helpScene.Enabled || actionScene.Enabled)
            {
                if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
                {
                    hideAllScenes();
                    startScene.show();
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        public void SetDirectory()
        {
            try
            {
                System.Windows.Forms.MessageBox.Show("Before we start this game, you need to specify a location to create a game data save file to save scores.", "Catle Defense");

                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        FileName = fbd.SelectedPath + "\\CastleDefenseSave.txt";

                        if (!File.Exists(FileName))
                        {
                            File.Create(FileName).Dispose();
                            System.Windows.Forms.MessageBox.Show("CastleDefenseSave.txt is created under selected location.", "Castle Defense");
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("CastleDefenseSave.txt is already created under selected location.", "Castle Defense");
                        }
                    }
                }

                if (String.IsNullOrEmpty(FileName))
                {
                    System.Windows.Forms.MessageBox.Show("Location path is empty", "Castle Defense");
                }
                else
                {
                    SetPlayerName();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: \n" + ex.Message);
            }
        }

        private void SetPlayerName()
        {
            using (StreamWriter writer = new StreamWriter(FileName, append: true))
            {
                InputBox inputBox = new InputBox("Player Name", "You need to enter a player name to play.");
                PlayerName = inputBox.GetName();

                writer.Write(PlayerName + "\t");
            }
        }
    }
}
