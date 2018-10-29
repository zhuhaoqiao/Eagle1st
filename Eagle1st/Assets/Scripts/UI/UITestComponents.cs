/****************************************************************************
 * 2018.10 DESKTOP-S5L3H66
 ****************************************************************************/

namespace Eagle1st
{
	using UnityEngine;
	using UnityEngine.UI;

	public partial class UITest
	{
		public const string NAME = "UITest";

		[SerializeField] public Button BtnTest;

		protected override void ClearUIComponents()
		{
			BtnTest = null;
		}

		private UITestData mPrivateData = null;

		public UITestData mData
		{
			get { return mPrivateData ?? (mPrivateData = new UITestData()); }
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
