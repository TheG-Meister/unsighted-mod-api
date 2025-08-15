using BepInEx;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Console = dev.gmeister.unsighted.modloader.code.console.Console;

namespace dev.gmeister.unsighted.modloader.code;

[BepInPlugin(GUID, NAME, VERSION)]
public class Plugin : BaseUnityPlugin
{

    public const string GUID = "dev.gmeister.unsighted.modloader";
    public const string NAME = "Unsighted Mod API";
    public const string VERSION = "0.0.1";

    public static Plugin instance;

    public Console console;

    public Plugin()
    {
        if (Plugin.instance != null) throw new ApplicationException("Cannot create another instance of Plugin as one already exists");

        new Harmony(GUID).PatchAll();

        this.console = new Console(Config);
        Plugin.instance = this;
    }

    public void OnGUI()
    {
        this.console.OnGUI();
    }

}
