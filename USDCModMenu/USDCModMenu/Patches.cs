using Harmony12;
using System;
using Rewired;
using UnityEngine;
using UnityEngine.UI;

namespace USDCModMenu
{
	[HarmonyPatch(typeof(AnimationTrigger))]
	[HarmonyPatch("Update")]
	class Patch1
	{
		static bool Prefix(ref float ___HSM,
                     ref float ___VSM,
                     ref float ___xRotateSmooth,
                     ref Player ___player,
                     ref Animator ___anim,
                     ref ColliderGC ___ground,
                     ref RagdollControl ___ragdollC,
                     ref Menu ___menuScript,
                     ref Pause ___pauseScript,
                     ref Rigidbody ___thisRB,
                     ref Vector3 ___localV,
                     ref bool ___L1Trick,
                     ref bool ___L2Trick,
                     ref bool ___R1Trick,
                     ref bool ___R2Trick,
                     ref bool ___R2L2Trick,
                     ref bool ___L1R1Trick,
                     ref bool ___fakie,
                     ref bool ___manual,
                     ref Text ___trickText,
                     ref ScooterController ___sCont,
                     ref GroundDistance ___groundInfo)
		{
			float axis = ___player.GetAxis("MoveHorizontal");
			___anim.SetFloat("horizontal", axis, ___HSM, Time.deltaTime);
			float axis2 = ___player.GetAxis("RightStickVertical");
			___anim.SetFloat("vertical", axis2, ___VSM, Time.deltaTime);
			float axis3 = ___player.GetAxis("LeftStickVertical");
			___anim.SetFloat("avertical", axis3, ___VSM, Time.deltaTime);
			float value = ___groundInfo.animationX * 1.3f;
			___anim.SetFloat("XRotation", value, ___xRotateSmooth, Time.deltaTime);
			float value2 = ___groundInfo.animationX * 2f;
			___anim.SetFloat("XRotationManual", value2, ___xRotateSmooth, Time.deltaTime);
			float value3 = ___groundInfo.animationZ * 1.3f;
			___anim.SetFloat("ZRotation", value3, ___xRotateSmooth, Time.deltaTime);
			if (___player.GetButton("R1") && !___ground.isGrounded)
			{
				___R1Trick = true;
			}
			else
			{
				___R1Trick = false;
			}
			if (___player.GetButton("L1") && !___ground.isGrounded)
			{
				___L1Trick = true;
			}
			else
			{
				___L1Trick = false;
			}
			if (___player.GetButton("R2") && !___ground.isGrounded)
			{
				___R2Trick = true;
			}
			else
			{
				___R2Trick = false;
			}
			if (___player.GetButton("L2") && !___ground.isGrounded)
			{
				___L2Trick = true;
			}
			else
			{
				___L2Trick = false;
			}
			if (___player.GetButton("R2") && ___player.GetButton("L2") && !___ground.isGrounded)
			{
				___R2Trick = false;
				___L2Trick = false;
				___R2L2Trick = true;
			}
			else
			{
				___R2L2Trick = false;
			}
			if (___player.GetButton("L1") && ___player.GetButton("R1") && !___ground.isGrounded)
			{
				___R1Trick = false;
				___L1Trick = false;
				___L1R1Trick = true;
			}
			else
			{
				___L1R1Trick = false;
			}
			___sCont.fakie = ___fakie;
			if (!___menuScript.menuScreen && !___ragdollC.ragdoll && !___pauseScript.freezeTime)
			{
				if (Mod.mod.LoopingAnimations)
				{
					if (___player.GetButton("RSRight") && !___ground.isGrounded && ___R1Trick)
					{
						___anim.speed = Mod.mod.AnimationSpeeds[0];
						___anim.SetBool("BarSpin", true);
					}
					else
					{
						___anim.SetBool("BarSpin", false);
					}
					if (___player.GetButton("RSLeft") && !___ground.isGrounded && ___R1Trick)
					{
						___anim.speed = Mod.mod.AnimationSpeeds[1];
						___anim.SetBool("OppoBar", true);
					}
					else
					{
						___anim.SetBool("OppoBar", false);
					}
					if (___player.GetButton("RSRight") && !___ground.isGrounded && ___L1R1Trick)
					{
						___anim.speed = Mod.mod.AnimationSpeeds[2];
						___anim.SetBool("TDBar", true);
					}
					else
					{
						___anim.SetBool("TDBar", false);
					}
					if (___player.GetButton("RSLeft") && !___ground.isGrounded && ___L1R1Trick)
					{
						___anim.speed = Mod.mod.AnimationSpeeds[3];
						___anim.SetBool("TDOBar", true);
					}
					else
					{
						___anim.SetBool("TDOBar", false);
					}
					if (___player.GetButton("RSRight") && !___ground.isGrounded && ___R2Trick)
					{
						___anim.speed = Mod.mod.AnimationSpeeds[4];
						___anim.SetBool("TailWhip", true);
					}
					else
					{
						___anim.SetBool("TailWhip", false);
					}
					if (___player.GetButton("RSRight") && !___ground.isGrounded && ___R2L2Trick)
					{
						___anim.speed = Mod.mod.AnimationSpeeds[5];
						___anim.SetBool("RotorWhip", true);
					}
					else
					{
						___anim.SetBool("RotorWhip", false);
					}
					if (___player.GetButton("RSDown") && !___ground.isGrounded && ___L1R1Trick)
					{
						___anim.speed = Mod.mod.AnimationSpeeds[6];
						___anim.SetBool("BriFlip", true);
					}
					else
					{
						___anim.SetBool("BriFlip", false);
					}
					if (___player.GetButton("RSUp") && !___ground.isGrounded && ___L1R1Trick)
					{
						___anim.speed = Mod.mod.AnimationSpeeds[7];
						___anim.SetBool("NothingFlip", true);
					}
					else
					{
						___anim.SetBool("NothingFlip", false);
					}
					if (___player.GetButton("RSLeft") && !___ground.isGrounded && ___R2Trick)
					{
						___anim.speed = Mod.mod.AnimationSpeeds[8];
						___anim.SetBool("HeelFlip", true);
					}
					else
					{
						___anim.SetBool("HeelFlip", false);
					}
					if (___player.GetButtonDown("RSDown") && !___ground.isGrounded && ___R2L2Trick)
					{
						___anim.speed = Mod.mod.AnimationSpeeds[9];
						___anim.SetBool("Kickless", true);
					}
					else
					{
						___anim.SetBool("Kickless", false);
					}
				}
				else
				{
					if (___player.GetButtonDown("RSRight") && !___ground.isGrounded && ___R1Trick)
					{
						if (Mod.mod.InstantAnimations)
						{
							___anim.speed = Mod.mod.AnimationSpeeds[0];
							___anim.Play("BarSpin");
						}
						else
						{
							___anim.speed = Mod.mod.AnimationSpeeds[0];
							___anim.SetTrigger("BarSpin");
						}
					}
					if (___player.GetButtonDown("RSLeft") && !___ground.isGrounded && ___R1Trick)
					{
						if (Mod.mod.InstantAnimations)
						{
							___anim.speed = Mod.mod.AnimationSpeeds[1];
							___anim.Play("OppoBar");
						}
						else
						{
							___anim.speed = Mod.mod.AnimationSpeeds[1];
							___anim.SetTrigger("OppoBar");
						}
					}
					if (___player.GetButtonDown("RSRight") && !___ground.isGrounded && ___L1R1Trick)
					{
						if (Mod.mod.InstantAnimations)
						{
							___anim.speed = Mod.mod.AnimationSpeeds[2];
							___anim.Play("TDBar");
						}
						else
						{
							___anim.speed = Mod.mod.AnimationSpeeds[2];
							___anim.SetTrigger("TDBar");
						}
					}
					if (___player.GetButtonDown("RSLeft") && !___ground.isGrounded && ___L1R1Trick)
					{
						if (Mod.mod.InstantAnimations)
						{
							___anim.speed = Mod.mod.AnimationSpeeds[3];
							___anim.Play("TDOBar");
						}
						else
						{
							___anim.speed = Mod.mod.AnimationSpeeds[3];
							___anim.SetTrigger("TDOBar");
						}
					}
					if (___player.GetButtonDown("RSRight") && !___ground.isGrounded && ___R2Trick)
					{
						if (Mod.mod.InstantAnimations)
						{
							___anim.speed = Mod.mod.AnimationSpeeds[4];
							___anim.Play("TailWhip");
						}
						else
						{
							___anim.speed = Mod.mod.AnimationSpeeds[4];
							___anim.SetTrigger("TailWhip");
						}
					}
					if (___player.GetButtonDown("RSRight") && !___ground.isGrounded && ___R2L2Trick)
					{
						if (Mod.mod.InstantAnimations)
						{
							___anim.speed = Mod.mod.AnimationSpeeds[5];
							___anim.Play("RotorWhip");
						}
						else
						{
							___anim.speed = Mod.mod.AnimationSpeeds[5];
							___anim.SetTrigger("RotorWhip");
						}
					}
					if (___player.GetButtonDown("RSDown") && !___ground.isGrounded && ___L1R1Trick)
					{
						if (Mod.mod.InstantAnimations)
						{
							___anim.speed = Mod.mod.AnimationSpeeds[6];
							___anim.Play("BriFlip");
						}
						else
						{
							___anim.speed = Mod.mod.AnimationSpeeds[6];
							___anim.Play("BriFlip");
						}
					}
					if (___player.GetButtonDown("RSUp") && !___ground.isGrounded && ___L1R1Trick)
					{
						if (Mod.mod.InstantAnimations)
						{
							___anim.speed = Mod.mod.AnimationSpeeds[7];
							___anim.Play("NothingFlip");
						}
						else
						{
							___anim.speed = Mod.mod.AnimationSpeeds[7];
							___anim.Play("NothingFlip");
						}
					}
					if (___player.GetButtonDown("RSLeft") && !___ground.isGrounded && ___R2Trick)
					{
						if (Mod.mod.InstantAnimations)
						{
							___anim.speed = Mod.mod.AnimationSpeeds[8];
							___anim.Play("HeelFlip");
						}
						else
						{
							___anim.speed = Mod.mod.AnimationSpeeds[8];
							___anim.SetTrigger("HeelFlip");
						}
					}
					if (___player.GetButtonDown("RSDown") && !___ground.isGrounded && ___R2L2Trick)
					{
						if (Mod.mod.InstantAnimations)
						{
							___anim.speed = Mod.mod.AnimationSpeeds[9];
							___anim.Play("Kickless");
						}
						else
						{
							___anim.speed = Mod.mod.AnimationSpeeds[9];
							___anim.SetTrigger("Kickless");
						}
					}
				}
				Vector3 vector = ___thisRB.gameObject.transform.InverseTransformDirection(___thisRB.velocity);
				___localV = vector;
				if (___player.GetButton("scoot") && ___ground.isGrounded)
				{
					___anim.speed = 1f;
					___anim.SetBool("Push", true);
				}
				else
				{
					___anim.SetBool("Push", false);
				}
				if (vector.z > 1f)
				{
					___fakie = true;
				}
				if (vector.z < 1f)
				{
					___fakie = false;
				}
				if (___fakie)
				{
					___anim.speed = 1f;
					___anim.SetBool("Fakie", true);
				}
				else
				{
					___anim.SetBool("Fakie", false);
				}
				if (!___fakie)
				{
					___anim.SetBool("FakieExit", true);
				}
				else
				{
					___anim.SetBool("FakieExit", false);
				}
				if (___ground.isGrounded)
				{
					___anim.ResetTrigger("inAir");
					___anim.SetTrigger("movement");
				}
				if (!___ground.isGrounded)
				{
					___anim.ResetTrigger("movement");
					___anim.SetTrigger("inAir");
				}
				if (___player.GetButton("Circle") && ___ground.isGrounded)
				{
					___anim.SetBool("Stopping", true);
				}
				else
				{
					___anim.SetBool("Stopping", false);
				}
				if (___player.GetButton("Circle") && ___ground.isGrounded)
				{
					___anim.SetBool("StoppingExit", false);
				}
				else
				{
					___anim.SetBool("StoppingExit", true);
				}
				if (___anim.GetCurrentAnimatorStateInfo(0).IsName("Manual") && ___ground.isGrounded)
				{
					___manual = true;
					___trickText.text = "Manual";
				}
				else
				{
					___manual = false;
				}
				if (___anim.GetCurrentAnimatorStateInfo(0).IsName("NoseManual") && ___ground.isGrounded)
				{
					___manual = true;
				}
				else
				{
					___manual = false;
				}
				if (___anim.GetCurrentAnimatorStateInfo(0).IsName("DeckGrab") && ___ground.isGrounded)
				{
					___trickText.text = "";
					if (!Mod.mod.noBail)
					{
						___ragdollC.ragdoll = true;
					}
				}
				if (___anim.GetCurrentAnimatorStateInfo(0).IsName("Movement Backwards"))
				{
					___trickText.text = "Fakie";
				}
				if (___anim.GetCurrentAnimatorStateInfo(0).IsName("NoHander") && ___ground.isGrounded)
				{
					___trickText.text = "Tuck No Hander";
					if (!Mod.mod.noBail)
					{
						___ragdollC.ragdoll = true;
					}
				}
				if (___anim.GetCurrentAnimatorStateInfo(0).IsName("TailWhip"))
				{
					___trickText.text = "Tailwhip";
				}
				if (___anim.GetCurrentAnimatorStateInfo(0).IsName("table") && ___ground.isGrounded)
				{
					___trickText.text = "Table";
					if (!Mod.mod.noBail)
					{
						___ragdollC.ragdoll = true;
					}
				}
				if (___anim.GetCurrentAnimatorStateInfo(0).IsName("BarSpin"))
				{
					___trickText.text = "Barspin";
				}
				if (___anim.GetCurrentAnimatorStateInfo(0).IsName("superman") && ___ground.isGrounded)
				{
					___trickText.text = "Superman";
					if (!Mod.mod.noBail)
					{
						___ragdollC.ragdoll = true;
					}
				}
				if (___anim.GetCurrentAnimatorStateInfo(0).IsName("HeelFlip"))
				{
					___trickText.text = "Heelflip";
				}
				if (___anim.GetCurrentAnimatorStateInfo(0).IsName("ContWhip") && ___ground.isGrounded)
				{
					___trickText.text = "";
					if (!Mod.mod.noBail)
					{
						___ragdollC.ragdoll = true;
					}
				}
				if (___anim.GetCurrentAnimatorStateInfo(0).IsName("Turndown") && ___ground.isGrounded && !Mod.mod.noBail)
				{
					___ragdollC.ragdoll = true;
				}
				if (___player.GetButton("RSRight") && !___ground.isGrounded && ___L1Trick)
				{
					___anim.speed = 1f;
					___anim.SetBool("Table", true);
				}
				else
				{
					___anim.SetBool("Table", false);
				}
				if (___player.GetButton("RSRight") && !___ground.isGrounded && ___L1Trick)
				{
					___anim.speed = 1f;
					___anim.SetBool("TableExit", false);
				}
				else
				{
					___anim.SetBool("TableExit", true);
				}
				if (___player.GetButton("RSDown") && !___ground.isGrounded && ___L1Trick)
				{
					___anim.speed = 1f;
					___anim.SetBool("Turndown", true);
				}
				else
				{
					___anim.SetBool("Turndown", false);
				}
				if (___player.GetButton("RSDown") && !___ground.isGrounded && ___L2Trick)
				{
					___anim.speed = 1f;
					___anim.SetBool("Superman", true);
				}
				else
				{
					___anim.SetBool("Superman", false);
				}
				if (___player.GetButton("RSDown") && !___ground.isGrounded && ___L2Trick)
				{
					___anim.speed = 1f;
					___anim.SetBool("SupermanExit", false);
				}
				else
				{
					___anim.SetBool("SupermanExit", true);
				}
				if (___player.GetButton("RSUp") && !___ground.isGrounded && ___R1Trick)
				{
					___anim.speed = 1f;
					___anim.SetBool("NoHands", true);
				}
				else
				{
					___anim.SetBool("NoHands", false);
				}
				if (___player.GetButton("RSUp") && !___ground.isGrounded && ___R1Trick)
				{
					___anim.speed = 1f;
					___anim.SetBool("NoHandsExit", false);
				}
				else
				{
					___anim.SetBool("NoHandsExit", true);
				}
				if (___player.GetButton("RSDown") && !___ground.isGrounded && ___R1Trick)
				{
					___anim.speed = 1f;
					___anim.SetBool("DeckGrab", true);
				}
				else
				{
					___anim.SetBool("DeckGrab", false);
				}
				if (___player.GetButton("RSDown") && !___ground.isGrounded && ___R1Trick)
				{
					___anim.speed = 1f;
					___anim.SetBool("DeckGrabExit", false);
				}
				else
				{
					___anim.SetBool("DeckGrabExit", true);
				}
				if (___player.GetButton("RSLeft") && !___ground.isGrounded && ___R2L2Trick)
				{
					___anim.speed = Mod.mod.AnimationSpeeds[10];
					___anim.SetBool("ContWhip", true);
				}
				else
				{
					___anim.SetBool("ContWhip", false);
				}
				if (___player.GetButton("RSLeft") && !___ground.isGrounded && ___R2L2Trick)
				{
					___anim.SetBool("CBallExit", false);
				}
				else
					___anim.SetBool("CBallExit", true);
			}
			return false;
		}
	}
}