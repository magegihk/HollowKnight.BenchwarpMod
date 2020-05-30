using GlobalEnums;
using System.Linq;

namespace Benchwarp
{
    public class Bench
    {
        public static Bench[] Benches = new Bench[]
            {
                new Bench("King's Pass", "Cliffs", "Tutorial_01", "国王山道", "呼啸", "Death Respawn Marker", 0, MapZone.KINGS_PASS),
                new Bench("Dirtmouth", "Cliffs", "Town", "德特茅斯", "呼啸", "RestBench", 1, MapZone.TOWN, true, "Left"),
                new Bench("Mato", "Cliffs", "Room_nailmaster", "马托", "呼啸", "RestBench", 1, MapZone.CLIFFS, true, "Mato"),

                new Bench("Hot Springs", "Crossroads", "Crossroads_30", "温泉", "十字路", "RestBench", 1, MapZone.CROSSROADS, true, "Right"),
                new Bench("Stag", "Crossroads", "Crossroads_47", "车站", "十字路", "RestBench", 1, MapZone.CROSSROADS),
                new Bench("Salubra", "Crossroads", "Crossroads_04", "红唇", "十字路", "RestBench", 1, MapZone.CROSSROADS, true, "Ornate"),
                new Bench("Ancestral Mound", "Crossroads", "Crossroads_ShamanTemple", "白波", "十字路", "BoneBench", 1, MapZone.SHAMAN_TEMPLE, true, "Bone"),
                new Bench("Black Egg Temple", "Crossroads", "Room_Final_Boss_Atrium", "黑卵", "十字路", "RestBench", 1, MapZone.FINAL_BOSS, true, "Black"),

                new Bench("Waterfall", "Greenpath", "Fungus1_01b", "瀑布", "苍绿", "RestBench", 1, MapZone.GREEN_PATH),
                new Bench("Stone Sanctuary", "Greenpath", "Fungus1_37", "庇护所", "苍绿", "RestBench", 1, MapZone.GREEN_PATH, true, "Stone"),
                new Bench("Toll", "Greenpath", "Fungus1_31", "收费机", "苍绿", "RestBench", 1, MapZone.GREEN_PATH),
                new Bench("Stag", "Greenpath", "Fungus1_16_alt", "车站", "苍绿", "RestBench", 1, MapZone.GREEN_PATH),
                new Bench("Lake of Unn", "Greenpath", "Room_Slug_Shrine", "乌恩", "苍绿", "RestBench", 1, MapZone.GREEN_PATH, true, "Shrine"),
                new Bench("Sheo", "Greenpath", "Fungus1_15", "席奥", "苍绿", "RestBench", 1, MapZone.GREEN_PATH, true, "Sheo"),

                new Bench("Archives", "Canyon", "Fungus3_archive", "档案馆", "雾谷", "RestBench", 1, MapZone.FOG_CANYON, true, "Archive"),

                new Bench("Queen's Station", "Wastes", "Fungus2_02", "王后驿站", "真菌", "RestBench", 1, MapZone.QUEENS_STATION),
                new Bench("Leg Eater", "Wastes", "Fungus2_26", "食腿者", "真菌", "RestBench", 1, MapZone.WASTES, true, "Corpse"),
                new Bench("Bretta", "Wastes", "Fungus2_13", "迷妹", "真菌", "RestBench", 1, MapZone.WASTES),
                new Bench("Mantis Village", "Wastes", "Fungus2_31", "螳螂村", "真菌", "RestBench", 1, MapZone.WASTES, true, "Mantis"),

                new Bench("Quirrel", "City", "Ruins1_02", "奎若", "泪城", "RestBench", 1, MapZone.CITY),
                new Bench("Toll", "City", "Ruins1_31", "收费机", "泪城", "RestBench", 1, MapZone.CITY),
                new Bench("City Storerooms", "City", "Ruins1_29", "城市仓库", "泪城", "RestBench", 1, MapZone.CITY),
                new Bench("Watcher's Spire", "City", "Ruins1_18", "守望者", "泪城", "RestBench", 1, MapZone.CITY),
                new Bench("King's Station", "City", "Ruins2_08", "国王驿站", "泪城", "RestBench", 1, MapZone.CITY),
                new Bench("Pleasure House", "City", "Ruins_Bathhouse", "温泉", "泪城", "RestBench", 1, MapZone.CITY, true, "Simple"),

                new Bench("Waterways", "Waterways", "Waterways_02", "下水道", "下水道", "RestBench", 1, MapZone.WATERWAYS, true, "Tilted"),
                new Bench("Godhome Atrium", "Waterways", "GG_Atrium", "神居", "下水道", "RestBench", 1, MapZone.GODS_GLORY, true, "Wide"),
                new Bench("Godhome Roof", "Waterways", "GG_Atrium_Roof", "神居屋顶", "下水道", "RestBench (1)", 1, MapZone.GODS_GLORY),
                new Bench("Hall of Gods", "Waterways", "GG_Workshop", "手办屋", "下水道", "RestBench (1)", 1, MapZone.GODS_GLORY),

                new Bench("Hot Springs", "Deepnest", "Deepnest_30", "温泉", "深巢", "RestBench", 1, MapZone.DEEPNEST),
                new Bench("Failed Tramway", "Deepnest", "Deepnest_14", "废弃车站", "深巢", "RestBench", 1, MapZone.DEEPNEST),
                new Bench("Beast's Den", "Deepnest", "Deepnest_Spider_Town", "野兽巢穴", "深巢", "RestBench Return", 1, MapZone.BEASTS_DEN, true, "Beast"),

                new Bench("Toll", "Basin", "Abyss_18", "收费机", "盆地", "RestBench", 1, MapZone.ABYSS),
                new Bench("Hidden Station", "Basin", "Abyss_22", "隐藏车站", "盆地", "RestBench", 1, MapZone.ABYSS),

                new Bench("Oro", "Edge", "Deepnest_East_06", "奥罗", "边境", "RestBench", 1, MapZone.OUTSKIRTS, true, "Oro"),
                new Bench("Camp", "Edge", "Deepnest_East_13", "帐篷", "边境", "RestBench", 1, MapZone.OUTSKIRTS, true, "Camp"),
                new Bench("Colosseum", "Edge", "Room_Colosseum_02", "竞技场", "边境", "RestBench", 1, MapZone.COLOSSEUM, true, "Fool"),
                new Bench("Hive", "Edge", "Hive_01", "蜂巢", "边境", "RestBench", 1, MapZone.HIVE),

                new Bench("Dark Room", "Peak", "Mines_29", "暗室", "矿山", "RestBench", 1, MapZone.MINES),
                new Bench("Crystal Guardian", "Peak", "Mines_18", "激光哥", "矿山", "RestBench", 1, MapZone.MINES),

                new Bench("Stag", "Grounds", "RestingGrounds_09", "车站", "安息", "RestBench", 1, MapZone.RESTING_GROUNDS),
                new Bench("Grey Mourner", "Grounds", "RestingGrounds_12", "送花", "安息", "RestBench", 1, MapZone.RESTING_GROUNDS),

                new Bench("Cornifer", "Gardens", "Fungus1_24", "绘图师", "花园", "RestBench", 1, MapZone.ROYAL_GARDENS, true, "Garden"),
                new Bench("Toll", "Gardens", "Fungus3_50", "收费机", "花园", "RestBench", 1, MapZone.ROYAL_GARDENS),
                new Bench("Stag", "Gardens", "Fungus3_40", "车站", "花园", "RestBench", 1, MapZone.ROYAL_GARDENS),

                new Bench("Entrance", "Palace", "White_Palace_01", "入口", "白宫", "WhiteBench", 1, MapZone.WHITE_PALACE, true, "White"),
                new Bench("Atrium", "Palace", "White_Palace_03_hub", "中庭", "白宫", "WhiteBench", 1, MapZone.WHITE_PALACE),
                new Bench("Balcony", "Palace", "White_Palace_06", "阳台", "白宫", "RestBench", 1, MapZone.WHITE_PALACE),

                new Bench("Upper Tram", "Tram", "Room_Tram_RG", "上电车", "电车", "RestBench", 1, MapZone.TRAM_UPPER),
                new Bench("Lower Tram", "Tram", "Room_Tram", "下电车", "电车", "RestBench", 1, MapZone.TRAM_LOWER, true, "Tram")
            };

        public readonly string name;
        public readonly string areaName;
        public readonly string sceneName;
        public readonly string cnName;
        public readonly string cnAreaName;
        public readonly string respawnMarker;
        public readonly int respawnType;
        public readonly MapZone mapZone;
        public readonly bool preload;
        public readonly string style;

        public bool visited
        {
            get => Benchwarp.instance.Settings.GetBool(false, sceneName);
            set => Benchwarp.instance.Settings.SetBool(value, sceneName);
        }
        public bool benched => PlayerData.instance.respawnScene == sceneName &&
            PlayerData.instance.respawnMarkerName == respawnMarker &&
            PlayerData.instance.respawnType == respawnType &&
            !Benchwarp.instance.Settings.atDeployedBench;

        public Bench(string _name, string _areaName, string _sceneName, string _cnName, string _cnAreaName, string _respawnMarker, int _respawnType, MapZone _mapZone, bool _preload = false, string _style = null)
        {
            name = _name; // may not be unique
            areaName = _areaName; // may be abbreviated, see below
            sceneName = _sceneName;
            cnName = _cnName;
            cnAreaName = _cnAreaName;
            respawnMarker = _respawnMarker;
            respawnType = _respawnType;
            mapZone = _mapZone;
            preload = _preload;
            style = _style;
        }

        public void SetBench()
        {
            if (!Benchwarp.instance.GlobalSettings.UnlockAllBenches && !visited && sceneName != "Tutorial_01") return;
            Benchwarp.instance.Settings.atDeployedBench = false;
            PlayerData.instance.respawnScene = sceneName;
            PlayerData.instance.respawnMarkerName = respawnMarker;
            PlayerData.instance.respawnType = respawnType;
            PlayerData.instance.mapZone = mapZone;
        }
        public static Bench GetStyleBench(string style)
        {
            return Benches.First(bench => bench.style == style);
        }
    }
}
