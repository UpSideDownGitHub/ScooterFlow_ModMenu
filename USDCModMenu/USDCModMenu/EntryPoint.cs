using System;
using System.Reflection;
using Harmony12;
using UnityEngine;
using UnityModManagerNet;

namespace USDCModMenu
{
    // Token: 0x02000003 RID: 3
    internal static class Main
	{
		// Token: 0x06000006 RID: 6 RVA: 0x000027F8 File Offset: 0x000009F8
		private static bool Load(UnityModManager.ModEntry modEntry)
		{
			Main.modId = modEntry.Info.Id;
			HarmonyInstance.Create(modEntry.Info.Id).PatchAll(Assembly.GetExecutingAssembly());
			GameObject gameObject = new GameObject();
			gameObject.name = "Main Script - UpSideDownCord#1346";
			gameObject.AddComponent<Mod>();

			UnityEngine.Object.DontDestroyOnLoad(gameObject);

			return true;
		}

		// Token: 0x0400000E RID: 14
		public static string modId;
	}
}