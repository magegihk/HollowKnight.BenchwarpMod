using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

namespace Benchwarp
{
    public static class TopMenu
    {
        private static CanvasPanel rootPanel;
        private static CanvasPanel sceneNamePanel;
        public static GameObject canvas;
        private static float cooldown;
        private static bool onCooldown;
        private static List<string> benchPanels;
        private static int fontSize;

        private static readonly Type t = typeof(GlobalSettings);

        private static readonly Dictionary<string, (string, UnityAction<string>, PropertyInfo, string)[]> Panels =
            new Dictionary<string, (string, UnityAction<string>, PropertyInfo, string)[]>
            {
                ["Options"] = new (string, UnityAction<string>, PropertyInfo, string)[]
                {
                    ("Cooldown", CooldownClicked, t.GetProperty(nameof(GlobalSettings.DeployCooldown)), "冷却"),
                    ("Noninteractive", NoninteractiveClicked, t.GetProperty(nameof(GlobalSettings.Noninteractive)), "非交互"),
                    ("No Mid-Air Deploy", NoMidAirDeployClicked, t.GetProperty(nameof(GlobalSettings.NoMidAirDeploy)), "禁空中部署"),
                    ("Blacklist", BlacklistClicked, t.GetProperty(nameof(GlobalSettings.BlacklistRooms)), "黑名单"),
                    ("Reduce Preload", ReducePreloadClicked, t.GetProperty(nameof(GlobalSettings.ReducePreload)), "减少预加载")
                },

                ["Settings"] = new (string, UnityAction<string>, PropertyInfo, string)[]
                {
                    ("Warp Only", WarpOnlyClicked, t.GetProperty(nameof(GlobalSettings.WarpOnly)), "只回城"),
                    ("Unlock All", UnlockAllClicked, t.GetProperty(nameof(GlobalSettings.UnlockAllBenches)), "全解锁"),
                    ("Show Room Name", ShowSceneClicked, t.GetProperty(nameof(GlobalSettings.ShowScene)), "显示房间名"),
                    ("汉化", TranslateClicked, t.GetProperty(nameof(GlobalSettings.ChineseNames)), "English"),
                    ("Use Room Names", SwapNamesClicked, t.GetProperty(nameof(GlobalSettings.SwapNames)), "使用房间名"),
                    ("Enable Deploy", EnableDeployClicked, t.GetProperty(nameof(GlobalSettings.EnableDeploy)), "开启部署")
                }
            };

        private static readonly Dictionary<string, (UnityAction<string>, Vector2, string)> Buttons = new Dictionary<string, (UnityAction<string>, Vector2, string)>
        {
            ["Deploy"] = (DeployClicked, new Vector2(-154f, 300f), "部署"),
            ["Set"] = (SetClicked, new Vector2(-54f, 300f), "设置"),
            ["Destroy"] = (s => BenchMaker.DestroyBench(), new Vector2(46f, 300f), "摧毁")
        };

        private static readonly Dictionary<string, (UnityAction<string>, Vector2)> RandomizerButtons = new Dictionary<string, (UnityAction<string>, Vector2)>
        {
            ["Set Start"] = (s => RandomizerStartLocation.SetStart(), new Vector2(1446f, 300f))
        };

        public static void BuildMenu(GameObject _canvas)
        {
            canvas = _canvas;

            sceneNamePanel = new CanvasPanel
                (_canvas, GUIController.Instance.images["ButtonsMenuBG"], new Vector2(0f, 0f), new Vector2(1346f, 0f), new Rect(0f, 0f, 0f, 0f));
            sceneNamePanel.AddText("SceneName", "Tutorial_01", new Vector2(5f, 1060f), Vector2.zero, GUIController.Instance.TrajanNormal, 18);

            rootPanel = new CanvasPanel
                (_canvas, GUIController.Instance.images["ButtonsMenuBG"], new Vector2(342f, 15f), new Vector2(1346f, 0f), new Rect(0f, 0f, 0f, 0f));

            Rect buttonRect = new Rect(0, 0, GUIController.Instance.images["ButtonRect"].width, GUIController.Instance.images["ButtonRect"].height);

            fontSize = 12;

            void AddButton(CanvasPanel panel, string name, UnityAction<string> action, Vector2 pos, string displayName = null, Font f = null)
            {
                panel.AddButton
                (
                    name,
                    GUIController.Instance.images["ButtonRectEmpty"],
                    pos,
                    Vector2.zero,
                    action,
                    new Rect(0f, 0f, 80f, 40f),
                    f != null ? f : GUIController.Instance.TrajanNormal,
                    displayName ?? name,
                    fontSize
                );
            }

            CanvasPanel MakePanel(string name, Vector2 position, string cnName)
            {
                CanvasPanel newPanel = rootPanel.AddPanel
                (
                    name,
                    GUIController.Instance.images["ButtonRectEmpty"],
                    position,
                    Vector2.zero,
                    new Rect(0f, 0f, GUIController.Instance.images["DropdownBG"].width, 270f)
                );
                rootPanel.AddButton
                (
                    name,
                    GUIController.Instance.images["ButtonRect"],
                    position + new Vector2(1f, -20f),
                    Vector2.zero,
                    s => rootPanel.TogglePanel(name),
                    buttonRect,
                    GUIController.Instance.TrajanBold,
                    !Benchwarp.instance.GlobalSettings.ChineseNames ? name : cnName
                );

                return newPanel;
            }

            //Main buttons
            rootPanel.AddButton
            (
                "Warp",
                GUIController.Instance.images["ButtonRect"],
                new Vector2(-154f, 40f),
                Vector2.zero,
                WarpClicked,
                buttonRect,
                GUIController.Instance.TrajanBold,
                !Benchwarp.instance.GlobalSettings.ChineseNames ? "Warp" : "回城"
            );

            if (Benchwarp.instance.GlobalSettings.EnableDeploy)
            {
                foreach (KeyValuePair<string, (UnityAction<string>, Vector2, string)> pair in Buttons)
                {
                    rootPanel.AddButton
                    (
                        pair.Key,
                        GUIController.Instance.images["ButtonRect"],
                        pair.Value.Item2,
                        Vector2.zero,
                        pair.Value.Item1,
                        buttonRect,
                        GUIController.Instance.TrajanBold,
                        !Benchwarp.instance.GlobalSettings.ChineseNames ? pair.Key : pair.Value.Item3,
                        fontSize: 11
                    );
                }

                CanvasPanel style = MakePanel("Style", new Vector2(145f, 320f), "样式");

                Vector2 position = new Vector2(5f, 25f);

                foreach ((string, string) styleName in BenchMaker.Styles)
                {
                    AddButton(style, styleName.Item1, StyleChanged, position, !Benchwarp.instance.GlobalSettings.ChineseNames ? styleName.Item1 : styleName.Item2);

                    position += new Vector2(0f, 30f);
                }

                CanvasPanel options = MakePanel("Options", new Vector2(245f, 320f), "选项");

                for (int i = 0; i < Panels["Options"].Length; i++)
                {
                    (string name, UnityAction<string> action, PropertyInfo _, string cnName) = Panels["Options"][i];

                    AddButton
                    (
                        options,
                        name,
                        action,
                        new Vector2(5f, 25 + i * 40),
                        !Benchwarp.instance.GlobalSettings.ChineseNames ? name : cnName
                    );
                }
            }


            CanvasPanel settings = MakePanel("Settings", new Vector2(1445f, 20f), "设置");

            for (int i = 0; i < Panels["Settings"].Length; i++)
            {
                (string name, UnityAction<string> action, PropertyInfo _, string cnName) = Panels["Settings"][i];

                AddButton
                (
                    settings,
                    name,
                    action,
                    new Vector2(5f, 25 + i * 40),
                    !Benchwarp.instance.GlobalSettings.ChineseNames ? name : cnName
                );
            }

            if (Benchwarp.instance.GlobalSettings.WarpOnly) return;

            if (RandomizerStartLocation.RandomizerActive)
            {
                foreach (KeyValuePair<string, (UnityAction<string>, Vector2)> pair in RandomizerButtons)
                {
                    rootPanel.AddButton
                    (
                        pair.Key,
                        GUIController.Instance.images["ButtonRect"],
                        pair.Value.Item2,
                        Vector2.zero,
                        pair.Value.Item1,
                        buttonRect,
                        GUIController.Instance.TrajanBold,
                        pair.Key
                    );
                }
            }

            Vector2 panelDistance = new Vector2(-155f, 20f);

            Dictionary<string, Vector2> panelButtonHeight = new Dictionary<string, Vector2>();
            benchPanels = new List<string>();

            foreach (Bench bench in Bench.Benches)
            {
                if (!panelButtonHeight.ContainsKey(bench.areaName))
                {
                    benchPanels.Add(bench.areaName);
                    panelDistance += new Vector2(100f, 0f);
                    panelButtonHeight[bench.areaName] = new Vector2(5f, 25f);
                    MakePanel(bench.areaName, panelDistance, bench.cnAreaName);
                }
                else
                {
                    panelButtonHeight[bench.areaName] += new Vector2(0f, 40f);
                }

                rootPanel.GetPanel(bench.areaName)
                         .AddButton
                         (
                             bench.name,
                             GUIController.Instance.images["ButtonRectEmpty"],
                             panelButtonHeight[bench.areaName],
                             Vector2.zero,
                             (string s) => bench.SetBench(),
                             new Rect(0f, 0f, 80f, 40f),
                             GUIController.Instance.TrajanNormal,
                             !Benchwarp.instance.GlobalSettings.SwapNames ? (!Benchwarp.instance.GlobalSettings.ChineseNames ? bench.name : bench.cnName) : bench.sceneName,
                             fontSize
                         );
            }

            rootPanel.AddButton
            (
                "All",
                GUIController.Instance.images["ButtonRect"],
                new Vector2(-154f, 0f),
                Vector2.zero,
                AllClicked,
                buttonRect,
                GUIController.Instance.TrajanBold,
                !Benchwarp.instance.GlobalSettings.ChineseNames ? "All" : "全部"
            );

            rootPanel.FixRenderOrder();
        }

        public static void Update()
        {
            if (cooldown > 0)
            {
                cooldown -= Time.unscaledDeltaTime;
            }

            if (rootPanel == null || sceneNamePanel == null) return;
            if (GameManager.instance == null || !GameManager.instance.IsGameplayScene() || HeroController.instance == null)
            {
                rootPanel.SetActive(false, true);
                return;
            }

            Benchwarp bw = Benchwarp.instance;
            GlobalSettings gs = bw.GlobalSettings;

            if (gs.ShowScene)
            {
                sceneNamePanel.SetActive(true, false);
                sceneNamePanel.GetText("SceneName").UpdateText(GameManager.instance.sceneName);
            }
            else sceneNamePanel.SetActive(false, true);

            if (GameManager.instance.IsGamePaused())
                rootPanel.SetActive(true, false);
            else
                rootPanel.SetActive(false, true);

            if (gs.AlwaysToggleAll)
            {
                foreach (string s in benchPanels)
                    if (!rootPanel.GetPanel(s).active)
                        rootPanel.TogglePanel(s);
            }

            if (gs.EnableDeploy)
            {
                CanvasButton deploy = rootPanel.GetButton("Deploy");

                if (onCooldown)
                {
                    deploy.UpdateText(((int) cooldown).ToString());
                }

                if (cooldown <= 0 && onCooldown)
                {
                    deploy.UpdateText("Deploy");
                    onCooldown = false;
                }

                bool cantDeploy = onCooldown
                    || gs.BlacklistRooms && BenchMaker.Blacklist()
                    || gs.NoMidAirDeploy && !HeroController.instance.CheckTouchingGround();

                deploy.SetTextColor(cantDeploy ? Color.red : Color.white);

                rootPanel.GetButton("Set")
                         .SetTextColor
                         (
                             Benchwarp.instance.Settings.atDeployedBench
                                 ? Color.yellow
                                 : Color.white
                         );

                if (rootPanel.GetPanel("Style").active)
                {
                    foreach ((string, string) style in BenchMaker.Styles)
                    {
                        rootPanel.GetButton(style.Item1, "Style").SetTextColor(gs.benchStyle == style.Item1 ? Color.yellow : Color.white);
                    }
                }

                CanvasPanel options = rootPanel.GetPanel("Options");

                if (options.active)
                {
                    foreach ((string name, PropertyInfo pi) in Panels["Options"].Select(x => (x.Item1, x.Item3)))
                    {
                        options.GetButton(name).SetTextColor((bool) pi.GetValue(gs, new object[0]) ? Color.yellow : Color.white);
                    }
                }
            }

            CanvasPanel settings = rootPanel.GetPanel("Settings");

            if (settings.active)
            {
                foreach ((string name, PropertyInfo pi) in Panels["Settings"].Select(x => (x.Item1, x.Item3)))
                {
                    settings.GetButton(name).SetTextColor((bool) pi.GetValue(gs, new object[0]) ? Color.yellow : Color.white);
                }
            }

            if (!Benchwarp.instance.GlobalSettings.WarpOnly && RandomizerStartLocation.RandomizerActive)
            {
                rootPanel.GetButton("Set Start").SetTextColor(RandomizerStartLocation.CheckIfAtStart() ? Color.yellow : Color.white);
            }

            foreach (Bench bench in Bench.Benches)
            {
                if (!rootPanel.GetPanel(bench.areaName).active) continue;

                if (!bench.visited && !gs.UnlockAllBenches)
                {
                    rootPanel.GetButton(bench.name, bench.areaName).SetTextColor(Color.red);
                }
                else
                {
                    rootPanel.GetButton(bench.name, bench.areaName).SetTextColor(bench.benched ? Color.yellow : Color.white);
                }
            }
        }

        private static void WarpClicked(string buttonName)
        {
            if (Benchwarp.instance.GlobalSettings.UnlockAllBenches)
                UnlockAllClicked(null);

            GameManager.instance.StartCoroutine(Benchwarp.instance.Respawn());
        }

        private static void DeployClicked(string buttonName)
        {
            if (onCooldown) return;
            if (Benchwarp.instance.GlobalSettings.BlacklistRooms && BenchMaker.Blacklist()) return;
            if (Benchwarp.instance.GlobalSettings.NoMidAirDeploy && !HeroController.instance.CheckTouchingGround()) return;

            BenchMaker.DestroyBench();

            Benchwarp.instance.Settings.benchDeployed = true;
            Benchwarp.instance.Settings.benchX = HeroController.instance.transform.position.x;
            Benchwarp.instance.Settings.benchY = HeroController.instance.transform.position.y;
            Benchwarp.instance.Settings.benchScene = GameManager.instance.sceneName;

            BenchMaker.MakeBench();

            SetClicked(null);

            if (!Benchwarp.instance.GlobalSettings.DeployCooldown) return;

            cooldown = 300f;
            onCooldown = true;
        }

        private static void SetClicked(string buttonName)
        {
            if (!Benchwarp.instance.Settings.benchDeployed) return;
            Benchwarp.instance.Settings.atDeployedBench = true;
        }

        #region Deploy options

        private static void StyleChanged(string buttonName)
        {
            Benchwarp.instance.GlobalSettings.benchStyle = buttonName;
            Benchwarp.instance.SaveGlobalSettings();
        }

        private static void CooldownClicked(string buttonName)
        {
            Benchwarp.instance.GlobalSettings.DeployCooldown = !Benchwarp.instance.GlobalSettings.DeployCooldown;
            Benchwarp.instance.SaveGlobalSettings();
            cooldown = 0f;
        }

        private static void NoninteractiveClicked(string buttonName)
        {
            Benchwarp.instance.GlobalSettings.Noninteractive = !Benchwarp.instance.GlobalSettings.Noninteractive;
            Benchwarp.instance.SaveGlobalSettings();
            if (!Benchwarp.instance.GlobalSettings.Noninteractive && BenchMaker.DeployedBench != null)
            {
                BenchMaker.MakeBench();
            }
        }

        private static void NoMidAirDeployClicked(string buttonName)
        {
            Benchwarp.instance.GlobalSettings.NoMidAirDeploy = !Benchwarp.instance.GlobalSettings.NoMidAirDeploy;
            Benchwarp.instance.SaveGlobalSettings();
        }

        private static void BlacklistClicked(string buttonName)
        {
            Benchwarp.instance.GlobalSettings.BlacklistRooms = !Benchwarp.instance.GlobalSettings.BlacklistRooms;
            Benchwarp.instance.SaveGlobalSettings();
        }

        private static void ReducePreloadClicked(string buttonName)
        {
            Benchwarp.instance.GlobalSettings.ReducePreload = !Benchwarp.instance.GlobalSettings.ReducePreload;
            Benchwarp.instance.SaveGlobalSettings();
        }

        #endregion

        #region Settings button method

        private static void WarpOnlyClicked(string buttonName)
        {
            Benchwarp.instance.GlobalSettings.WarpOnly = !Benchwarp.instance.GlobalSettings.WarpOnly;
            Benchwarp.instance.SaveGlobalSettings();
            rootPanel.Destroy();
            sceneNamePanel.Destroy();
            BuildMenu(canvas);
        }

        private static void UnlockAllClicked(string buttonName)
        {
            if (buttonName != null)
            {
                Benchwarp.instance.GlobalSettings.UnlockAllBenches = !Benchwarp.instance.GlobalSettings.UnlockAllBenches;
                Benchwarp.instance.SaveGlobalSettings();
            }

            if (!Benchwarp.instance.GlobalSettings.UnlockAllBenches) return;

            PlayerData pd = PlayerData.instance;

            FieldInfo[] fields = typeof(PlayerData).GetFields();

            // Most of these are unnecessary, but some titlecards can lock you into a bench
            foreach
            (
                FieldInfo fi in fields.Where
                (
                    x => x.Name.StartsWith("visited")
                        || x.Name.StartsWith("tramOpened")
                        || x.Name.StartsWith("openedTram")
                        || x.Name.StartsWith("tramOpened")
                )
            )
            {
                pd.SetBoolInternal(fi.Name, true);
            }

            //This actually fixes the unlockable benches
            SceneData sd = GameManager.instance.sceneData;

            foreach ((string sceneName, string id) in new (string, string)[]
            {
                ("Hive_01", "Hive Bench"),
                ("Ruins1_31", "Toll Machine Bench"),
                ("Abyss_18", "Toll Machine Bench"),
                ("Fungus3_50", "Toll Machine Bench")
            })
            {
                sd.SaveMyState
                (
                    new PersistentBoolData
                    {
                        sceneName = sceneName,
                        id = id,
                        activated = true,
                        semiPersistent = false
                    }
                );
            }
        }

        private static void ShowSceneClicked(string buttonName)
        {
            Benchwarp.instance.GlobalSettings.ShowScene = !Benchwarp.instance.GlobalSettings.ShowScene;
            Benchwarp.instance.SaveGlobalSettings();
        }
        private static void TranslateClicked(string buttonName)
        {
            Benchwarp.instance.GlobalSettings.ChineseNames = !Benchwarp.instance.GlobalSettings.ChineseNames;
            Benchwarp.instance.SaveGlobalSettings();
            rootPanel.Destroy();
            sceneNamePanel.Destroy();
            BuildMenu(canvas);
        }
        private static void SwapNamesClicked(string buttonName)
        {
            Benchwarp.instance.GlobalSettings.SwapNames = !Benchwarp.instance.GlobalSettings.SwapNames;
            Benchwarp.instance.SaveGlobalSettings();
            rootPanel.Destroy();
            sceneNamePanel.Destroy();
            BuildMenu(canvas);
        }

        private static void EnableDeployClicked(string buttonName)
        {
            Benchwarp.instance.GlobalSettings.EnableDeploy = !Benchwarp.instance.GlobalSettings.EnableDeploy;
            Benchwarp.instance.SaveGlobalSettings();
            BenchMaker.DestroyBench();
            rootPanel.Destroy();
            sceneNamePanel.Destroy();
            BuildMenu(canvas);
        }

        private static void AlwaysToggleAllClicked(string buttonName)
        {
            Benchwarp.instance.GlobalSettings.AlwaysToggleAll = !Benchwarp.instance.GlobalSettings.AlwaysToggleAll;
            Benchwarp.instance.SaveGlobalSettings();
        }

        #endregion

        private static void AllClicked(string buttonName)
        {
            if (benchPanels.Any(s => !rootPanel.GetPanel(s).active))
            {
                foreach (string s in benchPanels)
                    if (!rootPanel.GetPanel(s).active)
                        rootPanel.TogglePanel(s);
            }
            else
            {
                foreach (string s in benchPanels)
                    if (rootPanel.GetPanel(s).active)
                        rootPanel.TogglePanel(s);
            }
        }
    }
}