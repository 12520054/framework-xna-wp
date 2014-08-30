using FrameWork.GameObject;
using FrameWork.Global;
using FrameWork.Graphics;
using FrameWork.ManagerResoure;
using FrameWork.StateManger;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameWork.StateGame
{
    class GIntroState : GState
    {
        GSquare square;

        public GIntroState(eGStateGame id)
            : base(id)
        {
            this.EnabledGesture = GestureType.Tap;
        }
        public override void InitStateGame(Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            square = new GSquare(eGMyObject.RED_SQUARE, eGStatus.ALIVE, new Vector2(0, 0), new GSprite(GSpriteFactory.getInstance().getSprite(eGSprite.RED_SQUARE)));
            base.InitStateGame(Content);
        }
        public override void UnLoadStateGame()
        {
            base.UnLoadStateGame();
        }
        public override void UpdateState(Microsoft.Xna.Framework.GameTime gameTime)
        {
            square.UpdateAnimation(gameTime);
            
            base.UpdateState(gameTime);
        }
        public override void HandleInput(Microsoft.Xna.Framework.GameTime gameTime, GInputState Input)
        {
            square.UpdateMove(gameTime, Input);
            base.HandleInput(gameTime, Input);
        }
        public override void Render(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            square.Render(spriteBatch);
            base.Render(spriteBatch);
        }
    }
}
