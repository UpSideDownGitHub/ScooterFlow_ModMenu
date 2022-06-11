using System;
using Cinemachine;
using UnityEngine;

namespace USDCModMenu
{
    public class Mod : MonoBehaviour
	{
		private void Start()
		{
			mod = this;
		}
		private void Update()
		{
		}
		public void Gui()
		{
		}
		private void OnGUI()
		{
			DrawMenu();
		}

		public void DrawMenu()
		{
			if (doOnce)
			{
				OrignalValues[0] = Physics.gravity.y;
				OrignalValues[1] = Time.timeScale;
				OrignalValues[2] = 1f;
				OrignalValues[3] = CS.cam1.GetComponent<CinemachineFreeLook>().m_Lens.FieldOfView;
				OrignalValues[4] = CS.cam2.GetComponent<CinemachineFreeLook>().m_Lens.FieldOfView;
				OrignalValues[5] = CS.cam3.GetComponent<CinemachineFreeLook>().m_Lens.FieldOfView;
				OrignalValues[6] = CS.fpCam.GetComponent<Camera>().fieldOfView;
				OrignalValues[7] = H.strength;
				OrignalValues[8] = H.air;
				OrignalValues[9] = PF.m_Thrust;
				OrignalValues[10] = PF.maxSpeed;
				OrignalValues[11] = PF.minSpeed;
				OrignalValues[12] = RT.t_Spin_Speed;
				OrignalValues[13] = RT.rotationSpeed;
				OrignalValues[14] = SC.maxMotorTorque;
				OrignalValues[15] = SC.maxSteeringAngle;
				OrignalValues[16] = H.transform.position.x;
				OrignalValues[17] = H.transform.position.y;
				OrignalValues[18] = H.transform.position.z;
				OrignalValues[19] = 0f;
				OrignalValues[20] = 0.15f;
				OrignalValues[21] = 0f;
				OrignalValues[22] = 600f;
				OrignalValues[23] = 600f;
				OrignalValues[24] = 0f;
				OrignalValues[25] = 0f;
				OrignalValues[26] = 0f;
				OrignalValues[27] = 0f;
				OrignalValues[30] = 1f;
				doOnce = false;
			}
			if (GUI.Button(new Rect(0f, 0f, 30f, 30f), "1"))
			{
				Debug.Log("Button Pressed");
				Menu1 = !Menu1;
			}
			if (GUI.Button(new Rect(1870f, 30f, 50f, 30f), "Maps"))
			{
				openModMaps = !openModMaps;
			}
			if (Menu1)
			{
				Menu = GUI.Window(0, Menu, new GUI.WindowFunction(drawMenu), "USDC's Mod Menu");
			}
		}

		public void drawMenu(int windowID)
		{
			i = 1;
			scrollPosition = GUI.BeginScrollView(new Rect(10f, 30f, 630f, 1000f), scrollPosition, new Rect(0f, 0f, 610f, 2000f));
			GUI.Label(new Rect(10f, 50f * (float)i, 100f, 30f), "Gravity");
			Rect position = new Rect(100f, 50f * (float)i, 100f, 30f);
			Vector3 vector = Physics.gravity;
			GUI.Label(position, vector.y.ToString());
			if (GUI.Button(new Rect(200f, 50f * (float)i, 30f, 30f), "+"))
			{
				Physics.gravity += new Vector3(0f, 0.5f);
			}
			if (GUI.Button(new Rect(250f, 50f * (float)i, 30f, 30f), "-"))
			{
				Physics.gravity -= new Vector3(0f, 0.5f);
			}
			CustomValues[0] = GUI.TextField(new Rect(300f, 50f * (float)i, 100f, 30f), CustomValues[0]);
			if (GUI.Button(new Rect(410f, 50f * (float)i, 60f, 30f), "Set"))
			{
				Physics.gravity = new Vector3(0f, float.Parse(CustomValues[0]));
			}
			if (GUI.Button(new Rect(480f, 50f * (float)i, 60f, 30f), "Reset"))
			{
				Physics.gravity = new Vector3(0f, OrignalValues[0]);
			}
			i++;
			GUI.Label(new Rect(10f, 50f * (float)i, 100f, 30f), "Time Scale");
			GUI.Label(new Rect(100f, 50f * (float)i, 100f, 30f), Time.timeScale.ToString());
			if (GUI.Button(new Rect(200f, 50f * (float)i, 30f, 30f), "+"))
			{
				Time.timeScale += 0.5f;
			}
			if (GUI.Button(new Rect(250f, 50f * (float)i, 30f, 30f), "-"))
			{
				Time.timeScale -= 0.5f;
			}
			CustomValues[1] = GUI.TextField(new Rect(300f, 50f * (float)i, 100f, 30f), CustomValues[1]);
			if (GUI.Button(new Rect(410f, 50f * (float)i, 60f, 30f), "Set"))
			{
				Time.timeScale = float.Parse(CustomValues[1]);
			}
			if (GUI.Button(new Rect(480f, 50f * (float)i, 60f, 30f), "Reset"))
			{
				Time.timeScale = OrignalValues[1];
			}
			i++;
			if (GUI.Button(new Rect(10f, 50f * (float)i, 100f, 30f), "Animations"))
			{
				animationTab = !animationTab;
			}
			i++;
			if (animationTab)
			{
				InstantAnimations = GUI.Toggle(new Rect(10f, 50f * (float)i, 200f, 30f), InstantAnimations, "Instant Animations");
				i++;
				LoopingAnimations = GUI.Toggle(new Rect(10f, 50f * (float)i, 200f, 30f), LoopingAnimations, "Looping Animations");
				i++;
				for (int j = 0; j < AnimationName.Length; j++)
				{
					GUI.Label(new Rect(10f, 50f * (float)i, 100f, 30f), AnimationName[j]);
					GUI.Label(new Rect(100f, 50f * (float)i, 100f, 30f), AnimationSpeeds[j].ToString());
					if (GUI.Button(new Rect(200f, 50f * (float)i, 30f, 30f), "+"))
					{
						AnimationSpeeds[j] += 0.5f;
					}
					if (GUI.Button(new Rect(250f, 50f * (float)i, 30f, 30f), "-"))
					{
						AnimationSpeeds[j] -= 0.5f;
					}
					CustomValues[30 + j] = GUI.TextField(new Rect(300f, 50f * (float)i, 100f, 30f), CustomValues[30 + j]);
					if (GUI.Button(new Rect(410f, 50f * (float)i, 60f, 30f), "Set"))
					{
						AnimationSpeeds[j] = float.Parse(CustomValues[30 + j]);
					}
					if (GUI.Button(new Rect(480f, 50f * (float)i, 60f, 30f), "Reset"))
					{
						AnimationSpeeds[j] = OrignalValues[30];
					}
					i++;
				}
			}
			if (GUI.Button(new Rect(10f, 50f * (float)i, 100f, 30f), "Camera"))
			{
				cameraTab = !cameraTab;
			}
			i++;
			if (cameraTab)
			{
				GUI.Label(new Rect(10f, 50f * (float)i, 100f, 30f), "Camera 1 FOV");
				GUI.Label(new Rect(100f, 50f * (float)i, 100f, 30f), CS.cam1.GetComponent<CinemachineFreeLook>().m_Lens.FieldOfView.ToString());
				if (GUI.Button(new Rect(200f, 50f * (float)i, 30f, 30f), "+"))
				{
					CinemachineFreeLook component = CS.cam1.GetComponent<CinemachineFreeLook>();
					component.m_Lens.FieldOfView = component.m_Lens.FieldOfView + 0.5f;
				}
				if (GUI.Button(new Rect(250f, 50f * (float)i, 30f, 30f), "-"))
				{
					CinemachineFreeLook component2 = CS.cam1.GetComponent<CinemachineFreeLook>();
					component2.m_Lens.FieldOfView = component2.m_Lens.FieldOfView - 0.5f;
				}
				CustomValues[3] = GUI.TextField(new Rect(300f, 50f * (float)i, 100f, 30f), CustomValues[3]);
				if (GUI.Button(new Rect(410f, 50f * (float)i, 60f, 30f), "Set"))
				{
					CS.cam1.GetComponent<CinemachineFreeLook>().m_Lens.FieldOfView = float.Parse(CustomValues[3]);
				}
				if (GUI.Button(new Rect(480f, 50f * (float)i, 60f, 30f), "Reset"))
				{
					CS.cam1.GetComponent<CinemachineFreeLook>().m_Lens.FieldOfView = OrignalValues[3];
				}
				i++;
				GUI.Label(new Rect(10f, 50f * (float)i, 100f, 30f), "Camera 2 FOV");
				GUI.Label(new Rect(100f, 50f * (float)i, 100f, 30f), CS.cam2.GetComponent<CinemachineFreeLook>().m_Lens.FieldOfView.ToString());
				if (GUI.Button(new Rect(200f, 50f * (float)i, 30f, 30f), "+"))
				{
					CinemachineFreeLook component3 = CS.cam2.GetComponent<CinemachineFreeLook>();
					component3.m_Lens.FieldOfView = component3.m_Lens.FieldOfView + 0.5f;
				}
				if (GUI.Button(new Rect(250f, 50f * (float)i, 30f, 30f), "-"))
				{
					CinemachineFreeLook component4 = CS.cam2.GetComponent<CinemachineFreeLook>();
					component4.m_Lens.FieldOfView = component4.m_Lens.FieldOfView - 0.5f;
				}
				CustomValues[4] = GUI.TextField(new Rect(300f, 50f * (float)i, 100f, 30f), CustomValues[4]);
				if (GUI.Button(new Rect(410f, 50f * (float)i, 60f, 30f), "Set"))
				{
					CS.cam2.GetComponent<CinemachineFreeLook>().m_Lens.FieldOfView = float.Parse(CustomValues[4]);
				}
				if (GUI.Button(new Rect(480f, 50f * (float)i, 60f, 30f), "Reset"))
				{
					CS.cam2.GetComponent<CinemachineFreeLook>().m_Lens.FieldOfView = OrignalValues[4];
				}
				i++;
				GUI.Label(new Rect(10f, 50f * (float)i, 100f, 30f), "Camera 3 FOV");
				GUI.Label(new Rect(100f, 50f * (float)i, 100f, 30f), CS.cam3.GetComponent<CinemachineFreeLook>().m_Lens.FieldOfView.ToString());
				if (GUI.Button(new Rect(200f, 50f * (float)i, 30f, 30f), "+"))
				{
					CinemachineFreeLook component5 = CS.cam3.GetComponent<CinemachineFreeLook>();
					component5.m_Lens.FieldOfView = component5.m_Lens.FieldOfView + 0.5f;
				}
				if (GUI.Button(new Rect(250f, 50f * (float)i, 30f, 30f), "-"))
				{
					CinemachineFreeLook component6 = CS.cam3.GetComponent<CinemachineFreeLook>();
					component6.m_Lens.FieldOfView = component6.m_Lens.FieldOfView - 0.5f;
				}
				CustomValues[5] = GUI.TextField(new Rect(300f, 50f * (float)i, 100f, 30f), CustomValues[5]);
				if (GUI.Button(new Rect(410f, 50f * (float)i, 60f, 30f), "Set"))
				{
					CS.cam3.GetComponent<CinemachineFreeLook>().m_Lens.FieldOfView = float.Parse(CustomValues[5]);
				}
				if (GUI.Button(new Rect(480f, 50f * (float)i, 60f, 30f), "Reset"))
				{
					CS.cam3.GetComponent<CinemachineFreeLook>().m_Lens.FieldOfView = OrignalValues[5];
				}
				i++;
				GUI.Label(new Rect(10f, 50f * (float)i, 100f, 30f), "FP Cam FOV");
				GUI.Label(new Rect(100f, 50f * (float)i, 350f, 30f), CS.fpCam.GetComponent<Camera>().fieldOfView.ToString());
				if (GUI.Button(new Rect(200f, 50f * (float)i, 30f, 30f), "+"))
				{
					CS.fpCam.GetComponent<Camera>().fieldOfView += 0.5f;
				}
				if (GUI.Button(new Rect(250f, 50f * (float)i, 30f, 30f), "-"))
				{
					CS.fpCam.GetComponent<Camera>().fieldOfView -= 0.5f;
				}
				CustomValues[6] = GUI.TextField(new Rect(300f, 50f * (float)i, 100f, 30f), CustomValues[6]);
				if (GUI.Button(new Rect(410f, 50f * (float)i, 60f, 30f), "Set"))
				{
					CS.fpCam.GetComponent<Camera>().fieldOfView = float.Parse(CustomValues[6]);
				}
				if (GUI.Button(new Rect(480f, 50f * (float)i, 60f, 30f), "Reset"))
				{
					CS.fpCam.GetComponent<Camera>().fieldOfView = OrignalValues[6];
				}
				i++;
			}
			if (GUI.Button(new Rect(10f, 50f * (float)i, 100f, 30f), "Jump"))
			{
				jumpTab = !jumpTab;
			}
			i++;
			if (jumpTab)
			{
				GUI.Label(new Rect(10f, 50f * (float)i, 100f, 30f), "Strength");
				GUI.Label(new Rect(100f, 50f * (float)i, 100f, 30f), H.strength.ToString());
				if (GUI.Button(new Rect(200f, 50f * (float)i, 30f, 30f), "+"))
				{
					H.strength += 0.5f;
				}
				if (GUI.Button(new Rect(250f, 50f * (float)i, 30f, 30f), "-"))
				{
					H.strength -= 0.5f;
				}
				CustomValues[7] = GUI.TextField(new Rect(300f, 50f * (float)i, 100f, 30f), CustomValues[7]);
				if (GUI.Button(new Rect(410f, 50f * (float)i, 60f, 30f), "Set"))
				{
					H.strength = float.Parse(CustomValues[7]);
				}
				if (GUI.Button(new Rect(480f, 50f * (float)i, 60f, 30f), "Reset"))
				{
					H.strength = OrignalValues[7];
				}
				i++;
				GUI.Label(new Rect(10f, 50f * (float)i, 100f, 30f), "Air Strength");
				GUI.Label(new Rect(100f, 50f * (float)i, 100f, 30f), H.air.ToString());
				if (GUI.Button(new Rect(200f, 50f * (float)i, 30f, 30f), "+"))
				{
					H.air += 0.5f;
				}
				if (GUI.Button(new Rect(250f, 50f * (float)i, 30f, 30f), "-"))
				{
					H.air -= 0.5f;
				}
				CustomValues[8] = GUI.TextField(new Rect(300f, 50f * (float)i, 100f, 30f), CustomValues[8]);
				if (GUI.Button(new Rect(410f, 50f * (float)i, 60f, 30f), "Set"))
				{
					H.air = float.Parse(CustomValues[8]);
				}
				if (GUI.Button(new Rect(480f, 50f * (float)i, 60f, 30f), "Reset"))
				{
					H.air = OrignalValues[8];
				}
				i++;
			}
			if (GUI.Button(new Rect(10f, 50f * (float)i, 100f, 30f), "Push"))
			{
				pushTab = !pushTab;
			}
			i++;
			if (pushTab)
			{
				GUI.Label(new Rect(10f, 50f * (float)i, 100f, 30f), "Force");
				GUI.Label(new Rect(100f, 50f * (float)i, 100f, 30f), PF.m_Thrust.ToString());
				if (GUI.Button(new Rect(200f, 50f * (float)i, 30f, 30f), "+"))
				{
					PF.m_Thrust += 0.5f;
				}
				if (GUI.Button(new Rect(250f, 50f * (float)i, 30f, 30f), "-"))
				{
					PF.m_Thrust -= 0.5f;
				}
				CustomValues[9] = GUI.TextField(new Rect(300f, 50f * (float)i, 100f, 30f), CustomValues[9]);
				if (GUI.Button(new Rect(410f, 50f * (float)i, 60f, 30f), "Set"))
				{
					PF.m_Thrust = float.Parse(CustomValues[9]);
				}
				if (GUI.Button(new Rect(480f, 50f * (float)i, 60f, 30f), "Reset"))
				{
					PF.m_Thrust = OrignalValues[9];
				}
				i++;
				GUI.Label(new Rect(10f, 50f * (float)i, 100f, 30f), "Max Speed");
				GUI.Label(new Rect(100f, 50f * (float)i, 100f, 30f), PF.maxSpeed.ToString());
				if (GUI.Button(new Rect(200f, 50f * (float)i, 30f, 30f), "+"))
				{
					PF.maxSpeed += 0.5f;
				}
				if (GUI.Button(new Rect(250f, 50f * (float)i, 30f, 30f), "-"))
				{
					PF.maxSpeed -= 0.5f;
				}
				CustomValues[10] = GUI.TextField(new Rect(300f, 50f * (float)i, 100f, 30f), CustomValues[10]);
				if (GUI.Button(new Rect(410f, 50f * (float)i, 60f, 30f), "Set"))
				{
					PF.maxSpeed = float.Parse(CustomValues[10]);
				}
				if (GUI.Button(new Rect(480f, 50f * (float)i, 60f, 30f), "Reset"))
				{
					PF.maxSpeed = OrignalValues[10];
				}
				i++;
				GUI.Label(new Rect(10f, 50f * (float)i, 100f, 30f), "Min Speed");
				GUI.Label(new Rect(100f, 50f * (float)i, 100f, 30f), PF.minSpeed.ToString());
				if (GUI.Button(new Rect(200f, 50f * (float)i, 30f, 30f), "+"))
				{
					PF.minSpeed += 0.5f;
				}
				if (GUI.Button(new Rect(250f, 50f * (float)i, 30f, 30f), "-"))
				{
					PF.minSpeed -= 0.5f;
				}
				CustomValues[11] = GUI.TextField(new Rect(300f, 50f * (float)i, 100f, 30f), CustomValues[11]);
				if (GUI.Button(new Rect(410f, 50f * (float)i, 60f, 30f), "Set"))
				{
					PF.minSpeed = float.Parse(CustomValues[11]);
				}
				if (GUI.Button(new Rect(480f, 50f * (float)i, 60f, 30f), "Reset"))
				{
					PF.minSpeed = OrignalValues[11];
				}
				i++;
			}
			if (GUI.Button(new Rect(10f, 50f * (float)i, 100f, 30f), "Air Rotation"))
			{
				airRotationTab = !airRotationTab;
			}
			i++;
			if (airRotationTab)
			{
				GUI.Label(new Rect(10f, 50f * (float)i, 100f, 30f), "t spin Speed");
				GUI.Label(new Rect(100f, 50f * (float)i, 100f, 30f), RT.t_Spin_Speed.ToString());
				if (GUI.Button(new Rect(200f, 50f * (float)i, 30f, 30f), "+"))
				{
					RT.t_Spin_Speed += 0.5f;
				}
				if (GUI.Button(new Rect(250f, 50f * (float)i, 30f, 30f), "-"))
				{
					RT.t_Spin_Speed -= 0.5f;
				}
				CustomValues[12] = GUI.TextField(new Rect(300f, 50f * (float)i, 100f, 30f), CustomValues[12]);
				if (GUI.Button(new Rect(410f, 50f * (float)i, 60f, 30f), "Set"))
				{
					RT.t_Spin_Speed = float.Parse(CustomValues[12]);
				}
				if (GUI.Button(new Rect(480f, 50f * (float)i, 60f, 30f), "Reset"))
				{
					RT.t_Spin_Speed = OrignalValues[12];
				}
				i++;
				GUI.Label(new Rect(10f, 50f * (float)i, 100f, 30f), "Spin Speed");
				GUI.Label(new Rect(100f, 50f * (float)i, 100f, 30f), RT.rotationSpeed.ToString());
				if (GUI.Button(new Rect(200f, 50f * (float)i, 30f, 30f), "+"))
				{
					RT.rotationSpeed += 0.5f;
				}
				if (GUI.Button(new Rect(250f, 50f * (float)i, 30f, 30f), "-"))
				{
					RT.rotationSpeed -= 0.5f;
				}
				CustomValues[13] = GUI.TextField(new Rect(300f, 50f * (float)i, 100f, 30f), CustomValues[13]);
				if (GUI.Button(new Rect(410f, 50f * (float)i, 60f, 30f), "Set"))
				{
					RT.rotationSpeed = float.Parse(CustomValues[13]);
				}
				if (GUI.Button(new Rect(480f, 50f * (float)i, 60f, 30f), "Reset"))
				{
					RT.rotationSpeed = OrignalValues[13];
				}
				i++;
			}
			if (GUI.Button(new Rect(10f, 50f * (float)i, 100f, 30f), "Scooter"))
			{
				scooterControllerTab = !scooterControllerTab;
			}
			i++;
			if (scooterControllerTab)
			{
				GUI.Label(new Rect(10f, 50f * (float)i, 100f, 50f), "Max Motor Torque");
				GUI.Label(new Rect(100f, 50f * (float)i, 100f, 30f), SC.maxMotorTorque.ToString());
				if (GUI.Button(new Rect(200f, 50f * (float)i, 30f, 30f), "+"))
				{
					SC.maxMotorTorque += 0.5f;
				}
				if (GUI.Button(new Rect(250f, 50f * (float)i, 30f, 30f), "-"))
				{
					SC.maxMotorTorque -= 0.5f;
				}
				CustomValues[14] = GUI.TextField(new Rect(300f, 50f * (float)i, 100f, 30f), CustomValues[14]);
				if (GUI.Button(new Rect(410f, 50f * (float)i, 60f, 30f), "Set"))
				{
					SC.maxMotorTorque = float.Parse(CustomValues[14]);
				}
				if (GUI.Button(new Rect(480f, 50f * (float)i, 60f, 30f), "Reset"))
				{
					SC.maxMotorTorque = OrignalValues[14];
				}
				i++;
				GUI.Label(new Rect(10f, 50f * (float)i, 100f, 50f), "Max Stering Angle");
				GUI.Label(new Rect(100f, 50f * (float)i, 100f, 30f), SC.maxSteeringAngle.ToString());
				if (GUI.Button(new Rect(200f, 50f * (float)i, 30f, 30f), "+"))
				{
					SC.maxSteeringAngle += 0.5f;
				}
				if (GUI.Button(new Rect(250f, 50f * (float)i, 30f, 30f), "-"))
				{
					SC.maxSteeringAngle -= 0.5f;
				}
				CustomValues[15] = GUI.TextField(new Rect(300f, 50f * (float)i, 100f, 30f), CustomValues[15]);
				if (GUI.Button(new Rect(410f, 50f * (float)i, 60f, 30f), "Set"))
				{
					SC.maxSteeringAngle = float.Parse(CustomValues[15]);
				}
				if (GUI.Button(new Rect(480f, 50f * (float)i, 60f, 30f), "Reset"))
				{
					SC.maxSteeringAngle = OrignalValues[15];
				}
				i++;
			}
			if (GUI.Button(new Rect(10f, 50f * (float)i, 100f, 30f), "Other"))
			{
				otherTab = !otherTab;
			}
			i++;
			if (otherTab)
			{
				rainbowScooter = GUI.Toggle(new Rect(10f, 50f * (float)i, 200f, 30f), rainbowScooter, "Rainbow Scooter");
				i++;
				instantTeleport = GUI.Toggle(new Rect(10f, 50f * (float)i, 200f, 30f), instantTeleport, "Instant Teleport");
				i++;
				noBail = GUI.Toggle(new Rect(10f, 50f * (float)i, 200f, 30f), noBail, "No Bail");
				i++;
			}
			if (GUI.Button(new Rect(10f, 50f * (float)i, 100f, 30f), "Player"))
			{
				playerTab = !playerTab;
			}
			i++;
			if (playerTab)
			{
				GUI.Label(new Rect(10f, 50f * (float)i, 100f, 30f), "Player X");
				Rect position2 = new Rect(100f, 50f * (float)i, 100f, 30f);
				vector = H.transform.position;
				GUI.Label(position2, vector.x.ToString());
				if (GUI.Button(new Rect(200f, 50f * (float)i, 30f, 30f), "+"))
				{
					H.transform.position += new Vector3(10f, 0f, 0f);
				}
				if (GUI.Button(new Rect(250f, 50f * (float)i, 30f, 30f), "-"))
				{
					H.transform.position -= new Vector3(10f, 0f, 0f);
				}
				CustomValues[16] = GUI.TextField(new Rect(300f, 50f * (float)i, 100f, 30f), CustomValues[16]);
				if (GUI.Button(new Rect(410f, 50f * (float)i, 60f, 30f), "Set"))
				{
					H.transform.position = new Vector3(float.Parse(CustomValues[16]), H.transform.position.y, H.transform.position.z);
				}
				if (GUI.Button(new Rect(480f, 50f * (float)i, 60f, 30f), "Reset"))
				{
					H.transform.position = new Vector3(OrignalValues[16], H.transform.position.y, H.transform.position.z);
				}
				i++;
				GUI.Label(new Rect(10f, 50f * (float)i, 100f, 30f), "Player Y");
				Rect position3 = new Rect(100f, 50f * (float)i, 100f, 30f);
				vector = H.transform.position;
				GUI.Label(position3, vector.x.ToString());
				if (GUI.Button(new Rect(200f, 50f * (float)i, 30f, 30f), "+"))
				{
					H.transform.position += new Vector3(0f, 10f, 0f);
				}
				if (GUI.Button(new Rect(250f, 50f * (float)i, 30f, 30f), "-"))
				{
					H.transform.position -= new Vector3(0f, 10f, 0f);
				}
				CustomValues[17] = GUI.TextField(new Rect(300f, 50f * (float)i, 100f, 30f), CustomValues[17]);
				if (GUI.Button(new Rect(410f, 50f * (float)i, 60f, 30f), "Set"))
				{
					H.transform.position = new Vector3(H.transform.position.x, float.Parse(CustomValues[17]), H.transform.position.z);
				}
				if (GUI.Button(new Rect(480f, 50f * (float)i, 60f, 30f), "Reset"))
				{
					H.transform.position = new Vector3(H.transform.position.x, OrignalValues[17], H.transform.position.z);
				}
				i++;
				GUI.Label(new Rect(10f, 50f * (float)i, 100f, 30f), "Player Z");
				Rect position4 = new Rect(100f, 50f * (float)i, 100f, 30f);
				vector = H.transform.position;
				GUI.Label(position4, vector.z.ToString());
				if (GUI.Button(new Rect(200f, 50f * (float)i, 30f, 30f), "+"))
				{
					H.transform.position += new Vector3(0f, 0f, 10f);
				}
				if (GUI.Button(new Rect(250f, 50f * (float)i, 30f, 30f), "-"))
				{
					H.transform.position -= new Vector3(0f, 0f, 10f);
				}
				CustomValues[18] = GUI.TextField(new Rect(300f, 50f * (float)i, 100f, 30f), CustomValues[18]);
				if (GUI.Button(new Rect(410f, 50f * (float)i, 60f, 30f), "Set"))
				{
					H.transform.position = new Vector3(H.transform.position.x, H.transform.position.y, float.Parse(CustomValues[18]));
				}
				if (GUI.Button(new Rect(480f, 50f * (float)i, 60f, 30f), "Reset"))
				{
					H.transform.position = new Vector3(H.transform.position.x, H.transform.position.y, OrignalValues[18]);
				}
				i++;
				GUI.Label(new Rect(10f, 50f * (float)i, 100f, 30f), "Rot X");
				Rect position5 = new Rect(100f, 50f * (float)i, 100f, 30f);
				Quaternion rotation = H.transform.rotation;
				GUI.Label(position5, rotation.x.ToString());
				if (GUI.Button(new Rect(200f, 50f * (float)i, 30f, 30f), "+"))
				{
					H.transform.rotation *= new Quaternion(10f, 0f, 0f, 0f);
				}
				if (GUI.Button(new Rect(250f, 50f * (float)i, 30f, 30f), "-"))
				{
					H.transform.rotation *= Quaternion.Inverse(new Quaternion(10f, 0f, 0f, 0f));
				}
				CustomValues[24] = GUI.TextField(new Rect(300f, 50f * (float)i, 100f, 30f), CustomValues[24]);
				if (GUI.Button(new Rect(410f, 50f * (float)i, 60f, 30f), "Set"))
				{
					H.transform.rotation = new Quaternion(float.Parse(CustomValues[24]), H.transform.rotation.y, H.transform.rotation.z, H.transform.rotation.w);
				}
				if (GUI.Button(new Rect(480f, 50f * (float)i, 60f, 30f), "Reset"))
				{
					H.transform.localRotation = new Quaternion(OrignalValues[24], H.transform.localRotation.y, H.transform.localRotation.z, H.transform.localRotation.w);
				}
				i++;
				GUI.Label(new Rect(10f, 50f * (float)i, 100f, 30f), "Rot Y");
				Rect position6 = new Rect(100f, 50f * (float)i, 100f, 30f);
				rotation = H.transform.rotation;
				GUI.Label(position6, rotation.x.ToString());
				if (GUI.Button(new Rect(200f, 50f * (float)i, 30f, 30f), "+"))
				{
					H.transform.rotation *= new Quaternion(0f, 10f, 0f, 0f);
				}
				if (GUI.Button(new Rect(250f, 50f * (float)i, 30f, 30f), "-"))
				{
					H.transform.rotation *= Quaternion.Inverse(new Quaternion(0f, 10f, 0f, 0f));
				}
				CustomValues[25] = GUI.TextField(new Rect(300f, 50f * (float)i, 100f, 30f), CustomValues[25]);
				if (GUI.Button(new Rect(410f, 50f * (float)i, 60f, 30f), "Set"))
				{
					H.transform.rotation = new Quaternion(H.transform.rotation.x, float.Parse(CustomValues[25]), H.transform.rotation.z, H.transform.rotation.w);
				}
				if (GUI.Button(new Rect(480f, 50f * (float)i, 60f, 30f), "Reset"))
				{
					H.transform.rotation = new Quaternion(H.transform.rotation.x, OrignalValues[25], H.transform.rotation.z, H.transform.rotation.w);
				}
				i++;
				GUI.Label(new Rect(10f, 50f * (float)i, 100f, 30f), "Rot Z");
				Rect position7 = new Rect(100f, 50f * (float)i, 100f, 30f);
				rotation = H.transform.rotation;
				GUI.Label(position7, rotation.z.ToString());
				if (GUI.Button(new Rect(200f, 50f * (float)i, 30f, 30f), "+"))
				{
					H.transform.rotation *= new Quaternion(0f, 0f, 10f, 0f);
				}
				if (GUI.Button(new Rect(250f, 50f * (float)i, 30f, 30f), "-"))
				{
					H.transform.rotation *= Quaternion.Inverse(new Quaternion(0f, 0f, 10f, 0f));
				}
				CustomValues[26] = GUI.TextField(new Rect(300f, 50f * (float)i, 100f, 30f), CustomValues[26]);
				if (GUI.Button(new Rect(410f, 50f * (float)i, 60f, 30f), "Set"))
				{
					H.transform.rotation = new Quaternion(H.transform.rotation.x, H.transform.rotation.y, float.Parse(CustomValues[26]), H.transform.rotation.w);
				}
				if (GUI.Button(new Rect(480f, 50f * (float)i, 60f, 30f), "Reset"))
				{
					H.transform.rotation = new Quaternion(H.transform.rotation.x, H.transform.rotation.y, OrignalValues[26], H.transform.rotation.w);
				}
				i++;
				GUI.Label(new Rect(10f, 50f * (float)i, 100f, 30f), "Rot W");
				Rect position8 = new Rect(100f, 50f * (float)i, 100f, 30f);
				rotation = H.transform.rotation;
				GUI.Label(position8, rotation.z.ToString());
				if (GUI.Button(new Rect(200f, 50f * (float)i, 30f, 30f), "+"))
				{
					H.transform.rotation *= new Quaternion(0f, 0f, 0f, 10f);
				}
				if (GUI.Button(new Rect(250f, 50f * (float)i, 30f, 30f), "-"))
				{
					H.transform.rotation *= Quaternion.Inverse(new Quaternion(0f, 0f, 0f, 10f));
				}
				CustomValues[27] = GUI.TextField(new Rect(300f, 50f * (float)i, 100f, 30f), CustomValues[27]);
				if (GUI.Button(new Rect(410f, 50f * (float)i, 60f, 30f), "Set"))
				{
					H.transform.rotation = new Quaternion(H.transform.rotation.x, H.transform.rotation.y, H.transform.rotation.z, float.Parse(CustomValues[27]));
				}
				if (GUI.Button(new Rect(480f, 50f * (float)i, 60f, 30f), "Reset"))
				{
					H.transform.rotation = new Quaternion(H.transform.rotation.x, H.transform.rotation.y, H.transform.rotation.z, OrignalValues[27]);
				}
				i++;
			}
			if (GUI.Button(new Rect(10f, 50f * (float)i, 100f, 30f), "Rotation"))
			{
				Spinning = !Spinning;
			}
			i++;
			if (Spinning)
			{
				improvedSpins = GUI.Toggle(new Rect(10f, 50f * (float)i, 200f, 30f), improvedSpins, "Improved Rotation");
				i++;
				if (improvedSpins)
				{
					GUI.Label(new Rect(10f, 50f * (float)i, 100f, 50f), "Spin Speed");
					GUI.Label(new Rect(100f, 50f * (float)i, 100f, 30f), SpinSpeed.ToString());
					if (GUI.Button(new Rect(200f, 50f * (float)i, 30f, 30f), "+"))
					{
						SpinSpeed = temp.x + 0.5f;
					}
					if (GUI.Button(new Rect(250f, 50f * (float)i, 30f, 30f), "-"))
					{
						SpinSpeed = temp.x - 0.5f;
					}
					CustomValues[22] = GUI.TextField(new Rect(300f, 50f * (float)i, 100f, 30f), CustomValues[22]);
					if (GUI.Button(new Rect(410f, 50f * (float)i, 60f, 30f), "Set"))
					{
						SpinSpeed = float.Parse(CustomValues[22]);
					}
					if (GUI.Button(new Rect(480f, 50f * (float)i, 60f, 30f), "Reset"))
					{
						SpinSpeed = OrignalValues[22];
					}
					i++;
					GUI.Label(new Rect(10f, 50f * (float)i, 100f, 50f), "Flip Speed");
					GUI.Label(new Rect(100f, 50f * (float)i, 100f, 30f), FlipSpeed.ToString());
					if (GUI.Button(new Rect(200f, 50f * (float)i, 30f, 30f), "+"))
					{
						FlipSpeed = temp.x + 0.5f;
					}
					if (GUI.Button(new Rect(250f, 50f * (float)i, 30f, 30f), "-"))
					{
						FlipSpeed = temp.x - 0.5f;
					}
					CustomValues[23] = GUI.TextField(new Rect(300f, 50f * (float)i, 100f, 30f), CustomValues[23]);
					if (GUI.Button(new Rect(410f, 50f * (float)i, 60f, 30f), "Set"))
					{
						FlipSpeed = float.Parse(CustomValues[23]);
					}
					if (GUI.Button(new Rect(480f, 50f * (float)i, 60f, 30f), "Reset"))
					{
						FlipSpeed = OrignalValues[23];
					}
					i++;
					GUI.Label(new Rect(10f, 50f * (float)i, 100f, 50f), "X");
					GUI.Label(new Rect(100f, 50f * (float)i, 100f, 30f), temp.x.ToString());
					if (GUI.Button(new Rect(200f, 50f * (float)i, 30f, 30f), "+"))
					{
						temp.x = temp.x + 0.5f;
					}
					if (GUI.Button(new Rect(250f, 50f * (float)i, 30f, 30f), "-"))
					{
						temp.x = temp.x - 0.5f;
					}
					CustomValues[19] = GUI.TextField(new Rect(300f, 50f * (float)i, 100f, 30f), CustomValues[19]);
					if (GUI.Button(new Rect(410f, 50f * (float)i, 60f, 30f), "Set"))
					{
						temp.x = float.Parse(CustomValues[19]);
					}
					if (GUI.Button(new Rect(480f, 50f * (float)i, 60f, 30f), "Reset"))
					{
						temp.x = OrignalValues[19];
					}
					i++;
					GUI.Label(new Rect(10f, 50f * (float)i, 100f, 50f), "Y");
					GUI.Label(new Rect(100f, 50f * (float)i, 100f, 30f), temp.y.ToString());
					if (GUI.Button(new Rect(200f, 50f * (float)i, 30f, 30f), "+"))
					{
						temp.y = temp.y + 0.5f;
					}
					if (GUI.Button(new Rect(250f, 50f * (float)i, 30f, 30f), "-"))
					{
						temp.y = temp.y - 0.5f;
					}
					CustomValues[20] = GUI.TextField(new Rect(300f, 50f * (float)i, 100f, 30f), CustomValues[20]);
					if (GUI.Button(new Rect(410f, 50f * (float)i, 60f, 30f), "Set"))
					{
						temp.y = float.Parse(CustomValues[20]);
					}
					if (GUI.Button(new Rect(480f, 50f * (float)i, 60f, 30f), "Reset"))
					{
						temp.y = OrignalValues[20];
					}
					i++;
					GUI.Label(new Rect(10f, 50f * (float)i, 100f, 50f), "Z");
					GUI.Label(new Rect(100f, 50f * (float)i, 100f, 30f), temp.x.ToString());
					if (GUI.Button(new Rect(200f, 50f * (float)i, 30f, 30f), "+"))
					{
						temp.z = temp.z + 0.5f;
					}
					if (GUI.Button(new Rect(250f, 50f * (float)i, 30f, 30f), "-"))
					{
						temp.z = temp.z - 0.5f;
					}
					CustomValues[21] = GUI.TextField(new Rect(300f, 50f * (float)i, 100f, 30f), CustomValues[21]);
					if (GUI.Button(new Rect(410f, 50f * (float)i, 60f, 30f), "Set"))
					{
						temp.z = float.Parse(CustomValues[21]);
					}
					if (GUI.Button(new Rect(480f, 50f * (float)i, 60f, 30f), "Reset"))
					{
						temp.z = OrignalValues[21];
					}
					i++;
				}
			}
			i++;
			GUI.EndScrollView();
			GUI.DragWindow(new Rect(0f, 0f, 10000f, 20f));
		}
		public static Mod mod;

		public bool doOnce = true;

		public bool Menu1;

		public GUISkin guiSkin;

		public Vector2 scrollPosition = Vector2.zero;

		public Rect Menu = new Rect(40f, 10f, 650f, 1050f);

		public float[] OrignalValues = new float[100];

		public string[] CustomValues = new string[100];

		public int i;

		public Animator anim = GameObject.Find("Player").GetComponent<Animator>();

		public PushForce PF = GameObject.Find("Player").GetComponent<PushForce>();

		public Hop H = GameObject.Find("Player").GetComponent<Hop>();

		public RotateTest RT = GameObject.Find("Player").GetComponent<RotateTest>();

		public CameraSettings CS = GameObject.Find("Player").GetComponentInChildren<CameraSettings>();

		public ScooterController SC = GameObject.Find("Player").GetComponentInChildren<ScooterController>();

		public bool InstantAnimations;

		public bool LoopingAnimations;

		public bool animationTab;

		public bool cameraTab;

		public bool jumpTab;

		public bool pushTab;

		public bool airRotationTab;

		public bool scooterControllerTab;

		public bool otherTab;

		public bool rainbowScooter;

		public bool gridSystem;

		public bool instantTeleport;

		public bool noBail;

		public bool Restart = true;

		public bool openModMaps;

		public bool playerTab;

		public bool testingTab = false;

		public Vector3 temp = new Vector3(0f, 0.35f, 0f);

		public bool Spinning = false;

		public bool improvedSpins = false;

		public float SpinSpeed = 400f;

		public float FlipSpeed = 400f;

		public float[] AnimationSpeeds = new float[]
		{
		1f,
		1f,
		1f,
		1f,
		1f,
		1f,
		1f,
		1f,
		1f,
		1f,
		1f
		};

		public string[] AnimationName = new string[]
		{
		"BarSpin",
		"OppoBar",
		"TDBar",
		"TDOBar",
		"TailWhip",
		"RotorWhip",
		"Briflip",
		"NothingFlip",
		"HeelFlip",
		"Kickless",
		"Multi Whip"
		};
	}
}