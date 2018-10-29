/****************************************************************************
 * 2018.10 DESKTOP-RIU3M20
 ****************************************************************************/

namespace Eagle1st
{
	using UnityEngine;
	using UnityEngine.UI;

	public partial class UILoginPanel
	{
		public const string NAME = "UILoginPanel";

		[SerializeField] public InputField Input_Account;
		[SerializeField] public InputField PwdInput;
		[SerializeField] public Button Btn_Login;
		[SerializeField] public Button Btn_Registe;

		protected override void ClearUIComponents()
		{
			Input_Account = null;
			PwdInput = null;
			Btn_Login = null;
			Btn_Registe = null;
		}

		private UILoginPanelData mPrivateData = null;

		public UILoginPanelData mData
		{
			get { return mPrivateData ?? (mPrivateData = new UILoginPanelData()); }
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
