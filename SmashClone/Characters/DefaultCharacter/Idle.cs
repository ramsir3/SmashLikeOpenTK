using System;
using OpenTK;
using SmashClone;
using SmashClone.Common;
using static SmashClone.Common.Constants;
namespace SmashClone.Characters.DefaultCharacter
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