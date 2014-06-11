using Microsoft.Xna.Framework.Input;

namespace Abimn
{
    /// <summary>
    /// Event Manager
    /// Write : Nobody
    /// </summary>
    public static class E
    {
        private static KeyboardState _currentK, _oldK;
        private static MouseState _currentM, _oldM;

        public static bool IsDown(Keys key) { return _currentK.IsKeyDown(key); }
        public static bool IsUp(Keys key) { return _currentK.IsKeyUp(key); }
        public static bool IsPushed(Keys key) { return _oldK.IsKeyUp(key) && _currentK.IsKeyDown(key); }
        public static bool IsReleased(Keys key) { return _oldK.IsKeyDown(key) && _currentK.IsKeyUp(key); }
        public static Keys[] GetPressedKeys() { return _currentK.GetPressedKeys(); }

        public static bool LeftIsDown() { return _currentM.LeftButton == ButtonState.Pressed; }
        public static bool LeftIsUp() { return _currentM.LeftButton == ButtonState.Released; }
        public static bool LeftIsPushed() { return _currentM.LeftButton == ButtonState.Pressed && _oldM.LeftButton == ButtonState.Released; }
        public static bool LeftIsReleased() { return _currentM.LeftButton == ButtonState.Released && _oldM.LeftButton == ButtonState.Pressed; }
        public static bool RightIsDown() { return _currentM.RightButton == ButtonState.Pressed; }
        public static bool RightIsUp() { return _currentM.RightButton == ButtonState.Released; }
        public static bool RightIsPushed() { return _currentM.RightButton == ButtonState.Pressed && _oldM.RightButton == ButtonState.Released; }
        public static bool RightIsReleased() { return _currentM.RightButton == ButtonState.Released && _oldM.RightButton == ButtonState.Pressed; }
        public static bool MiddleIsDown() { return _currentM.MiddleButton == ButtonState.Pressed; }
        public static bool MiddleIsUp() { return _currentM.MiddleButton == ButtonState.Released; }
        public static bool MiddleIsPushed() { return _currentM.MiddleButton == ButtonState.Pressed && _oldM.MiddleButton == ButtonState.Released; }
        public static bool MiddleIsReleased() { return _currentM.MiddleButton == ButtonState.Released && _oldM.MiddleButton == ButtonState.Pressed; }
        public static bool Button1IsDown() { return _currentM.XButton1 == ButtonState.Pressed; }
        public static bool Button1IsUp() { return _currentM.XButton1 == ButtonState.Released; }
        public static bool Button1IsPushed() { return _currentM.XButton1 == ButtonState.Pressed && _oldM.XButton1 == ButtonState.Released; }
        public static bool Button1IsReleased() { return _currentM.XButton1 == ButtonState.Released && _oldM.XButton1 == ButtonState.Pressed; }
        public static bool Button2IsDown() { return _currentM.XButton2 == ButtonState.Pressed; }
        public static bool Button2IsUp() { return _currentM.XButton2 == ButtonState.Released; }
        public static bool Button2IsPushed() { return _currentM.XButton2 == ButtonState.Pressed && _oldM.XButton2 == ButtonState.Released; }
        public static bool Button2IsReleased() { return _currentM.XButton2 == ButtonState.Released && _oldM.XButton2 == ButtonState.Pressed; }
        public static Pos GetMousePos() { return new Pos(_currentM.X, _currentM.Y); }
        public static int GetMousePosX() { return _currentM.X; }
        public static int GetMousePosY() { return _currentM.Y; }
        public static int getMouseWheel() { return _currentM.ScrollWheelValue - _oldM.ScrollWheelValue;}

        public static void Init()
        {
            _currentK = _oldK = Keyboard.GetState();
            _currentM = _oldM = Mouse.GetState();
        }

        public static void Update()
        {
            _oldK = _currentK;
            _currentK = Keyboard.GetState();
            _oldM = _currentM;
            _currentM = Mouse.GetState();
        }
    }
}
