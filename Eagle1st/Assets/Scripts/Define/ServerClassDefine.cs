using System;

namespace Eagle1st
{
    /// <summary>
    /// 用户角色
    /// </summary>
    public class PlayerData
    {
        public string ID;
        public string UserID;
        public string RoleID;
        public string PlaneID;
        public string Name;
        public int Leave;
        public int AllNum;
        public int ViNum;
        public string Createor;
        public DateTime CreateDate;
        public string Editor;
        public DateTime EditDate;
    }
    /// <summary>
    /// 好友
    /// </summary>
    public class FriendData
    {
        public string ID;
        public int UserRoleID;
        public int FriendID;
        public int Intimacy;
        public string Createor;
        public DateTime CreateDate;
        public string Editor;
        public DateTime EditDate;
    }
    /// <summary>
    /// 用户
    /// </summary>
    public class UserData
    {
        public string ID;
        public string UserName;
        public string Password;
        public string Model;
        public string Email;
        public DateTime LogTime;
        public DateTime LogOutTime;
        public string Createor;
        public DateTime CreateDate;
        public string Editor;
        public DateTime EditDate;
    }
    /// <summary>
    /// 道具
    /// </summary>
    public class PropData
    {
        
    }
    /// <summary>
    /// 飞机
    /// </summary>
    public class PlaneData
    {
        public string ID;
        public string Createor;
        public DateTime CreateDate;
        public string Editor;
        public DateTime EditDate;
    }
    /// <summary>
    /// 武器
    /// </summary>
    public class WeaponData
    {
        public string ID;
        public string Createor;
        public DateTime CreateDate;
        public string Editor;
        public DateTime EditDate;
    }
    /// <summary>
    /// 成就
    /// </summary>
    public class AchievementData
    {

    }
    /// <summary>
    /// 荣誉
    /// </summary>
    public class HonorData
    {
        public string ID;
        public string Createor;
        public DateTime CreateDate;
        public string Editor;
        public DateTime EditDate;
    }
    /// <summary>
    /// 背包
    /// </summary>
    public class BackpackData
    {

    }
    /// <summary>
    /// 游戏记录
    /// </summary>
    public class RecordData
    {

    }
}
