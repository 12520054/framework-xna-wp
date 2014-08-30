using FrameWork.Global;
using FrameWork.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameWork.MyObject
{
    class GObject
    {
        protected eGMyObject m_ID;
        protected eGStatus m_Status;
        protected Vector2 m_Position;
        protected Vector2 m_Origin;
        protected Vector2 m_Veloc;
        protected Vector2 m_Accel;
        protected Point m_Size;
        protected int m_CurFrame;
        protected int m_StartFrame;
        protected int m_EndFrame;
        protected int m_TotalFrame;
        protected GSprite m_Sprite;
        protected GTimer Time;

        #region Pro
        public Vector2 Origin
        {
            get { return m_Origin; }
        }

        public eGMyObject ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }
        public Rectangle RECT
        {
            get { return new Rectangle((int)m_Position.X, (int)m_Position.Y, (int)m_Size.X, (int)m_Size.Y); }
        }
        public eGStatus STATUS
        {
            get { return m_Status; }
            set { m_Status = value; }
        }
        public Vector2 POSITION
        {
            get { return m_Position; }
            set { m_Position = value; }
        }
        public GTimer TIME
        {
            get { return Time; }
            set { Time = value; }
        }
        public Vector2 VELOC
        {
            get { return m_Veloc; }
            set { m_Veloc = value; }
        }
        public Vector2 ACCEL
        {
            get { return m_Accel; }
            set { m_Accel = value; }
        }
        public Point SIZE
        {
            get { return m_Size; }
            set { m_Size = value; }
        }

        public int CURRENTFRAME
        {
            get { return m_CurFrame; }
            set { m_CurFrame = value; }
        }

        public int TOTALFRAME
        {
            get { return m_TotalFrame; }
            set { m_TotalFrame = value; }
        }

        public GSprite SPRITE
        {
            get { return m_Sprite; }
            set { m_Sprite = value; }
        }
        #endregion

        public GObject(eGMyObject eObj, eGStatus estt, Vector2 position, GSprite sprite)
        {
            this.m_ID = eObj;
            this.STATUS = estt;
            this.POSITION = position;
            this.SPRITE = new GSprite(sprite);
            this.SIZE = new Point(SPRITE.Size.X, SPRITE.Size.Y);
            this.TOTALFRAME = sprite.TotalFrame;
            this.Time = new GTimer();
            m_Origin = new Vector2(this.POSITION.X + SIZE.X / 2, this.POSITION.Y + SIZE.Y / 2);
        }

        public GObject(GObject Obj)
        {
            m_ID = Obj.m_ID;
            m_Position = Obj.m_Position;
            m_Status = Obj.m_Status;
            m_Sprite = new GSprite(Obj.SPRITE);
            m_TotalFrame = Obj.m_TotalFrame;
            m_Origin = new Vector2(Obj.m_Origin.X, Obj.Origin.Y);
        }

        public eGDirectCollision DirectionCollision(GObject Obj)
        {
            if (RECT.Intersects(Obj.RECT))
            {
                float top = Math.Abs(RECT.Top - Obj.RECT.Bottom);
                float botom = Math.Abs(RECT.Bottom - Obj.RECT.Top);
                float left = Math.Abs(RECT.Left - Obj.RECT.Right);
                float right = Math.Abs(RECT.Right - Obj.RECT.Left);
                float rs = Math.Min(Math.Min(right, left), Math.Min(top, botom));

                if (rs == top)
                {
                    return eGDirectCollision.TOP;
                }
                if (rs == botom)
                {
                    return eGDirectCollision.BOT;
                }
                if (rs == left)
                {
                    return eGDirectCollision.LEFT;
                }
                if (rs == right)
                {
                    return eGDirectCollision.RIGHT;
                }
            }
            return eGDirectCollision.NONE;
        }
        virtual public void Init() { }
        virtual public void UpdateMove(GameTime gameTime, GInputState Input)
        {
            m_Position.X += VELOC.X * gameTime.ElapsedGameTime.Milliseconds / 10;
            m_Position.Y += VELOC.Y * gameTime.ElapsedGameTime.Milliseconds / 10;
        }

        virtual public void UpdateAnimation(GameTime gameTime) 
        {
            if (TIME.StopWatch(100, gameTime))
            {
                m_CurFrame++;
                if (m_CurFrame > m_EndFrame)
                {
                    m_CurFrame = m_StartFrame;
                }
            }
        }

        virtual public void UpdateCollision(GObject Obj)
        { 

        }
        virtual public void Render(SpriteBatch sb)
        {
            SPRITE.Position = POSITION;
            SPRITE.CurFrame = this.CURRENTFRAME;
            SPRITE.Render(sb);
        }
    }
}
