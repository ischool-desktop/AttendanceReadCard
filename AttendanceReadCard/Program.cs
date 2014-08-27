using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA;
using FISCA.Presentation;
using FISCA.Permission;

namespace AttendanceReadCard
{
    public static class Program
    {
        public const string SetupFormCoode = "出缺席讀卡模組.讀卡設定";

        public const string ReadCardFormCode = "出缺席讀卡模組.出缺席讀卡";

        [MainMethod()]
        public static void Main()
        {
            RibbonBarItemManager ribbon = FISCA.Presentation.MotherForm.RibbonBarItems;

            MenuButton button = ribbon["學務作業", "基本設定"]["設定"]["出缺席讀卡設定"];
            button.Enable = UserAcl.Current[SetupFormCoode].Executable;
            button.Click += delegate
            {
                new SetupForm().ShowDialog();
            };

            button = ribbon["學務作業", "批次作業/查詢"]["出缺席讀卡"];
            button.Image = Properties.Resources.ReadCard;
            button.Enable = UserAcl.Current[ReadCardFormCode].Executable;
            button.Click += delegate
            {
                new ReadCardForm().ShowDialog();
            };

            Catalog catalog = RoleAclSource.Instance["學務作業"]["功能按鈕"];
            catalog.Add(new RibbonFeature(SetupFormCoode, "出缺席讀卡設定"));
            catalog.Add(new RibbonFeature(ReadCardFormCode, "出缺席讀卡"));
        }

        /// <summary>
        /// 卡片上所提供的節次列表。
        /// </summary>
        public static string[] PeriodNameList = new string[] { "早自習/升旗", 
                    "第一節", "第二節", "第三節", "第四節", "午休",
                    "第五節", "第六節", "第七節", "第八節" };
    }
}
