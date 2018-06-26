import sys,os
import json

fn = sys.argv[1]
types = {
    "loop":"CLoopedAnimation",
    "anim":"CAnimation"
}
hitbox = "new HitBox"
vector = "new Vector2"
header= "using System;using OpenTK;using SmashClone;using static SmashClone.Constants;"
state=os.path.basename(fn)
namespace=os.path.basename(fn[:-(len(state)+6)])
projectname=os.path.basename(fn[:-(len(state)+len(namespace)+18)])
state=state.split(".")[0]
# print(fn)
# print(state)
# print(namespace)
# print(projectname)
def csify(_type,_frame,_end,_start=0,_main=0,_hitBoxes=0):
    out = header+"namespace "+namespace+"{ public class "+state+":" \
        +types[_type]+"{"+"public "+state+"(){_frame="+str(_frame)+";" \
        +"_end="+str(_end)+";" \
        +"_state=CharacterState."+state+";"
    if _type == "loop":
        out += "_main="+str(_main)+";" \
            +"_start="+str(_start)+";"
    out += "_hitBoxes="+hitbox+"[][]{"
    for f in _hitBoxes:
        out+=hitbox+"[]{"
        for hb in f:
            out+=hitbox+"("+vector+"("+str(hb[0])+"f,"+str(hb[1])+"f),"+str(hb[2])+"f),"
        out+="},"
    out+="};}"
    out+="}"
    out+="}"
    return out

with open(fn,'r') as anim:
    animjson=json.loads(anim.read())
    # print(animjson)
    animcs=csify(**animjson)
    # print(animcs)
    with open(os.path.join(projectname,"Characters",namespace,state)+".cs",'w') as out:
        out.write(animcs)


