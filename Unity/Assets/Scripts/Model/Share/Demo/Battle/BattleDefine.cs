namespace ET
{
    public static class BattleDefine
    {
    
    }
    
    /// <summary>
    /// 输入操作类型
    /// </summary>
    public enum EInputType : byte
    {
        Key,
        KeyDown,
        KeyUp,
    }
    
    public enum EOperateType : byte
    {
        Move = 0,
        Jump = 1,
        Attack = 2,//普攻
        Skill1,
        Skill2,
        Skill3,
        Skill4,
    }

}
