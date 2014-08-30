using FrameWork.Global;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameWork.StateManger
{
    abstract class GState
    {
        protected eGStateGame m_ID;
        protected GestureType enabledGesture = GestureType.None;

        protected GestureType EnabledGesture
        {
            get { return enabledGesture; }
            set { 
                enabledGesture = value; 
                TouchPanel.EnabledGestures = enabledGesture;
            }
        }


        public GState(eGStateGame id)
        {
            this.m_ID = id;
        }

        virtual public void InitStateGame(ContentManager Content)
        { }
        virtual public void UnLoadStateGame()
        { }
        virtual public void UpdateState(GameTime gameTime)
        { }
        virtual public void HandleInput(GameTime gameTime, GInputState Input)
        { }
        virtual public void Pause() { }
        virtual public void ReSume() { }
        virtual public void Render(SpriteBatch spriteBatch)
        {
        }
        public void ExitState()
        {
            GStateManager.getInstance().ExitState();
        }
    }
}
