/****************************************************************************
 * 2018.10 DESKTOP-RIU3M20
 ****************************************************************************/

namespace Eagle1st
{
	using UnityEngine;
	using UnityEngine.UI;

	public partial class UIInfoPanel
	{
		public const string NAME = "UIInfoPanel";

		[SerializeField] public Button Btn_QuitPanel;
		[SerializeField] public Button BasicInfo;
		[SerializeField] public Button HisGrade;
		[SerializeField] public Button AddPal;
		[SerializeField] public Image BasicInfoPanel;
		[SerializeField] public Image HisGradePanel;
		[SerializeField] public Image AddPalPanel;

		protected override void ClearUIComponents()
		{
			Btn_QuitPanel = null;
			BasicInfo = null;
			HisGrade = null;
			AddPal = null;
			BasicInfoPanel = null;
			HisGradePanel = null;
			AddPalPanel = null;
		}

		private UIInfoPanelData mPrivateData = null;

		public UIInfoPanelData mData
		{
			get { return mPrivateData ?? (mPrivateData = new UIInfoPanelData()); }
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
