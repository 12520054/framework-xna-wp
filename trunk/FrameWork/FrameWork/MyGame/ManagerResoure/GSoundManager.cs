using FrameWork.Global;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameWork.Manager
{
    public enum eGSounds
    { }
    public enum eGSongs
    { }

    class GSoundManager
    {
        public static bool IsRepeating = true;

        // All Songs at here ---> private static

        // End All Songs

        // All Sounds at here ---> private static

        // End All Sounds

        public static void LoadContent(ContentManager Content)
        {
            // Load all content Songs and Sounds
        }

        public static void PlaySounds(eGSounds e)
        {
            if (GGlobalSetting.IsSound == true)
            {
                switch (e)
                {

                    default:
                        break;
                }
            }
        }
        public static void PlaySongs(eGSongs e)
        {
            if (GGlobalSetting.IsSound == true)
            {
                switch (e)
                {

                    default:
                        break;
                }
            }
        }

    }
}
