﻿using System;
using UnityEngine;
using GlobalEnums;

namespace Benchwarp
{
    public static class TopMenu
    {
        private static CanvasPanel panel;
        private static CanvasPanel sceneNamePanel;
        private static GameObject canvas;

        public static void BuildMenu(GameObject _canvas)
        {
            canvas = _canvas;

            sceneNamePanel = new CanvasPanel(_canvas, GUIController.Instance.images["ButtonsMenuBG"], new Vector2(0f, 0f), new Vector2(1346f, 0f), new Rect(0f, 0f, 0f, 0f));
            sceneNamePanel.AddText("SceneName", "Tutorial_01", new Vector2(5f, 1060f), Vector2.zero, GUIController.Instance.trajanNormal, 18);

            panel = new CanvasPanel(_canvas, GUIController.Instance.images["ButtonsMenuBG"], new Vector2(342f, 15f), new Vector2(1346f, 0f), new Rect(0f, 0f, 0f, 0f));

            Rect buttonRect = new Rect(0, 0, GUIController.Instance.images["ButtonRect"].width, GUIController.Instance.images["ButtonRect"].height);

            int fontSize = 12;

            //Main buttons
            panel.AddButton("Warp", GUIController.Instance.images["ButtonRect"], new Vector2(-154f, 40f), Vector2.zero, WarpClicked, buttonRect, GUIController.Instance.trajanBold, "回城");
            panel.AddButton("Settings", GUIController.Instance.images["ButtonRect"], new Vector2(1446f, 0f), Vector2.zero, SettingsClicked, buttonRect, GUIController.Instance.trajanBold, "设置");
            panel.AddPanel("Settings Panel", GUIController.Instance.images["DropdownBG"], new Vector2(1445f, 20f), Vector2.zero, new Rect(0, 0, GUIController.Instance.images["DropdownBG"].width, 270f));
            panel.GetPanel("Settings Panel").AddButton("WarpOnly", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 25f), Vector2.zero, WarpOnlyClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "只回城", fontSize);
            panel.GetPanel("Settings Panel").AddButton("UnlockAll", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 65f), Vector2.zero, UnlockAllClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "全解锁", fontSize);
            panel.GetPanel("Settings Panel").AddButton("ShowScene", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 105f), Vector2.zero, ShowSceneClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "显示房间名", fontSize);

            if (Benchwarp.instance.GlobalSettings.WarpOnly) return;

            panel.AddButton("All", GUIController.Instance.images["ButtonRect"], new Vector2(-154f, 0f), Vector2.zero, AllClicked, buttonRect, GUIController.Instance.trajanBold, "全部");
            panel.AddButton("Cliffs", GUIController.Instance.images["ButtonRect"], new Vector2(-54f, 0f), Vector2.zero, CliffsClicked, buttonRect, GUIController.Instance.trajanBold, "呼啸");
            panel.AddButton("Crossroads", GUIController.Instance.images["ButtonRect"], new Vector2(46f, 0f), Vector2.zero, CrossroadsClicked, buttonRect, GUIController.Instance.trajanBold, "十字路");
            panel.AddButton("Greenpath", GUIController.Instance.images["ButtonRect"], new Vector2(146f, 0f), Vector2.zero, GreenpathClicked, buttonRect, GUIController.Instance.trajanBold, "苍绿");
            panel.AddButton("Canyon", GUIController.Instance.images["ButtonRect"], new Vector2(246f, 0f), Vector2.zero, CanyonClicked, buttonRect, GUIController.Instance.trajanBold, "雾谷");
            panel.AddButton("Wastes", GUIController.Instance.images["ButtonRect"], new Vector2(346f, 0f), Vector2.zero, WastesClicked, buttonRect, GUIController.Instance.trajanBold, "真菌");
            panel.AddButton("City", GUIController.Instance.images["ButtonRect"], new Vector2(446f, 0f), Vector2.zero, CityClicked, buttonRect, GUIController.Instance.trajanBold, "泪城");
            panel.AddButton("RoyalWaterways", GUIController.Instance.images["ButtonRect"], new Vector2(546f, 0f), Vector2.zero, RoyalWaterwaysClicked, buttonRect, GUIController.Instance.trajanBold, "下水道");
            panel.AddButton("Deepnest", GUIController.Instance.images["ButtonRect"], new Vector2(646f, 0f), Vector2.zero, DeepnestClicked, buttonRect, GUIController.Instance.trajanBold, "深巢");
            panel.AddButton("Basin", GUIController.Instance.images["ButtonRect"], new Vector2(746f, 0f), Vector2.zero, BasinClicked, buttonRect, GUIController.Instance.trajanBold, "盆地");
            panel.AddButton("Edge", GUIController.Instance.images["ButtonRect"], new Vector2(846f, 0f), Vector2.zero, EdgeClicked, buttonRect, GUIController.Instance.trajanBold, "边境");
            panel.AddButton("Peak", GUIController.Instance.images["ButtonRect"], new Vector2(946f, 0f), Vector2.zero, PeakClicked, buttonRect, GUIController.Instance.trajanBold, "矿山");
            panel.AddButton("Grounds", GUIController.Instance.images["ButtonRect"], new Vector2(1046f, 0f), Vector2.zero, GroundsClicked, buttonRect, GUIController.Instance.trajanBold, "安息");
            panel.AddButton("Gardens", GUIController.Instance.images["ButtonRect"], new Vector2(1146f, 0f), Vector2.zero, GardensClicked, buttonRect, GUIController.Instance.trajanBold, "花园");
            panel.AddButton("Palace", GUIController.Instance.images["ButtonRect"], new Vector2(1246f, 0f), Vector2.zero, PalaceClicked, buttonRect, GUIController.Instance.trajanBold, "宫殿");
            panel.AddButton("Tram", GUIController.Instance.images["ButtonRect"], new Vector2(1346f, 0f), Vector2.zero, TramClicked, buttonRect, GUIController.Instance.trajanBold, "电车");

            //Dropdown panels
            panel.AddPanel("Cliffs Panel", GUIController.Instance.images["DropdownBG"], new Vector2(-55f, 20f), Vector2.zero, new Rect(0, 0, GUIController.Instance.images["DropdownBG"].width, 270f));
            panel.AddPanel("Crossroads Panel", GUIController.Instance.images["DropdownBG"], new Vector2(45f, 20f), Vector2.zero, new Rect(0, 0, GUIController.Instance.images["DropdownBG"].width, 270f));
            panel.AddPanel("Greenpath Panel", GUIController.Instance.images["DropdownBG"], new Vector2(145f, 20f), Vector2.zero, new Rect(0, 0, GUIController.Instance.images["DropdownBG"].width, 270f));
            panel.AddPanel("Canyon Panel", GUIController.Instance.images["DropdownBG"], new Vector2(245f, 20f), Vector2.zero, new Rect(0, 0, GUIController.Instance.images["DropdownBG"].width, 270f));
            panel.AddPanel("Wastes Panel", GUIController.Instance.images["DropdownBG"], new Vector2(345f, 20f), Vector2.zero, new Rect(0, 0, GUIController.Instance.images["DropdownBG"].width, 270f));
            panel.AddPanel("City Panel", GUIController.Instance.images["DropdownBG"], new Vector2(445f, 20f), Vector2.zero, new Rect(0, 0, GUIController.Instance.images["DropdownBG"].width, 270f));
            panel.AddPanel("Waterways Panel", GUIController.Instance.images["DropdownBG"], new Vector2(545f, 20f), Vector2.zero, new Rect(0, 0, GUIController.Instance.images["DropdownBG"].width, 270f));
            panel.AddPanel("Deepnest Panel", GUIController.Instance.images["DropdownBG"], new Vector2(645f, 20f), Vector2.zero, new Rect(0, 0, GUIController.Instance.images["DropdownBG"].width, 270f));
            panel.AddPanel("Basin Panel", GUIController.Instance.images["DropdownBG"], new Vector2(745f, 20f), Vector2.zero, new Rect(0, 0, GUIController.Instance.images["DropdownBG"].width, 270f));
            panel.AddPanel("Edge Panel", GUIController.Instance.images["DropdownBG"], new Vector2(845f, 20f), Vector2.zero, new Rect(0, 0, GUIController.Instance.images["DropdownBG"].width, 270f));
            panel.AddPanel("Peak Panel", GUIController.Instance.images["DropdownBG"], new Vector2(945f, 20f), Vector2.zero, new Rect(0, 0, GUIController.Instance.images["DropdownBG"].width, 270f));
            panel.AddPanel("Grounds Panel", GUIController.Instance.images["DropdownBG"], new Vector2(1045f, 20f), Vector2.zero, new Rect(0, 0, GUIController.Instance.images["DropdownBG"].width, 270f));
            panel.AddPanel("Gardens Panel", GUIController.Instance.images["DropdownBG"], new Vector2(1145f, 20f), Vector2.zero, new Rect(0, 0, GUIController.Instance.images["DropdownBG"].width, 270f));
            panel.AddPanel("Palace Panel", GUIController.Instance.images["DropdownBG"], new Vector2(1245f, 20f), Vector2.zero, new Rect(0, 0, GUIController.Instance.images["DropdownBG"].width, 270f));
            panel.AddPanel("Tram Panel", GUIController.Instance.images["DropdownBG"], new Vector2(1345f, 20f), Vector2.zero, new Rect(0, 0, GUIController.Instance.images["DropdownBG"].width, 270f));

            //Cheats panel
            panel.GetPanel("Cliffs Panel").AddButton("KingsPass", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 25f), Vector2.zero, KingsPassClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "国王山道", fontSize);
            panel.GetPanel("Cliffs Panel").AddButton("Dirtmouth", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 65f), Vector2.zero, DirtmouthClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "德特茅斯", fontSize);
            panel.GetPanel("Cliffs Panel").AddButton("Mato", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 105f), Vector2.zero, MatoClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "马托", fontSize);
            
            //Crossroads panel
            panel.GetPanel("Crossroads Panel").AddButton("XRHotSprings", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 25f), Vector2.zero, XRHotSpringsClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "温泉", fontSize);
            panel.GetPanel("Crossroads Panel").AddButton("XRStag", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 65f), Vector2.zero, XRStagClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "车站", fontSize);
            panel.GetPanel("Crossroads Panel").AddButton("Salubra", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 105f), Vector2.zero, SalubraClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "红唇", fontSize);
            panel.GetPanel("Crossroads Panel").AddButton("AncestralMound", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 145f), Vector2.zero, AncestralMoundClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "祖先山丘", fontSize);
            panel.GetPanel("Crossroads Panel").AddButton("BlackEggTemple", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 185f), Vector2.zero, BlackEggTempleClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "黑卵圣殿", fontSize);

            //Greenpath panel
            panel.GetPanel("Greenpath Panel").AddButton("Waterfall", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 25f), Vector2.zero, WaterfallClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "瀑布", fontSize);
            panel.GetPanel("Greenpath Panel").AddButton("StoneSanctuary", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 65f), Vector2.zero, StoneSanctuaryClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "庇护所", fontSize);
            panel.GetPanel("Greenpath Panel").AddButton("GPToll", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 105f), Vector2.zero, GPTollClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "收费机", fontSize);
            panel.GetPanel("Greenpath Panel").AddButton("GPStag", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 145f), Vector2.zero, GPStagClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "车站", fontSize);
            panel.GetPanel("Greenpath Panel").AddButton("LakeofUnn", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 185f), Vector2.zero, LakeofUnnClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "乌恩", fontSize);
            panel.GetPanel("Greenpath Panel").AddButton("Sheo", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 225f), Vector2.zero, SheoClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "席奥", fontSize);

            //Canyon panel
            panel.GetPanel("Canyon Panel").AddButton("Archives", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 25f), Vector2.zero, TeachersArchivesClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "档案馆", fontSize);

            //Wastes panel
            panel.GetPanel("Wastes Panel").AddButton("QueensStation", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 25f), Vector2.zero, QueensStationClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "王后驿站", fontSize);
            panel.GetPanel("Wastes Panel").AddButton("LegEater", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 65f), Vector2.zero, LegEaterClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "食腿者", fontSize);
            panel.GetPanel("Wastes Panel").AddButton("Bretta", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 105f), Vector2.zero, BrettaClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "迷妹", fontSize);
            panel.GetPanel("Wastes Panel").AddButton("MantisVillage", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 145f), Vector2.zero, MantisVillageClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "螳螂村", fontSize);

            //City panel
            panel.GetPanel("City Panel").AddButton("Quirrel", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 25f), Vector2.zero, QuirrelClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "奎若", fontSize);
            panel.GetPanel("City Panel").AddButton("CoTToll", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 65f), Vector2.zero, CoTTollClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "收费机", fontSize);
            panel.GetPanel("City Panel").AddButton("CityStorerooms", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 105f), Vector2.zero, CityStoreroomsClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "城市仓库", fontSize);
            panel.GetPanel("City Panel").AddButton("WatchersSpire", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 145f), Vector2.zero, WatchersSpireClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "守望者高塔", fontSize);
            panel.GetPanel("City Panel").AddButton("KingsStation", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 185f), Vector2.zero, KingsStationClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "国王驿站", fontSize);
            panel.GetPanel("City Panel").AddButton("PleasureHouse", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 225f), Vector2.zero, PleasureHouseClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "欢乐之屋", fontSize);

            //Waterways panel
            panel.GetPanel("Waterways Panel").AddButton("Waterways", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 25f), Vector2.zero, WaterwaysClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "下水道", fontSize);
            panel.GetPanel("Waterways Panel").AddButton("Godhome", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 65f), Vector2.zero, GodhomeClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "神居", fontSize);
            panel.GetPanel("Waterways Panel").AddButton("HallofGods", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 105f), Vector2.zero, HallofGodsClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "手办屋", fontSize);

            //Deepnest panel
            panel.GetPanel("Deepnest Panel").AddButton("DNHotSprings", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 25f), Vector2.zero, DNHotSpringsClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "温泉", fontSize);
            panel.GetPanel("Deepnest Panel").AddButton("FailedTramway", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 65f), Vector2.zero, FailedTramwayClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "废弃车站", fontSize);
            panel.GetPanel("Deepnest Panel").AddButton("BeastsDen", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 105f), Vector2.zero, BeastsDenClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "野兽巢穴", fontSize);

            //Basin panel
            panel.GetPanel("Basin Panel").AddButton("ABToll", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 25f), Vector2.zero, ABTollClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "收费机", fontSize);
            panel.GetPanel("Basin Panel").AddButton("ABStag", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 65f), Vector2.zero, ABStagClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "车站", fontSize);

            //Edge panel
            panel.GetPanel("Edge Panel").AddButton("Oro", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 25f), Vector2.zero, OroClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "奥罗", fontSize);
            panel.GetPanel("Edge Panel").AddButton("Camp", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 65f), Vector2.zero, CampClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "营地", fontSize);
            panel.GetPanel("Edge Panel").AddButton("Colosseum", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 105f), Vector2.zero, ColosseumClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "愚人竞技场", fontSize);
            panel.GetPanel("Edge Panel").AddButton("Hive", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 145f), Vector2.zero, HiveClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "蜂巢", fontSize);

            //Peak panel
            panel.GetPanel("Peak Panel").AddButton("DarkRoom", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 25f), Vector2.zero, DarkRoomClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "暗室", fontSize);
            panel.GetPanel("Peak Panel").AddButton("CrystalGuardian", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 65f), Vector2.zero, CrystalGuardianClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "水晶守卫", fontSize);

            //Grounds panel
            panel.GetPanel("Grounds Panel").AddButton("RGStag", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 25f), Vector2.zero, RGStagClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "车站", fontSize);
            panel.GetPanel("Grounds Panel").AddButton("GreyMourner", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 65f), Vector2.zero, GreyMournerClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "灰色哀悼者", fontSize);

            //Gardens panel
            panel.GetPanel("Gardens Panel").AddButton("QGCornifer", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 25f), Vector2.zero, QGCorniferClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "绘图师", fontSize);
            panel.GetPanel("Gardens Panel").AddButton("QGToll", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 65f), Vector2.zero, QGTollClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "收费机", fontSize);
            panel.GetPanel("Gardens Panel").AddButton("QGStag", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 105f), Vector2.zero, QGStagClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "车站", fontSize);

            //Palace panel
            panel.GetPanel("Palace Panel").AddButton("WPEntrance", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 25f), Vector2.zero, WPEntranceClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "入口", fontSize);
            panel.GetPanel("Palace Panel").AddButton("WPAtrium", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 65f), Vector2.zero, WPAtriumClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "中庭", fontSize);
            panel.GetPanel("Palace Panel").AddButton("WPBalcony", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 105f), Vector2.zero, WPBalconyClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "阳台", fontSize);

            //Tram panel
            panel.GetPanel("Tram Panel").AddButton("UpperTram", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 25f), Vector2.zero, UpperTramClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "上电车", fontSize);
            panel.GetPanel("Tram Panel").AddButton("LowerTram", GUIController.Instance.images["ButtonRectEmpty"], new Vector2(5f, 65f), Vector2.zero, LowerTramClicked, new Rect(0f, 0f, 80f, 40f), GUIController.Instance.trajanNormal, "下电车", fontSize);

            panel.FixRenderOrder();
        }

        public static void Update()
        {
            if (panel == null || sceneNamePanel == null)
            {
                return;
            }

            if (Benchwarp.instance.GlobalSettings.ShowScene)
            {
                sceneNamePanel.SetActive(true, false);
                sceneNamePanel.GetText("SceneName").UpdateText(GameManager.instance.sceneName);
            }
            else sceneNamePanel.SetActive(false, true);

            if (GameManager.instance.IsGamePaused())
            {
                panel.SetActive(true, false);
            }
            else if (!GameManager.instance.IsGamePaused())
            {
                panel.SetActive(false, true);
            }

            if (panel.GetPanel("Settings Panel").active)
            {
                panel.GetButton("WarpOnly", "Settings Panel").SetTextColor(Benchwarp.instance.GlobalSettings.WarpOnly ? Color.yellow : Color.white);
                panel.GetButton("UnlockAll", "Settings Panel").SetTextColor(Benchwarp.instance.GlobalSettings.UnlockAllBenches ? Color.yellow : Color.white);
                panel.GetButton("ShowScene", "Settings Panel").SetTextColor(Benchwarp.instance.GlobalSettings.ShowScene ? Color.yellow : Color.white);
            }

            if (panel.GetPanel("Cliffs Panel").active)
            {
                panel.GetButton("KingsPass", "Cliffs Panel").SetTextColor(PlayerData.instance.respawnScene == "Tutorial_01" ? Color.yellow : Color.white);

                if (!Benchwarp.instance.Settings.hasVisitedDirtmouth && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("Dirtmouth", "Cliffs Panel").SetTextColor(Color.red);
                else panel.GetButton("Dirtmouth", "Cliffs Panel").SetTextColor(PlayerData.instance.respawnScene == "Town" ? Color.yellow : Color.white);

                if (!Benchwarp.instance.Settings.hasVisitedMato && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("Mato", "Cliffs Panel").SetTextColor(Color.red);
                else panel.GetButton("Mato", "Cliffs Panel").SetTextColor(PlayerData.instance.respawnScene == "Room_nailmaster" ? Color.yellow : Color.white);
            }

            if (panel.GetPanel("Crossroads Panel").active)
            {
                if (!Benchwarp.instance.Settings.hasVisitedXRHotSprings && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("XRHotSprings", "Crossroads Panel").SetTextColor(Color.red);
                else panel.GetButton("XRHotSprings", "Crossroads Panel").SetTextColor(PlayerData.instance.respawnScene == "Crossroads_30" ? Color.yellow : Color.white);

                if (!Benchwarp.instance.Settings.hasVisitedXRStag && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("XRStag", "Crossroads Panel").SetTextColor(Color.red);
                else panel.GetButton("XRStag", "Crossroads Panel").SetTextColor(PlayerData.instance.respawnScene == "Crossroads_47" ? Color.yellow : Color.white);

                if (!Benchwarp.instance.Settings.hasVisitedSalubra && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("Salubra", "Crossroads Panel").SetTextColor(Color.red);
                else panel.GetButton("Salubra", "Crossroads Panel").SetTextColor(PlayerData.instance.respawnScene == "Crossroads_04" ? Color.yellow : Color.white);

                if (!Benchwarp.instance.Settings.hasVisitedAncestralMound && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("AncestralMound", "Crossroads Panel").SetTextColor(Color.red);
                else panel.GetButton("AncestralMound", "Crossroads Panel").SetTextColor(PlayerData.instance.respawnScene == "Crossroads_ShamanTemple" ? Color.yellow : Color.white);

                if (!Benchwarp.instance.Settings.hasVisitedBlackEggTemple && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("BlackEggTemple", "Crossroads Panel").SetTextColor(Color.red);
                else panel.GetButton("BlackEggTemple", "Crossroads Panel").SetTextColor(PlayerData.instance.respawnScene == "Room_Final_Boss_Atrium" ? Color.yellow : Color.white);
            }

            if (panel.GetPanel("Greenpath Panel").active)
            {
                if (!Benchwarp.instance.Settings.hasVisitedWaterfall && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("Waterfall", "Greenpath Panel").SetTextColor(Color.red);
                else panel.GetButton("Waterfall", "Greenpath Panel").SetTextColor(PlayerData.instance.respawnScene == "Fungus1_01b" ? Color.yellow : Color.white);

                if (!Benchwarp.instance.Settings.hasVisitedStoneSanctuary && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("StoneSanctuary", "Greenpath Panel").SetTextColor(Color.red);
                else panel.GetButton("StoneSanctuary", "Greenpath Panel").SetTextColor(PlayerData.instance.respawnScene == "Fungus1_37" ? Color.yellow : Color.white);

                if (!Benchwarp.instance.Settings.hasVisitedGPToll && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("GPToll", "Greenpath Panel").SetTextColor(Color.red);
                else panel.GetButton("GPToll", "Greenpath Panel").SetTextColor(PlayerData.instance.respawnScene == "Fungus1_31" ? Color.yellow : Color.white);

                if (!Benchwarp.instance.Settings.hasVisitedGPStag && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("GPStag", "Greenpath Panel").SetTextColor(Color.red);
                else panel.GetButton("GPStag", "Greenpath Panel").SetTextColor(PlayerData.instance.respawnScene == "Fungus1_16_alt" ? Color.yellow : Color.white);

                if (!Benchwarp.instance.Settings.hasVisitedLakeofUnn && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("LakeofUnn", "Greenpath Panel").SetTextColor(Color.red);
                else panel.GetButton("LakeofUnn", "Greenpath Panel").SetTextColor(PlayerData.instance.respawnScene == "Room_Slug_Shrine" ? Color.yellow : Color.white);

                if (!Benchwarp.instance.Settings.hasVisitedSheo && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("Sheo", "Greenpath Panel").SetTextColor(Color.red);
                else panel.GetButton("Sheo", "Greenpath Panel").SetTextColor(PlayerData.instance.respawnScene == "Fungus1_15" ? Color.yellow : Color.white);
            }

            if (panel.GetPanel("Canyon Panel").active)
            {
                if (!Benchwarp.instance.Settings.hasVisitedTeachersArchives && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("Archives", "Canyon Panel").SetTextColor(Color.red);
                else panel.GetButton("Archives", "Canyon Panel").SetTextColor(PlayerData.instance.respawnScene == "Fungus3_archive" ? Color.yellow : Color.white);
            }

            if (panel.GetPanel("Wastes Panel").active)
            {
                if (!Benchwarp.instance.Settings.hasVisitedQueensStation && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("QueensStation", "Wastes Panel").SetTextColor(Color.red);
                else panel.GetButton("QueensStation", "Wastes Panel").SetTextColor(PlayerData.instance.respawnScene == "Fungus2_02" ? Color.yellow : Color.white);

                if (!Benchwarp.instance.Settings.hasVisitedLegEater && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("LegEater", "Wastes Panel").SetTextColor(Color.red);
                else panel.GetButton("LegEater", "Wastes Panel").SetTextColor(PlayerData.instance.respawnScene == "Fungus2_26" ? Color.yellow : Color.white);

                if (!Benchwarp.instance.Settings.hasVisitedBretta && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("Bretta", "Wastes Panel").SetTextColor(Color.red);
                else panel.GetButton("Bretta", "Wastes Panel").SetTextColor(PlayerData.instance.respawnScene == "Fungus2_13" ? Color.yellow : Color.white);

                if (!Benchwarp.instance.Settings.hasVisitedMantisVillage && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("MantisVillage", "Wastes Panel").SetTextColor(Color.red);
                else panel.GetButton("MantisVillage", "Wastes Panel").SetTextColor(PlayerData.instance.respawnScene == "Fungus2_31" ? Color.yellow : Color.white);
            }

            if (panel.GetPanel("City Panel").active)
            {
                if (!Benchwarp.instance.Settings.hasVisitedQuirrel && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("Quirrel", "City Panel").SetTextColor(Color.red);
                else panel.GetButton("Quirrel", "City Panel").SetTextColor(PlayerData.instance.respawnScene == "Ruins1_02" ? Color.yellow : Color.white);

                if (!Benchwarp.instance.Settings.hasVisitedCoTToll && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("CoTToll", "City Panel").SetTextColor(Color.red);
                else panel.GetButton("CoTToll", "City Panel").SetTextColor(PlayerData.instance.respawnScene == "Ruins1_31" ? Color.yellow : Color.white);

                if (!Benchwarp.instance.Settings.hasVisitedCityStorerooms && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("CityStorerooms", "City Panel").SetTextColor(Color.red);
                else panel.GetButton("CityStorerooms", "City Panel").SetTextColor(PlayerData.instance.respawnScene == "Ruins1_29" ? Color.yellow : Color.white);

                if (!Benchwarp.instance.Settings.hasVisitedWatchersSpire && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("WatchersSpire", "City Panel").SetTextColor(Color.red);
                else panel.GetButton("WatchersSpire", "City Panel").SetTextColor(PlayerData.instance.respawnScene == "Ruins1_18" ? Color.yellow : Color.white);

                if (!Benchwarp.instance.Settings.hasVisitedKingsStation && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("KingsStation", "City Panel").SetTextColor(Color.red);
                else panel.GetButton("KingsStation", "City Panel").SetTextColor(PlayerData.instance.respawnScene == "Ruins2_08" ? Color.yellow : Color.white);

                if (!Benchwarp.instance.Settings.hasVisitedPleasureHouse && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("PleasureHouse", "City Panel").SetTextColor(Color.red);
                else panel.GetButton("PleasureHouse", "City Panel").SetTextColor(PlayerData.instance.respawnScene == "Ruins_Bathhouse" ? Color.yellow : Color.white);
            }

            if (panel.GetPanel("Waterways Panel").active)
            {
                if (!Benchwarp.instance.Settings.hasVisitedWaterways && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("Waterways", "Waterways Panel").SetTextColor(Color.red);
                else panel.GetButton("Waterways", "Waterways Panel").SetTextColor(PlayerData.instance.respawnScene == "Waterways_02" ? Color.yellow : Color.white);

                if (!Benchwarp.instance.Settings.hasVisitedGodhome && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("Godhome", "Waterways Panel").SetTextColor(Color.red);
                else panel.GetButton("Godhome", "Waterways Panel").SetTextColor(PlayerData.instance.respawnScene == "GG_Atrium" ? Color.yellow : Color.white);

                if (!Benchwarp.instance.Settings.hasVisitedHallofGods && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("HallofGods", "Waterways Panel").SetTextColor(Color.red);
                else panel.GetButton("HallofGods", "Waterways Panel").SetTextColor(PlayerData.instance.respawnScene == "GG_Workshop" ? Color.yellow : Color.white);
            }

            if (panel.GetPanel("Deepnest Panel").active)
            {
                if (!Benchwarp.instance.Settings.hasVisitedDNHotSprings && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("DNHotSprings", "Deepnest Panel").SetTextColor(Color.red);
                else panel.GetButton("DNHotSprings", "Deepnest Panel").SetTextColor(PlayerData.instance.respawnScene == "Deepnest_30" ? Color.yellow : Color.white);

                if (!Benchwarp.instance.Settings.hasVisitedFailedTramway && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("FailedTramway", "Deepnest Panel").SetTextColor(Color.red);
                else panel.GetButton("FailedTramway", "Deepnest Panel").SetTextColor(PlayerData.instance.respawnScene == "Deepnest_14" ? Color.yellow : Color.white);

                if (!Benchwarp.instance.Settings.hasVisitedBeastsDen && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("BeastsDen", "Deepnest Panel").SetTextColor(Color.red);
                else panel.GetButton("BeastsDen", "Deepnest Panel").SetTextColor(PlayerData.instance.respawnScene == "Deepnest_Spider_Town" ? Color.yellow : Color.white);
            }

            if (panel.GetPanel("Basin Panel").active)
            {
                if (!Benchwarp.instance.Settings.hasVisitedABToll && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("ABToll", "Basin Panel").SetTextColor(Color.red);
                else panel.GetButton("ABToll", "Basin Panel").SetTextColor(PlayerData.instance.respawnScene == "Abyss_18" ? Color.yellow : Color.white);

                if (!Benchwarp.instance.Settings.hasVisitedABStag && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("ABStag", "Basin Panel").SetTextColor(Color.red);
                else panel.GetButton("ABStag", "Basin Panel").SetTextColor(PlayerData.instance.respawnScene == "Abyss_22" ? Color.yellow : Color.white);
            }

            if (panel.GetPanel("Edge Panel").active)
            {
                if (!Benchwarp.instance.Settings.hasVisitedOro && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("Oro", "Edge Panel").SetTextColor(Color.red);
                else panel.GetButton("Oro", "Edge Panel").SetTextColor(PlayerData.instance.respawnScene == "Deepnest_East_06" ? Color.yellow : Color.white);

                if (!Benchwarp.instance.Settings.hasVisitedCamp && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("Camp", "Edge Panel").SetTextColor(Color.red);
                else panel.GetButton("Camp", "Edge Panel").SetTextColor(PlayerData.instance.respawnScene == "Deepnest_East_13" ? Color.yellow : Color.white);

                if (!Benchwarp.instance.Settings.hasVisitedColosseum && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("Colosseum", "Edge Panel").SetTextColor(Color.red);
                else panel.GetButton("Colosseum", "Edge Panel").SetTextColor(PlayerData.instance.respawnScene == "Room_Colosseum_02" ? Color.yellow : Color.white);

                if (!Benchwarp.instance.Settings.hasVisitedHive && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("Hive", "Edge Panel").SetTextColor(Color.red);
                else panel.GetButton("Hive", "Edge Panel").SetTextColor(PlayerData.instance.respawnScene == "Hive_01" ? Color.yellow : Color.white);
            }

            if (panel.GetPanel("Peak Panel").active)
            {
                if (!Benchwarp.instance.Settings.hasVisitedDarkRoom && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("DarkRoom", "Peak Panel").SetTextColor(Color.red);
                else panel.GetButton("DarkRoom", "Peak Panel").SetTextColor(PlayerData.instance.respawnScene == "Mines_29" ? Color.yellow : Color.white);

                if (!Benchwarp.instance.Settings.hasVisitedCrystalGuardian && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("CrystalGuardian", "Peak Panel").SetTextColor(Color.red);
                else panel.GetButton("CrystalGuardian", "Peak Panel").SetTextColor(PlayerData.instance.respawnScene == "Mines_18" ? Color.yellow : Color.white);
            }

            if (panel.GetPanel("Grounds Panel").active)
            {
                if (!Benchwarp.instance.Settings.hasVisitedRGStag && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("RGStag", "Grounds Panel").SetTextColor(Color.red);
                else panel.GetButton("RGStag", "Grounds Panel").SetTextColor(PlayerData.instance.respawnScene == "RestingGrounds_09" ? Color.yellow : Color.white);

                if (!Benchwarp.instance.Settings.hasVisitedGreyMourner && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("GreyMourner", "Grounds Panel").SetTextColor(Color.red);
                else panel.GetButton("GreyMourner", "Grounds Panel").SetTextColor(PlayerData.instance.respawnScene == "RestingGrounds_12" ? Color.yellow : Color.white);
            }

            if (panel.GetPanel("Gardens Panel").active)
            {
                if (!Benchwarp.instance.Settings.hasVisitedQGCornifer && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("QGCornifer", "Gardens Panel").SetTextColor(Color.red);
                else panel.GetButton("QGCornifer", "Gardens Panel").SetTextColor(PlayerData.instance.respawnScene == "Fungus1_24" ? Color.yellow : Color.white);

                if (!Benchwarp.instance.Settings.hasVisitedQGToll && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("QGToll", "Gardens Panel").SetTextColor(Color.red);
                else panel.GetButton("QGToll", "Gardens Panel").SetTextColor(PlayerData.instance.respawnScene == "Fungus3_50" ? Color.yellow : Color.white);

                if (!Benchwarp.instance.Settings.hasVisitedQGStag && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("QGStag", "Gardens Panel").SetTextColor(Color.red);
                else panel.GetButton("QGStag", "Gardens Panel").SetTextColor(PlayerData.instance.respawnScene == "Fungus3_40" ? Color.yellow : Color.white);
            }

            if (panel.GetPanel("Palace Panel").active)
            {
                if (!Benchwarp.instance.Settings.hasVisitedWPEntrance && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("WPEntrance", "Palace Panel").SetTextColor(Color.red);
                else panel.GetButton("WPEntrance", "Palace Panel").SetTextColor(PlayerData.instance.respawnScene == "White_Palace_01" ? Color.yellow : Color.white);

                if (!Benchwarp.instance.Settings.hasVisitedWPAtrium && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("WPAtrium", "Palace Panel").SetTextColor(Color.red);
                else panel.GetButton("WPAtrium", "Palace Panel").SetTextColor(PlayerData.instance.respawnScene == "White_Palace_03_hub" ? Color.yellow : Color.white);

                if (!Benchwarp.instance.Settings.hasVisitedWPBalcony && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("WPBalcony", "Palace Panel").SetTextColor(Color.red);
                else panel.GetButton("WPBalcony", "Palace Panel").SetTextColor(PlayerData.instance.respawnScene == "White_Palace_06" ? Color.yellow : Color.white);
            }

            if (panel.GetPanel("Tram Panel").active)
            {
                if (!Benchwarp.instance.Settings.hasVisitedUpperTram && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("UpperTram", "Tram Panel").SetTextColor(Color.red);
                else panel.GetButton("UpperTram", "Tram Panel").SetTextColor(PlayerData.instance.respawnScene == "Room_Tram_RG" ? Color.yellow : Color.white);

                if (!Benchwarp.instance.Settings.hasVisitedLowerTram && !Benchwarp.instance.GlobalSettings.UnlockAllBenches) panel.GetButton("LowerTram", "Tram Panel").SetTextColor(Color.red);
                else panel.GetButton("LowerTram", "Tram Panel").SetTextColor(PlayerData.instance.respawnScene == "Room_Tram" ? Color.yellow : Color.white);
            }
           }




        private static void WarpClicked(string buttonName)
        {
            if (Benchwarp.instance.GlobalSettings.UnlockAllBenches) UnlockAllClicked(buttonName); // makes various pd changes if necessary

            GameManager.instance.StartCoroutine(Benchwarp.instance.Respawn());
        }

        #region Settings button method
        private static void WarpOnlyClicked(string buttonName)
        {
            Benchwarp.instance.GlobalSettings.WarpOnly = !Benchwarp.instance.GlobalSettings.WarpOnly;
            Benchwarp.instance.SaveGlobalSettings();
            panel.Destroy();
            sceneNamePanel.Destroy();
            BuildMenu(canvas);
        }

        private static void UnlockAllClicked(string buttonName)
        {
            if (buttonName != "Warp")
            {
                Benchwarp.instance.GlobalSettings.UnlockAllBenches = !Benchwarp.instance.GlobalSettings.UnlockAllBenches;
                Benchwarp.instance.SaveGlobalSettings();
            }
            
            if (Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData pd = PlayerData.instance;

                //Most of these are unnecessary, but some titlecards can lock you into a bench
                pd.SetBoolInternal("visitedAbyss", true);
                pd.SetBoolInternal("visitedAbyssLower", true);
                pd.SetBoolInternal("visitedCliffs", true);
                pd.SetBoolInternal("visitedCrossroads", true);
                pd.SetBoolInternal("visitedDeepnest", true);
                pd.SetBoolInternal("visitedDirtmouth", true);
                pd.SetBoolInternal("visitedGreenpath", true);
                pd.SetBoolInternal("visitedFogCanyon", true);
                pd.SetBoolInternal("visitedFungus", true);
                pd.SetBoolInternal("visitedHive", true);
                pd.SetBoolInternal("visitedGodhome", true);
                pd.SetBoolInternal("visitedMines", true);
                pd.SetBoolInternal("visitedOutskirts", true);
                pd.SetBoolInternal("visitedRestingGrounds", true);
                pd.SetBoolInternal("visitedRoyalGardens", true);
                pd.SetBoolInternal("visitedRestingGrounds", true);
                pd.SetBoolInternal("visitedRuins", true);
                pd.SetBoolInternal("visitedWaterways", true);
                pd.SetBoolInternal("visitedWhitePalace", true);

                // Only two of these do anything
                pd.SetBoolInternal("tramOpenedCrossroads", true);
                pd.SetBoolInternal("openedTramRestingGrounds", true);
                pd.SetBoolInternal("tramOpenedDeepnest", true);
                pd.SetBoolInternal("openedTramLower", true);
                pd.SetBoolInternal("tollBenchAbyss", true);
                pd.SetBoolInternal("tollBenchCity", true);
                pd.SetBoolInternal("tollBenchQueensGardens", true);

                //This actually fixes the unlockable benches
                SceneData sd = GameManager.instance.sceneData;
                sd.SaveMyState(new PersistentBoolData
                {
                    sceneName = "Hive_01",
                    id = "Hive Bench",
                    activated = true,
                    semiPersistent = false
                });
                sd.SaveMyState(new PersistentBoolData
                {
                    sceneName = "Ruins1_31",
                    id = "Toll Machine Bench",
                    activated = true,
                    semiPersistent = false
                });
                sd.SaveMyState(new PersistentBoolData
                {
                    sceneName = "Abyss_18",
                    id = "Toll Machine Bench",
                    activated = true,
                    semiPersistent = false
                });
                sd.SaveMyState(new PersistentBoolData
                {
                    sceneName = "Fungus3_50",
                    id = "Toll Machine Bench",
                    activated = true,
                    semiPersistent = false
                });
            }
        }

        private static void ShowSceneClicked(string buttonName)
        {
            Benchwarp.instance.GlobalSettings.ShowScene = !Benchwarp.instance.GlobalSettings.ShowScene;
            Benchwarp.instance.SaveGlobalSettings();
        }

        #endregion

        #region Dropdown toggle methods
        private static void AllClicked(string buttonName)
        {
            panel.TogglePanel("Cliffs Panel");
            panel.TogglePanel("Crossroads Panel");
            panel.TogglePanel("Greenpath Panel");
            panel.TogglePanel("Canyon Panel");
            panel.TogglePanel("Wastes Panel");
            panel.TogglePanel("City Panel");
            panel.TogglePanel("Waterways Panel");
            panel.TogglePanel("Deepnest Panel");
            panel.TogglePanel("Basin Panel");
            panel.TogglePanel("Edge Panel");
            panel.TogglePanel("Peak Panel");
            panel.TogglePanel("Grounds Panel");
            panel.TogglePanel("Gardens Panel");
            panel.TogglePanel("Palace Panel");
            panel.TogglePanel("Tram Panel");
        }

        private static void CliffsClicked(string buttonName)
        {
            panel.TogglePanel("Cliffs Panel");
        }

        private static void CrossroadsClicked(string buttonName)
        {
            panel.TogglePanel("Crossroads Panel");
        }

        private static void GreenpathClicked(string buttonName)
        {
            panel.TogglePanel("Greenpath Panel");
        }
        private static void CanyonClicked(string buttonName)
        {
            panel.TogglePanel("Canyon Panel");
        }
        private static void WastesClicked(string buttonName)
        {
            panel.TogglePanel("Wastes Panel");
        }
        private static void CityClicked(string buttonName)
        {
            panel.TogglePanel("City Panel");
        }
        private static void DeepnestClicked(string buttonName)
        {
            panel.TogglePanel("Deepnest Panel");
        }
        private static void RoyalWaterwaysClicked(string buttonName)
        {
            panel.TogglePanel("Waterways Panel");
        }
        private static void BasinClicked(string buttonName)
        {
            panel.TogglePanel("Basin Panel");
        }
        private static void EdgeClicked(string buttonName)
        {
            panel.TogglePanel("Edge Panel");
        }
        private static void PeakClicked(string buttonName)
        {
            panel.TogglePanel("Peak Panel");
        }
        private static void GroundsClicked(string buttonName)
        {
            panel.TogglePanel("Grounds Panel");
        }
        private static void GardensClicked(string buttonName)
        {
            panel.TogglePanel("Gardens Panel");
        }
        private static void PalaceClicked(string buttonName)
        {
            panel.TogglePanel("Palace Panel");
        }
        private static void TramClicked(string buttonName)
        {
            panel.TogglePanel("Tram Panel");
        }

        private static void SettingsClicked(string buttonName)
        {
            panel.TogglePanel("Settings Panel");
        }
        #endregion

        #region Bench button methods
        private static void KingsPassClicked(string buttonName)
        {
            PlayerData.instance.respawnScene = "Tutorial_01";
            PlayerData.instance.mapZone = (MapZone)2;
            PlayerData.instance.respawnType = 0;
            PlayerData.instance.respawnMarkerName = "Death Respawn Marker";
        }

        private static void DirtmouthClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedDirtmouth || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Town";
                PlayerData.instance.mapZone = (MapZone)4;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
            
        }

        private static void MatoClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedMato || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Room_nailmaster";
                PlayerData.instance.mapZone = (MapZone)3;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void XRHotSpringsClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedXRHotSprings || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Crossroads_30";
                PlayerData.instance.mapZone = (MapZone)5;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }

        private static void XRStagClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedXRStag || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Crossroads_47";
                PlayerData.instance.mapZone = (MapZone)5;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }

        private static void SalubraClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedSalubra || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Crossroads_04";
                PlayerData.instance.mapZone = (MapZone)5;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }

        private static void AncestralMoundClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedAncestralMound || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Crossroads_ShamanTemple";
                PlayerData.instance.mapZone = (MapZone)22;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "BoneBench";
            }
        }
        private static void BlackEggTempleClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedBlackEggTemple || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Room_Final_Boss_Atrium";
                PlayerData.instance.mapZone = (MapZone)30;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void WaterfallClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedWaterfall || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Fungus1_01b";
                PlayerData.instance.mapZone = (MapZone)6;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void StoneSanctuaryClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedStoneSanctuary || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Fungus1_37";
                PlayerData.instance.mapZone = (MapZone)6;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void GPTollClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedGPToll || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Fungus1_31";
                PlayerData.instance.mapZone = (MapZone)6;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void GPStagClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedGPStag || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Fungus1_16_alt";
                PlayerData.instance.mapZone = (MapZone)6;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void LakeofUnnClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedLakeofUnn || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Room_Slug_Shrine";
                PlayerData.instance.mapZone = (MapZone)6;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void SheoClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedSheo || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Fungus1_15";
                PlayerData.instance.mapZone = (MapZone)6;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void TeachersArchivesClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedTeachersArchives || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Fungus3_archive";
                PlayerData.instance.mapZone = (MapZone)34;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void QueensStationClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedQueensStation || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Fungus2_02";
                PlayerData.instance.mapZone = (MapZone)24;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void LegEaterClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedLegEater || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Fungus2_26";
                PlayerData.instance.mapZone = (MapZone)9;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void MantisVillageClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedMantisVillage || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Fungus2_31";
                PlayerData.instance.mapZone = (MapZone)9;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void BrettaClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedBretta || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Fungus2_13";
                PlayerData.instance.mapZone = (MapZone)9;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void QuirrelClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedQuirrel || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Ruins1_02";
                PlayerData.instance.mapZone = (MapZone)16;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void CoTTollClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedCoTToll || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Ruins1_31";
                PlayerData.instance.mapZone = (MapZone)16;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void CityStoreroomsClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedCityStorerooms || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Ruins1_29";
                PlayerData.instance.mapZone = (MapZone)16;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void WatchersSpireClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedWatchersSpire || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Ruins1_18";
                PlayerData.instance.mapZone = (MapZone)16;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void KingsStationClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedKingsStation || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Ruins2_08";
                PlayerData.instance.mapZone = (MapZone)16;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void PleasureHouseClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedPleasureHouse || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Ruins_Bathhouse";
                PlayerData.instance.mapZone = (MapZone)16;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void DNHotSpringsClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedDNHotSprings || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Deepnest_30";
                PlayerData.instance.mapZone = (MapZone)10;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void FailedTramwayClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedFailedTramway || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Deepnest_14";
                PlayerData.instance.mapZone = (MapZone)10;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void BeastsDenClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedBeastsDen || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Deepnest_Spider_Town";
                PlayerData.instance.mapZone = (MapZone)49;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench Return";
            }
        }
        private static void WaterwaysClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedWaterways || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Waterways_02";
                PlayerData.instance.mapZone = (MapZone)23;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void GodhomeClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedGodhome || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "GG_Atrium";
                PlayerData.instance.mapZone = (MapZone)50;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void HallofGodsClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedHallofGods || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "GG_Workshop";
                PlayerData.instance.mapZone = (MapZone)50;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench (1)";
            }
        }
        private static void DarkRoomClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedDarkRoom || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Mines_29";
                PlayerData.instance.mapZone = (MapZone)14;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void CrystalGuardianClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedCrystalGuardian || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Mines_18";
                PlayerData.instance.mapZone = (MapZone)14;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void ABTollClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedABToll || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Abyss_18";
                PlayerData.instance.mapZone = (MapZone)19;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void ABStagClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedABStag || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Abyss_22";
                PlayerData.instance.mapZone = (MapZone)19;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void WPEntranceClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedWPEntrance || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "White_Palace_01";
                PlayerData.instance.mapZone = (MapZone)21;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "WhiteBench";
            }
        }
        private static void WPAtriumClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedWPAtrium || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "White_Palace_03_hub";
                PlayerData.instance.mapZone = (MapZone)21;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "WhiteBench";
            }
        }
        private static void WPBalconyClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedWPBalcony || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "White_Palace_06";
                PlayerData.instance.mapZone = (MapZone)21;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void OroClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedOro || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Deepnest_East_06";
                PlayerData.instance.mapZone = (MapZone)25;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void CampClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedCamp || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Deepnest_East_13";
                PlayerData.instance.mapZone = (MapZone)25;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void ColosseumClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedColosseum || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Room_Colosseum_02";
                PlayerData.instance.mapZone = (MapZone)18;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void HiveClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedHive || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Hive_01";
                PlayerData.instance.mapZone = (MapZone)11;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void RGStagClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedRGStag || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "RestingGrounds_09";
                PlayerData.instance.mapZone = (MapZone)15;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void GreyMournerClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedGreyMourner || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "RestingGrounds_12";
                PlayerData.instance.mapZone = (MapZone)15;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void QGCorniferClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedQGCornifer || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Fungus1_24";
                PlayerData.instance.mapZone = (MapZone)7;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void QGTollClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedQGToll || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Fungus3_50";
                PlayerData.instance.mapZone = (MapZone)7;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void QGStagClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedQGStag || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Fungus3_40";
                PlayerData.instance.mapZone = (MapZone)7;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void UpperTramClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedUpperTram || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Room_Tram_RG";
                PlayerData.instance.mapZone = (MapZone)28;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        private static void LowerTramClicked(string buttonName)
        {
            if (Benchwarp.instance.Settings.hasVisitedLowerTram || Benchwarp.instance.GlobalSettings.UnlockAllBenches)
            {
                PlayerData.instance.respawnScene = "Room_Tram";
                PlayerData.instance.mapZone = (MapZone)29;
                PlayerData.instance.respawnType = 1;
                PlayerData.instance.respawnMarkerName = "RestBench";
            }
        }
        #endregion
    }
}
