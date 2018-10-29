/****************************************************************************
 * 2018.10 DESKTOP-RIU3M20
 ****************************************************************************/

namespace Eagle1st
{
	using UnityEngine;
	using UnityEngine.UI;

	public partial class UIRegistePanel
	{
		public const string NAME = "UIRegistePanel";

		[SerializeField] public Button Btn_OK;

		protected override void ClearUIComponents()
		{
			Btn_OK = null;
		}

		private UIRegistePanelData mPrivateData = null;

		public UIRegistePanelData mData
		{
			get { return mPrivateData ?? (mPrivateData = new UIRegistePanelData()); }
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
