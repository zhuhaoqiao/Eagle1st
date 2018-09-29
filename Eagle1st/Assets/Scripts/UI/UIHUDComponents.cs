/****************************************************************************
 * 2018.9 DESKTOP-S5L3H66
 ****************************************************************************/

namespace Eagle1st
{
	using UnityEngine;
	using UnityEngine.UI;

	public partial class UIHUD
	{
		public const string NAME = "UIHUD";

		[SerializeField] public Image Box_Pre;

		protected override void ClearUIComponents()
		{
			Box_Pre = null;
		}

		private UIHUDData mPrivateData = null;

		public UIHUDData mData
		{
			get { return mPrivateData ?? (mPrivateData = new UIHUDData()); }
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
