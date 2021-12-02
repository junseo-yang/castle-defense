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

        Castle castle;
        Archer archer;
        EnemyManager enemyManager;
        public ArrowManager arrowManager;

        MouseState oldMouseState;

        Game1 g;

        public GameManager(Game game) : base(game)
        {
            g = (Game1)game;

            ManagerComponents = new List<GameComponent>();

            level = 1;

            castle = new Castle(game);
            this.ManagerComponents.Add(castle);

            archer = new Archer(game);
            this.ManagerComponents.Add(archer);

            enemyManager = new EnemyManager(game);
            foreach (var item in enemyManager.Enemies)
            {
                ManagerComponents.Add(item);
            }

            arrowManager = new ArrowManager(game, archer);
            this.ManagerComponents.Add(arrowManager);
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

            // Draw Arrow
            //if (arrowManager.Arrows.Count != 0)
            //{
            //    foreach (var item in arrowManager.Arrows)
            //    {
            //        ManagerComponents.Add(item);
            //    }
            //}


            // Enemy dissapear Test
            //MouseState ms = Mouse.GetState();

            //if (ms.LeftButton == ButtonState.Pressed)
            //{
            //    foreach (JSDrawableGameComponent item in enemyManager.Enemies)
            //    {
            //        item.Hide();
            //    }

            //}
            //if (ms.RightButton == ButtonState.Pressed)
            //{
            //    foreach (JSDrawableGameComponent item in enemyManager.Enemies)
            //    {
            //        item.Show();
            //    }
            //}



            base.Update(gameTime);
        }
    }
}
