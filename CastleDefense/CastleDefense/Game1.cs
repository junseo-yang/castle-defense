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
        public const int START_GAME = 0;
        public const int LOAD_GAME = 1;
        public const int HELP_SCENE = 2;
        public const int HIGH_SCORE_SCENE = 3;
        public const int CREDIT_SCENE = 4;
        public const int QUIT = 5;

        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;

        /* Scene */
        private StartScene startScene;
        public ActionScene actionScene;
        private HelpScene helpScene;
        public HighScoreScene highScoreScene;
        public CreditScene creditScene;


        public static string PlayerName { get; set; }
        public static string FileName { get; set; } = "CastleDefenseSave.txt";

        int selectedIndex = 0;

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

            //do
            //{
            //    SetDirectory();
            //} while (string.IsNullOrEmpty(FileName));

            CreateSaveFile();

            do
            {
                SetPlayerName();
            } while (string.IsNullOrEmpty(PlayerName));


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content

            Art.Load(Content);
            Font.Load(Content);
            Sound.Load(Content);

            // Music Player
            try
            {
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Play(Sound.Music);
            }
            catch { }

            /* Scene */
            startScene = new StartScene(this);
            this.Components.Add(startScene);

            helpScene = new HelpScene(this);
            this.Components.Add(helpScene);

            actionScene = new ActionScene(this);
            this.Components.Add(actionScene);

            highScoreScene = new HighScoreScene(this);
            this.Components.Add(highScoreScene);

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

            KeyboardState ks = Keyboard.GetState();
            if (startScene.Enabled)
            {
                selectedIndex = startScene.Menu.SelectedIndex;
                if (selectedIndex == START_GAME && ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Enter))
                {
                    startScene.hide();
                    actionScene.RestartGame();
                    actionScene.show();
                }
                if (selectedIndex == LOAD_GAME && ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Enter))
                {
                    try
                    {
                        LoadGame();
                        startScene.hide();
                        actionScene.show();
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Error: " + ex.Message, "Castle Defense");
                    }

                }
                else if (selectedIndex == HELP_SCENE && ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Enter))
                {
                    startScene.hide();
                    helpScene.show();
                }
                else if (selectedIndex == HIGH_SCORE_SCENE && ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Enter))
                {
                    startScene.hide();
                    highScoreScene.show();
                }
                else if (selectedIndex == CREDIT_SCENE && ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Enter))
                {
                    startScene.hide();
                    helpScene.show();
                }
                else if (selectedIndex == QUIT && ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Enter))
                {
                    Exit();
                }
            }

            if (helpScene.Enabled || actionScene.Enabled || highScoreScene.Enabled)
            {
                if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
                {
                    actionScene.RestartGame();
                    hideAllScenes();
                    startScene.show();
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Bisque);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        public void CreateSaveFile()
        {
            try
            {
                //System.Windows.Forms.MessageBox.Show("Before we start this game, you need to specify a location to create a game data save file to save scores.", "Catle Defense");

                //using (var fbd = new FolderBrowserDialog())
                //{
                //    DialogResult result = fbd.ShowDialog();

                //    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                //    {
                //        FileName = fbd.SelectedPath + "\\CastleDefenseSave.txt";

                //        if (!File.Exists(FileName))
                //        {
                //            File.Create(FileName).Dispose();
                //            System.Windows.Forms.MessageBox.Show("CastleDefenseSave.txt is created under selected location.", "Castle Defense");
                //        }
                //        else
                //        {
                //            System.Windows.Forms.MessageBox.Show("CastleDefenseSave.txt is already created under selected location.", "Castle Defense");
                //        }
                //    }
                //}

                if (!File.Exists(FileName))
                {
                    File.Create(FileName).Dispose();
                    // System.Windows.Forms.MessageBox.Show("CastleDefenseSave.txt is created under selected location.", "Castle Defense");
                }
                //else
                //{
                //    System.Windows.Forms.MessageBox.Show("CastleDefenseSave.txt is already created under selected location.", "Castle Defense");
                //}
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: \n" + ex.Message);
            }
        }

        private void SetPlayerName()
        {
            InputBox inputBox = new InputBox("Player Name", "You need to enter a player name to play.");
            PlayerName = inputBox.GetName();

            string[] records;
            using (StreamReader reader = new StreamReader(Game1.FileName))
            {
                records = reader.ReadToEnd().Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var item in records)
            {
                if (item.StartsWith(PlayerName))
                {
                    PlayerName = null;
                    System.Windows.Forms.MessageBox.Show("The Player Name already exists.");
                    return;
                }
            }

            using (StreamWriter writer = new StreamWriter(FileName, append: true))
            {
                writer.WriteLine(Game1.PlayerName + "\t" + ActionScene.Level + "\t" + ActionScene.Score);
            }
        }

        private void LoadGame()
        {
            using (StreamReader reader = new StreamReader(FileName))
            {
                // InputBox inputBox = new InputBox("Player Name", "You need to enter a player name to play.");
                do
                {
                    string[] record = reader.ReadLine().Split("\t", StringSplitOptions.RemoveEmptyEntries);
                    if (record[0].StartsWith(PlayerName))
                    {
                        ActionScene.Level = int.Parse(record[1]);
                        ActionScene.Score = int.Parse(record[2]);
                        break;
                    }
                } while (reader.EndOfStream);
            }
        }
    }
}
