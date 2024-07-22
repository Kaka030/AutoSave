using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using SDG.Unturned;
using System;
using System.Security.Policy;

namespace kaka.AutoSave
{
    public class AutoSave : RocketPlugin<AutoSaveConfiguration>
    {
        public static AutoSave Instance;
        public DateTime start = DateTime.Now;
        public bool msgYorN;
        public void AutoSaveEvent()
        {
            if (!Configuration.Instance.Enabled)
            {
                return;
            }
            if (start != null && (DateTime.Now - start).TotalSeconds > Configuration.Instance.SaveInterval)
            {
                if (!msgYorN)
                {
                    UnturnedChat.Say(Configuration.Instance.SaveMsg, UnturnedChat.GetColorFromName(Configuration.Instance.MessageColor, UnityEngine.Color.blue));
                    msgYorN = true;
                }
                SaveManager.save();
                msgYorN = false;
                start = DateTime.Now;
                Logger.Log("服务器保存时间 " + DateTime.Now);
            }
        }

        protected override void Load()
        {
            Instance = this;

            Logger.LogWarning("KakaPlugin--AutoSave");
            Logger.Log($"{Name} {Assembly.GetName().Version.ToString(3)} 已加载!");
        }

        protected override void Unload()
        {
            Logger.Log($"{Name} 已卸载!");
        }
    }
}