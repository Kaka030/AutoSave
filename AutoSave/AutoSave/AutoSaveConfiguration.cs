using Rocket.API;

namespace kaka.AutoSave
{
    public class AutoSaveConfiguration : IRocketPluginConfiguration
    {
        public bool Enabled { get; set; }
        public int SaveInterval { get; set; }
        public string SaveMsg { get; set; }
        public string MessageColor { get; set; }


        public void LoadDefaults()
        {
            MessageColor = "blue";
            Enabled = false;
            SaveInterval = 5;
            SaveMsg = "服务器保存中...";
        }
    }
}
