using System.Collections.Generic;

namespace ET.Client
{
    public struct SceneChangeStart
    {
    }
    
    public struct SceneChangeFinish
    {
    }
    
    public struct AfterCreateClientScene
    {
    }
    
    public struct AfterCreateCurrentScene
    {
    }

    public struct AppStartInitFinish
    {
    }

    public struct LoginFinish
    {
    }

    public struct EnterMapFinish
    {
    }

    public struct AfterUnitCreate
    {
        public Unit Unit;
    }
    
    public struct AfterMyUnitCreate
    {
        public Unit Unit;
    }

    public struct LoginAndGetServerInfoFinish
    {
        
    }

    public struct EnterServerNotHaveRoles
    {
        
    }
    
    public struct EnterServerHaveRoles
    {
        public List<RoleInfoProto> RoleInfos;
    }

    public struct OnClickNextRole
    {
        
    }
    
    public struct OnClickPreRole
    {
        
    }
}