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

        public ActionScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            spriteBatch = g._spriteBatch;

            // arrowSound = g.Content.Load<SoundEffect>("sounds/shoot");

            EntityManager.Add(Castle.Instance);
            EntityManager.Add(Archer.Instance);
        }

        public override void Update(GameTime gameTime)
        {
            if (!ArcherStatus.IsGameOver)
            {
                if (Input.WasKeyPressed(Keys.P))
                    paused = !paused;
                //if (Input.WasKeyPressed(Keys.B))
                //    useBloom = !useBloom;

                if (!paused)
                {
                    // PlayerStatus.Update();
                    EntityManager.Update();
                    EnemySpawner.Update();
                }

                if (Score % 2 == 0 && Score != 0 && !paused)
                {
                    if (!Archer.IsDead)
                    {
                        paused = true;
                        EntityManager.EmptyEnemies();
                        System.Windows.Forms.MessageBox.Show("Congratulations! You passed Level " + Level, "Castle Defense");
                        Level++;
                        Score = 0;
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

            if (ArcherStatus.IsGameOver)
            {
                string text = "Game Over\n" +
                    "Your Score: " + Score + "\n";

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
                records = reader.ReadToEnd().Split("\n", StringSplitOptions.RemoveEmptyEntries);
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
    }
}
