using System;
namespace SmashClone
{
    public abstract class CharacterAnimation
    {
        protected Character.CharacterState _state;

        public Character.CharacterState State
        {
            get
            {
                return _state;
            }
        }

        public abstract void Draw();

    }
}
