using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameWork.Graphics
{
    class GSprite
    {
        private Texture2D m_Texture;
        private Vector2 m_Position;
        private int m_CurFrame;
        private int m_ColFrame;
        private int m_TotalFrame;

        

        private Point m_Size;
        private float m_Depth;
        private Vector2 m_Scale;
        private float m_Rotation;
        private SpriteEffects m_Effect;
        private Color m_color;

        public float Alpha = 1;
        #region Pro
        public int TotalFrame
        {
            get { return m_TotalFrame; }
            set { m_TotalFrame = value; }
        }
        public Texture2D Texture
        {
            get { return m_Texture; }
            set { m_Texture = value; }
        }

        public Vector2 Position
        {
            get { return m_Position; }
            set { m_Position = value; }
        }

        public int CurFrame
        {
            get { return m_CurFrame; }
            set { m_CurFrame = value; }
        }

        public int ColFrame
        {
            get { return m_ColFrame; }
            set { m_ColFrame = value; }
        }

        public Point Size
        {
            get { return m_Size; }
            set { m_Size = value; }
        }

        public float Depth
        {
            get { return m_Depth; }
            set { m_Depth = value; }
        }

        public Vector2 Scale
        {
            get { return m_Scale; }
            set { m_Scale = value; }
        }

        public float Rotation
        {
            get { return m_Rotation; }
            set { m_Rotation = value; }
        }

        public SpriteEffects Effect
        {
            get { return m_Effect; }
            set { m_Effect = value; }
        }

        public Color Color
        {
            get { return m_color; }
            set { m_color = value; }
        }
        #endregion

        public GSprite(GSprite _Sprite)
        {
            Texture = _Sprite.Texture;
            Size = _Sprite.Size;
            ColFrame = _Sprite.ColFrame;
            Color = _Sprite.Color;
            CurFrame = _Sprite.CurFrame;
            Depth = _Sprite.Depth;
            Scale = _Sprite.Scale;
            Rotation = _Sprite.Rotation;
            Effect = _Sprite.Effect;
        }

        /*
             *  Content --> LoadContent
             *  fileName --> file Link to photo
             *  Size --> Size a frame in sheet
             *  Col --> Num Collum
             *  Total --> Total frame
             *  Color --> Color.White
        */
        public GSprite(ContentManager Content, string filename, Point _Size, int _Col, int total, Color _Color)
        {
            Texture = Content.Load<Texture2D>(filename);
            Size = _Size;
            ColFrame = _Col;
            m_TotalFrame = total;
            Color = _Color;
            CurFrame = 0;
            Depth = 0.0f;
            Scale = new Vector2(1.0f, 1.0f);
            Rotation = 0.0f;
            Effect = SpriteEffects.None;
            //Position = new Vector2(0, 0); // setting in Object class
        }
        public void Render(SpriteBatch _SpiteBatch)
        {
            _SpiteBatch.Draw(Texture, new Vector2(Position.X + (Size.X) / 2, Position.Y + (Size.Y) / 2), new Rectangle((CurFrame % ColFrame) * Size.X, (CurFrame / ColFrame) * Size.Y, Size.X, Size.Y),
               Color*Alpha, Rotation, new Vector2((Size.X) / 2, (Size.Y) / 2), Scale, Effect, Depth);
        }
    }
}
