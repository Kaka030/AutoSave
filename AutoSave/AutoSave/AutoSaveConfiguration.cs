using Rocket.API;
using System.Runtime.Serialization.Formatters;

namespace kaka.AutoSave
{
    public class AutoSaveConfiguration : IRocketPluginConfiguration
    {
        public bool Enabled;
        public int SaveInterval;
        public string SaveMsg;
        public string MessageColor;
        public void LoadDefaults()
        {
            Enabled = true;
            SaveInterval = 60;
            SaveMsg = "服务器保存中...";
            MessageColor = "blue";
        }
    }
}
