using Harmony12;
using Rewired;

namespace USDCModMenu
{
    [HarmonyPatch(typeof(AnimationTrigger), "Update")]
	class Patch1
	{
		static bool Postfix(AnimationTrigger __instance)
		{
			if (__instance.R1Trick)
			{
				Mod.mod.anim.speed = Mod.mod.AnimationSpeeds[0];
			}
			if (__instance.R1Trick)
			{
				Mod.mod.anim.speed = Mod.mod.AnimationSpeeds[1];
			}
			if (__instance.L1R1Trick)
			{
				Mod.mod.anim.speed = Mod.mod.AnimationSpeeds[2];
            }
			if (__instance.L1R1Trick)
			{
				Mod.mod.anim.speed = Mod.mod.AnimationSpeeds[3];
			}
			if (__instance.R2Trick)
			{
				Mod.mod.anim.speed = Mod.mod.AnimationSpeeds[4];
			}
			if (__instance.R2L2Trick)
			{
				Mod.mod.anim.speed = Mod.mod.AnimationSpeeds[5];
			}
			if (__instance.L1R1Trick)
			{
				Mod.mod.anim.speed = Mod.mod.AnimationSpeeds[6];
			}
			if (__instance.L1R1Trick)
			{
				Mod.mod.anim.speed = Mod.mod.AnimationSpeeds[7];
			}
			if (__instance.R2Trick)
			{
				Mod.mod.anim.speed = Mod.mod.AnimationSpeeds[8];
			}
			if (__instance.R2L2Trick)
			{
				Mod.mod.anim.speed = Mod.mod.AnimationSpeeds[9];
			}
			return true;
		}
	}
}