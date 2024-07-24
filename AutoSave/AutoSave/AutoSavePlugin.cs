using Rocket.API.Collections;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using SDG.Unturned;
using System;
using System.Diagnostics.Eventing.Reader;
using UnityEngine;

namespace kaka.AutoSave
{
    public class AutoSave : RocketPlugin<AutoSaveConfiguration>
    {
        public static AutoSave Instance {  get; private set; }

        public DateTime ServerStart = DateTime.Now;

        public void SaveServer()
        {
            if (Configuration.Instance.Enabled && (DateTime.Now - ServerStart).TotalSeconds >= Configuration.Instance.SaveInterval)
            {
                UnturnedChat.Say(Configuration.Instance.SaveMsg,UnturnedChat.GetColorFromName(Configuration.Instance.MessageColor,Color.green));
                SaveManager.save();
                ServerStart = DateTime.Now;
                Rocket.Core.Logging.Logger.Log("服务器保存时间: " + DateTime.Now);
            }
            else
            {
                return;
            }
        }

        protected override void Load()
        {
            Instance = this;
            Rocket.Core.Logging.Logger.Log($"{Name} {Assembly.GetName().Version.ToString(3)} 已加载!");
            InvokeRepeating("SaveServer", Configuration.Instance.SaveInterval, Configuration.Instance.SaveInterval);
        }

        protected override void Unload()
        {
            Rocket.Core.Logging.Logger.Log($"{Name} 已卸载!");
        }
    }
}