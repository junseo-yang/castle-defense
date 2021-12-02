using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CastleDefense
{
    public class GameManager : JSDrawableGameComponent
    {
        private int level;

        public List<GameComponent> ManagerComponents { get; set; }

        EnemyManager enemyManager;

        public GameManager(Game game) : base(game)
        {
            ManagerComponents = new List<GameComponent>();

            level = 1;

            Castle castle = new Castle(game);
            this.ManagerComponents.Add(castle);

            Archer archer = new Archer(game);
            this.ManagerComponents.Add(archer);

            enemyManager = new EnemyManager(game);
            foreach (var item in enemyManager.Enemies)
            {
                ManagerComponents.Add(item);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            DrawableGameComponent comp = null;
            foreach (GameComponent item in ManagerComponents)
            {
                if (item is DrawableGameComponent)
                {
                    comp = (DrawableGameComponent)item;
                    if (comp.Visible)
                    {
                        comp.Draw(gameTime);
                    }
                }
            }

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (GameComponent item in ManagerComponents)
            {
                if (item.Enabled)
                {
                    item.Update(gameTime);
                }
            }

            // Test
            MouseState ms = Mouse.GetState();

            if (ms.LeftButton == ButtonState.Pressed)
            {
                foreach (JSDrawableGameComponent item in enemyManager.Enemies)
                {
                    item.Hide();
                }

            }
            if (ms.RightButton == ButtonState.Pressed)
            {
                foreach (JSDrawableGameComponent item in enemyManager.Enemies)
                {
                    item.Show();
                }
            }


            base.Update(gameTime);
        }
    }
}
