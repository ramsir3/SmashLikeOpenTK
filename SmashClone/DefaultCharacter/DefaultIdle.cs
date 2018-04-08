using System;
namespace SmashClone
{
    public class DefaultIdle:CharacterAnimation
    {
        public DefaultIdle()
        {
            this._state = Character.CharacterState.Idle;
        }

        public override void Draw() {
            
        }
    }
}
