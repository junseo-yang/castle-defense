using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CastleDefense
{
    public class HighScoreScene : GameScene
    {
        List<string[]> scores;

        public HighScoreScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            spriteBatch = g._spriteBatch;

            scores = new List<string[]>();
        }

        public override void Draw(GameTime gameTime)
        {
            Vector2 tempPos = new Vector2(Shared.stage.X / 2, 280f);

            spriteBatch.Begin();
            // spriteBatch.DrawString(titleFont, "Castle Defense", Shared.stage / 2, Color.Black, 0f, );
            DrawRightAlignedString(titleFont, "Castle Defense", 50f);
            DrawRightAlignedString(regularFont, "Top 5 High Score\nPress ESC to quit.", 150f);
            DrawRightAlignedString(scoreFont, String.Format("{0,-30} {1,-15} {2,-15}", "Player Name", "Level", "Score"), 250f);

            int i = 0;
            foreach (var score in scores)
            {
                DrawRightAlignedString(scoreFont, String.Format("{0,-30} {1,-15} {2,-15}", score[0], score[1], score[2]), tempPos.Y);
                tempPos.Y += hilightFont.LineSpacing;
                i++;
                if (i == 5)
                {
                    break;
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            LoadScores();

            base.Update(gameTime);
        }

        private void LoadScores()
        {
            using (StreamReader reader = new StreamReader(Game1.FileName))
            {
                // InputBox inputBox = new InputBox("Player Name", "You need to enter a player name to play.");
                List<string[]> records = new List<string[]>();
                while (!reader.EndOfStream)
                {
                    string[] record = reader.ReadLine().Split(new char[] { '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                    records.Add(record);
                }

                if (records.Count > 1)
                {
                    records.Sort((delegate (string[] x, string[] y)
                    {
                        return int.Parse(y[2]) - int.Parse(x[2]);
                    }));
                }

                scores = records;
            }
        }
    }
}
