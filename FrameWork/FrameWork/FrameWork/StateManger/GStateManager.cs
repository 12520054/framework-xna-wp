using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameWork.StateManger
{
    class GStateManager
    {
        private List<GState> m_ListState = new List<GState>();
        public List<GState> getListState()
        {
            return m_ListState;
        }

        private ContentManager m_Content;

        public ContentManager Content
        {
          get { return m_Content; }
          set { m_Content = value; }
        }

        protected GStateManager() { }

        private static GStateManager m_Instance;
        public static GStateManager getInstance()
        {
            if (m_Instance == null)
                m_Instance = new GStateManager();
            return m_Instance;
        }

        public void Init()
        {
            if (getListState().Count != 0)
            {
                getListState()[getListState().Count - 1].InitStateGame(Content);
            }
        }
        public void Update(GameTime gameTime)
        {
            if (getListState().Count != 0)
            {
                getListState()[getListState().Count - 1].UpdateState(gameTime);
            }
        }
        public void HandleInput(GameTime gameTime, GInputState Input)
        {
            if (getListState().Count != 0)
            {
                getListState()[getListState().Count - 1].HandleInput(gameTime, Input);
            }
        }
        public void Render(SpriteBatch spriteBatch)
        {
            if (getListState().Count != 0)
            {
                getListState()[getListState().Count - 1].Render(spriteBatch);
            }
        }
        public void AddState(GState State)
        {
            //if (getListState().Count != 0)
            //{
            //    getListState()[getListState().Count - 1].ReLease();
            //}
            getListState().Add(State);
            getListState()[getListState().Count - 1].InitStateGame(Content);
        }
        public void ExitState()
        {
            getListState()[getListState().Count - 1].UnLoadStateGame();
            getListState().RemoveAt(getListState().Count - 1);
        }
        public void ClearAllState()
        {
            while (getListState().Count != 0)
                ExitState();
        }
    }
}
