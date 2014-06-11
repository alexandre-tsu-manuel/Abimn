using Microsoft.Xna.Framework;

namespace Abimn
{
    public enum State { Reload, Run, Exit }

    public abstract class GameType
    {
        public bool IsFullScreen
        {
            get { return _isFullScreen; }
            set { _isFullScreen = value; }
        }
        private bool _isFullScreen;

        public State State
        {
            get { return _state; }
            set { _state = value; }
        }
        private State _state = State.Run;

        public GameType(bool isFullScreen)
        {
            this._isFullScreen = isFullScreen;
            this.Initialize();
        }

        public virtual void Initialize() { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw() { }
    }
}
