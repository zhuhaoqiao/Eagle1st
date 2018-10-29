/****************************************************************************
 * 2018.10 DESKTOP-RIU3M20
 ****************************************************************************/

namespace Eagle1st
{
	using UnityEngine;
	using UnityEngine.UI;

	public partial class UIPlayerMainMenu
	{
		public const string NAME = "UIPlayerMainMenu";

		[SerializeField] public Button FlyPractice;
		[SerializeField] public Button Environment;
		[SerializeField] public Button FriendList;
		[SerializeField] public Button SelfInfo;
		[SerializeField] public Button GameSetting;
		[SerializeField] public Button QuickGame;
		[SerializeField] public Button MultiPlayer;
		[SerializeField] public Button QuitGame;

		protected override void ClearUIComponents()
		{
			FlyPractice = null;
			Environment = null;
			FriendList = null;
			SelfInfo = null;
			GameSetting = null;
			QuickGame = null;
			MultiPlayer = null;
			QuitGame = null;
		}

		private UIPlayerMainMenuData mPrivateData = null;

		public UIPlayerMainMenuData mData
		{
			get { return mPrivateData ?? (mPrivateData = new UIPlayerMainMenuData()); }
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
