using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
	[ComponentOf(typeof(Scene))]
	public class OperaComponent: Entity, IAwake, IUpdate, ILateUpdate
    {
        public Vector3 ClickPoint;

	    public int mapMask;
	    
	    //操作信息
	    public List<OperateInfo> OperateInfos = new List<OperateInfo>();
	    public List<OperateInfo> OperateInfosTemp = new List<OperateInfo>();
    }
}
