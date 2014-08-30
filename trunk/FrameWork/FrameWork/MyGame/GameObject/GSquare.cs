using FrameWork.Global;
using FrameWork.Graphics;
using FrameWork.MyObject;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameWork.GameObject
{
    class GSquare : GObject
    {
        public GSquare(eGMyObject eObj, eGStatus eStt, Vector2 Pos, GSprite sprite)
            : base(eObj, eStt, Pos, sprite)
        {
            this.VELOC = new Vector2(1, 1);
        }
        public override void Init()
        {
            base.Init();
        }
        public override void UpdateMove(GameTime gameTime, GInputState Input)
        {
            if (this.POSITION.X < 0 || this.POSITION.X > 450)
                this.m_Veloc.X *= -1;
            if (this.POSITION.Y < 0 || this.POSITION.Y > 750)
                this.m_Veloc.Y *= -1;
            base.UpdateMove(gameTime, Input);
        }
        public override void UpdateAnimation(GameTime gameTime)
        {
            this.SPRITE.Rotation += 0.1f;
            base.UpdateAnimation(gameTime);
        }
        public override void UpdateCollision(GObject Obj)
        {
            base.UpdateCollision(Obj);
        }
        public override void Render(Microsoft.Xna.Framework.Graphics.SpriteBatch sb)
        {
            base.Render(sb);
        }
    }
}
