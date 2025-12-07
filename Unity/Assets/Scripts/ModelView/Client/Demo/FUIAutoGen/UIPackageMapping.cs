/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using System.Collections.Generic;
using FairyGUI.Dynamic;

namespace ET.Client
{
    [EnableClass]
    public sealed class UIPackageMapping : IUIPackageHelper
    {
        private readonly Dictionary<string, string> m_PackageIdToNameMap = new()
        {
            {"5razy0t5", "Common"},
            {"9q0q76hc", "Login"},
            {"ngzx0fqy", "Main"},
            // <last line>
        };

        public string GetPackageNameById(string id)
        {
            return m_PackageIdToNameMap.TryGetValue(id, out var packageName) ? packageName : null;
        }
    }
}
