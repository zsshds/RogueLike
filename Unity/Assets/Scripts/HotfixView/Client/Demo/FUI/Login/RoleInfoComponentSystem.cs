using System.Collections.Generic;
using ET.Client.Login;

namespace ET.Client
{
    [EntitySystemOf(typeof(FUI_RoleInfoComponent))]
    public static partial class RoleInfoComponentSystem
    {
        public static void Init(this FUI_RoleInfoComponent self, HeroConfig heroConfig)
        {
            self.Txt_RoleName.text = heroConfig.Name;
            self.Txt_RoleDIcx.text = heroConfig.Desc;
            List<string> keys = new List<string>(heroConfig.AttributeDict.Keys);
            self.RoleAttributeList.itemRenderer = (index, obj) =>
            { 
                FUI_RoleAttributeComponent roleAttributeComponent = obj as FUI_RoleAttributeComponent;
                int key = int.Parse(keys[index]);
                roleAttributeComponent.Txt_AttributeName.text = HeroAttributeCategory.Instance.Get(key).AttributeName;
                roleAttributeComponent.Txt_AttributeValue.text = (heroConfig.AttributeDict[key.ToString()] / 10000).ToString();
            };
            self.RoleAttributeList.numItems = heroConfig.AttributeDict.Count;
        }
    }

}
