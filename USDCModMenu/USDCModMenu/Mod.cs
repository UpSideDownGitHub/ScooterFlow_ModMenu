using UnityEngine;

namespace USDCModMenu
{
    public class Mod : MonoBehaviour
	{
		// Token: 0x06000007 RID: 7 RVA: 0x000028B8 File Offset: 0x00000AB8
		public void Start()
		{

		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002918 File Offset: 0x00000B18
		public void Update()
		{

		}
		// Token: 0x0600000B RID: 11 RVA: 0x00002ADC File Offset: 0x00000CDC
		public void Gui()
		{

			GUI.Box(new Rect(1515f, 0f, 165f, 220f), "Extras Menu");
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002DA0 File Offset: 0x00000FA0
		public void Menu1()
		{

		}


		// Token: 0x06000011 RID: 17 RVA: 0x00004F83 File Offset: 0x00003183
		public void OnGUI()
		{
			this.Gui();
			this.Menu1();
		}
	}
}