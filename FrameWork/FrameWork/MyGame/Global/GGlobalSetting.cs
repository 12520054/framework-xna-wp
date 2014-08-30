using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameWork.Global
{

    public enum eGStateGame
    {
        INTRO,
    }
    public enum eGMyObject
    {
        RED_SQUARE,
    }
    public enum eGStatus
    {
        ALIVE, 
    }
    public enum eGDirectCollision
    {
        TOP, BOT, LEFT, RIGHT, NONE
    }
    public enum eGSprite
    {
        RED_SQUARE
    }
    public enum eGFont
    {
        ARIAL_FONT
    }
    public class GGlobalSetting
    {
        static public int ScreenWidth = 480;
        static public int ScreenHeight = 800;
        static public bool IsPause = false;
        static public bool IsExit = false;
        static public bool IsSound = true;

    }
}
