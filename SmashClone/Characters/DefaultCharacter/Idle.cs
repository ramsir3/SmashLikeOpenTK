using System;
using OpenTK;
using OpenPlatformFighter;
using OpenPlatformFighter.Common;
using static OpenPlatformFighter.Common.Constants;
namespace OpenPlatformFighter.Characters.DefaultCharacter
{
    public class Idle : CAnimation
    {
        protected override void Init()
        {
            _frame = 0;
            _end = 0;
            _state = AnimationStates.Idle;
            _hurtBoxes = new Box[][]{
                new Box[]{
                    new Box(new Vector2(0f,0f),0.1f),
                },
            };        
        }
    }
}