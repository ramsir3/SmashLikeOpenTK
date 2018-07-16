using System;
using OpenTK;
using SmashClone;
using SmashClone.Common;
using static SmashClone.Common.Constants;
namespace SmashClone.Characters.DefaultCharacter
{
    public class Walk : CLoopedAnimation
    {
        protected override void Init()
        {
            _frame = 0;
            _end = 9;
            _state = AnimationStates.Walk;
            _main=5;
            _start=3;
            _hurtBoxes = new Box[][]{
                new Box[]{
                    new Box(new Vector2(0f,0f),0.1f),
                },
                new Box[]{
                    new Box(new Vector2(0f,0f),0.1f),
                },
                new Box[]{
                    new Box(new Vector2(0f,0.0125f),0.125f),
                },
                new Box[]{
                    new Box(new Vector2(0f,0.0125f),0.125f),
                },
                new Box[]{
                    new Box(new Vector2(0f,0.025f),0.15f),
                },
                new Box[]{
                    new Box(new Vector2(0f,0.025f),0.15f),
                },
                new Box[]{
                    new Box(new Vector2(0f,0.125f),0.125f),
                },
                new Box[]{
                    new Box(new Vector2(0f,0.125f),0.125f),
                },
                new Box[]{
                    new Box(new Vector2(0f,0f),0.1f),
                },
                new Box[]{
                    new Box(new Vector2(0f,0f),0.1f),
                },
            };        
        }
    }
}