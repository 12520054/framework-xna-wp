using FrameWork.Global;
using FrameWork.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameWork.ManagerResoure
{
    class GSpriteFactory
    {
        private static GSpriteFactory m_Inst;
        public static GSpriteFactory getInstance()
        {
            if (m_Inst == null)
                m_Inst = new GSpriteFactory();
            return m_Inst;
        }
        private GSpriteFactory() { }

        // All Sprite in Game
        private GSprite SpriteSquare;

        // End All Sprite

        // All SpriteFont in Game
        private SpriteFont ArialFont;
        // End All SpriteFont

        // Ham nay dung tam thoi`. De opt game thi phai phan chia theo tung State
        public void Init(ContentManager Content)
        {
            // Init Sprite
            SpriteSquare = new GSprite(Content, @"Resource\\RedSquare", new Point(40, 40), 9, 9, Color.White);

            // Init SpriteFont
            ArialFont = Content.Load<SpriteFont>(@"Font\\ArialFont");
        }

        public GSprite getSprite(eGSprite e)
        {
            switch (e)
            {
                case eGSprite.RED_SQUARE:
                    return this.SpriteSquare;
                default:
                    return null;
            }
        }
        public SpriteFont getFont(eGFont e)
        {
            switch (e)
            {
                case eGFont.ARIAL_FONT:
                    return ArialFont;
                default:
                    return null;
            }
        }
    }
}
