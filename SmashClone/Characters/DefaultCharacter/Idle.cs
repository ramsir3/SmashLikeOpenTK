using System;using OpenTK;using SmashClone;using static SmashClone.Constants;namespace DefaultCharacter{ public class Idle:CAnimation{public Idle(){_frame=0;_end=0;_state=CharacterState.Idle;_hitBoxes=new HitBox[][]{new HitBox[]{new HitBox(new Vector2(0f,0f),0.1f),},};}}}