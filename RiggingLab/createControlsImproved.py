import maya.cmds as cmds

def create_Controls():
    selList = cmds.ls(selection=True)
    controlDict = {}
    for sel in selList:
        selRot = cmds.xform(sel, worldSpace=True, rotation=True, q=True)
        selTrans = cmds.xform(sel, worldSpace=True, translation=True, q=True)

        if "_Jnt" in sel or "_Geo" in sel:
            txt = sel
            txt2 = (txt.rpartition('_')[0])
            txt2 = '%s_Ctrl' % txt2
            currentControl = cmds.circle(c=[0,0,0], nr=[1,0,0], sw=360, r=1, d=3, ut=0, tol=0.01, s=8, ch=1, name=txt2)[0]
        else:
            currentControl = cmds.circle(c=[0,0,0], nr=[1,0,0], sw=360, r=1, d=3, ut=0, tol=0.01, s=8, ch=1, name=f"{sel}_Ctrl")[0]
        
        currentGroup = cmds.group(currentControl, world=True, name=f"{currentControl}_Grp")
        cmds.xform(currentGroup, rotation=selRot, translation=selTrans)

        if "_Jnt" in sel:
            cmds.parentConstraint(currentControl, sel, mo=True)
            cmds.scaleConstraint(currentControl, sel, mo=True)

        controlDict[sel] = (currentControl, currentGroup)

    # Now, parent the control groups to mimic the hierarchy of the joints
    for sel in selList:
        # Get the parent of the current selected joint
        parent = cmds.listRelatives(sel, parent=True)
        if parent:
            parentControl, parentGroup = controlDict[parent[0]]
            currentControl, currentGroup = controlDict[sel]
            # Parent the control group to the parent control, not the parent control group
            cmds.parent(currentGroup, parentControl)
create_Controls()