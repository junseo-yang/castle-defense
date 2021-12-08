using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System.IO;

namespace CastleDefense
{
    public class ActionScene : GameScene
    {
        private SoundEffect arrowSound;

        bool paused = false;

        public static int Level { get; set; } = 1;
        public static int Score = 0;
        public int OldScore { get; set; } = -1;

        public int BombCount { get; set; } = 0;

        public ActionScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            spriteBatch = g._spriteBatch;

            // arrowSound = g.Content.Load<SoundEffect>("sounds/shoot");

            EntityManager.Add(Background.Instance);
            EntityManager.Add(Castle.Instance);
            EntityManager.Add(Archer.Instance);
        }

        public override void Update(GameTime gameTime)
        {
            if (!ArcherStatus.IsGameOver)
            {
                if (Input.WasKeyPressed(Keys.P))
                    paused = !paused;
                if (Input.WasKeyPressed(Keys.B) && BombCount != 0)
                {
                    EntityManager.Add(new Bomb(new Vector2(800, 950)));
                    EntityManager.Add(new Bomb(new Vector2(1000, 950)));
                    EntityManager.Add(new Bomb(new Vector2(1200, 950)));
                    EntityManager.Add(new Bomb(new Vector2(1400, 950)));
                    EntityManager.EmptyEnemies();
                    BombCount--;
                }

                if (!paused)
                {
                    // PlayerStatus.Update();
                    EntityManager.Update();
                    EnemySpawner.Update();
                }

                if (Score % 2 == 0 && Score != 0 && !paused && OldScore != Score)
                {
                    if (!Archer.IsDead)
                    {
                        paused = true;
                        EntityManager.EmptyEnemies();
                        EntityManager.EmptyArrows();
                        System.Windows.Forms.MessageBox.Show("Congratulations! You passed Level " + Level, "Castle Defense");
                        Level++;
                        BombCount = (int)(Level * 0.2);
                        OldScore = Score;
                        paused = false;
                    }
                }

                try
                {
                    UpdateScore();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Error: \n" + ex.Message);
                }

                base.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            EntityManager.Draw(spriteBatch);
            spriteBatch.End();

            spriteBatch.Begin();
            DrawTitleSafeAlignedString("Level: " + Level, Vector2.Zero);
            DrawTitleSafeAlignedString("Scores: " + Score, new Vector2(0, 16));
            DrawTitleSafeAlignedString("Bomb: " + BombCount, new Vector2(0, 32));

            if (ArcherStatus.IsGameOver)
            {
                string text = "Game Over\n" + "Your Level: " + Level + "\n" +
                "Your Score: " + Score + "\n" + "Press ESC to Quit";

                Vector2 textSize = Art.RegularFont.MeasureString(text);
                spriteBatch.DrawString(Art.RegularFont, text, Shared.stage / 2 - textSize / 2, Color.White);
            }
            spriteBatch.End();
            

            base.Draw(gameTime);
        }

        private void UpdateScore()
        {
            string[] records;
            string updatedRecord = "";
            using (StreamReader reader = new StreamReader(Game1.FileName))
            {
                records = reader.ReadToEnd().Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            }

            using (StreamWriter writer = new StreamWriter(Game1.FileName, append: false))
            {
                foreach (var item in records)
                {
                    if (item.StartsWith(Game1.PlayerName))
                    {
                        updatedRecord += Game1.PlayerName + "\t" + Level + "\t" + Score;
                    }
                    else
                    {
                        updatedRecord += item + "\n";
                    }
                }

                writer.WriteLine(updatedRecord);
            }
        }

        private void DrawTitleSafeAlignedString(string text, Vector2 pos)
        {
            spriteBatch.DrawString(Art.RegularFont, text, pos, Color.White);
        }

        public void RestartGame()
        {
            Score = 0;
            Level = 1;
            BombCount = 0;
            ArcherStatus.IsGameOver = false;
            Archer.IsDead = false;
            EntityManager.EmptyEnemies();
            EntityManager.EmptyBombs();
            Castle.Instance.CastleReset();
            Background.Instance.BackgroundReset();
        }
    }
}
