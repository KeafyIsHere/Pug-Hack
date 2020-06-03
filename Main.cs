using Harmony;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pug_Hack
{
    public class Main : MelonLoader.MelonMod
    {
        private List<string> gobjenable = new List<string>()
        {
            "/ - Logic Objects/GameObject/- MOD TOOLS",
            "/ - Logic Objects/GameObject/- MOD TOOLS/MimiLock-MOD/Unlocked",
            "/ - Logic Objects/GameObject/GameObject-01",
            "/ - Logic Objects/GameObject/GameObject-00/GameObject",
            "/ - Logic Objects/GameObject/bar-security/button - bar eject - night view",
            "/ - Logic Objects/GameObject/bar-security/button - bar eject - main",
            "/ - Logic Objects/Stage Lights - Controls/stage-light-buttons",
            "/ - Logic Objects/GameObject/bar-security/button-bar-teleport (EXIT)",
            "/ - Logic Objects/GameObject/bar-security/button-bar-teleport (ENTER)"
        };

        private List<string> gobjdestroy = new List<string>()
        {
            "/ - Props/Props (Static) - Hallways - First Floor/door_fire (2)",
            "/great_pug/Cube_093",
            "/great_pug/Cube_022  (GLASS)",
            "/dumpster (1)",
            "/dumpster",
            "/great_pug/door-frame_004",
            "/great_pug/door-frame_002",
            "door-basic - basement",
            "/great_pug/Cube_000",
            "/ - Logic Objects/Script Loading/entrance-blocker"
        };
        Dictionary<string, string> gobiter = new Dictionary<string, string>()
        {
            {
                "keypad - night view",  "wall-panel"
            },
            {
                "/ - Logic Objects/GameObject/bar-security/keypad (1)" , "wall-panel"
            }
        };
        Dictionary<string, Vector3> gobjmove = new Dictionary<string, Vector3>()
        {
            {
                "/ - Logic Objects/GameObject/utility-security/RemoveBabs - night view",  Vector3.positiveInfinity
            },
            {
                "/ - Logic Objects/GameObject/bar-security/RemoveBabs - main bar",  Vector3.positiveInfinity
            },
            {
                "/ - Logic Objects/GameObject/bar-security/bar - main - lock-down-barrior" , Vector3.positiveInfinity
            },
            {
                "/ - Logic Objects/GameObject/bar-security/bar - Two - lock-down-barrior", Vector3.positiveInfinity
            },
            //{
            //    "/great_pug_floor2/stage-locked_barrior", new Vector3(1000,1000,1000)
            //},
            {
                "/ - Logic Objects/GameObject/bar-security/button - bar eject - main", new Vector3(1.0319f, -1.401f, -0.7901f)
            },
            {
                "/ - Logic Objects/GameObject/bar-security/button - bar eject - night view", new Vector3(-6.1633f, 5.055f, -3.072f)
            }
        };
        private List<string> coliders = new List<string>
        {
            "/regency_shelves_24x72x74 (1)/shelves",
            "/great_pug/pantry_freezer_walls",
            "/regency_shelves_24x72x74 (4)/shelves",
            "/regency_shelves_24x72x74 (14)/shelves",
            "/regency_shelves_24x72x74 (11)/shelves",
            "/regency_shelves_24x72x74 (7)/shelves",
            "/regency_shelves_24x72x74 (13)/shelves",
            "/great_pug_floor2/floor-1-mapped-walls-outer_025",
            "/great_pug_floor2/floor-1-mapped-walls-on-windows_003",
            "/ - Props/Props (Static) - Hallways - First Floor/Velvet Rope (1)",
            "/ - Props/Props (Static) - Hallways - First Floor/Velvet Rope",
            "/ - Safe Areas",
            "/great_pug/kitchen-walls",
            "/Cube"
        };

        public override void OnLevelWasLoaded(int level)
        {
            if (string.IsNullOrEmpty(GameObject.FindObjectOfType<ApiWorldUpdate>().field_Private_String_0)) return;
            if (GameObject.FindObjectOfType<ApiWorldUpdate>().field_Private_String_0.Contains("wrld_6caf5200-70e1-46c2-b043-e3c4abe69e0f"))
            {
                foreach (string go in gobjenable)
                    GameObject.Find(go).SetActive(true);
                foreach (string go in gobjdestroy)
                    GameObject.Destroy(GameObject.Find(go));
                foreach (KeyValuePair<string, string> item in gobiter)
                    for (int i = 0; i < GameObject.Find(item.Key).transform.childCount; i++)
                        if (GameObject.Find(item.Key).transform.GetChild(i).name != item.Value)
                            GameObject.Find(item.Key).transform.GetChild(i).gameObject.SetActive(true);
                foreach (KeyValuePair<string, Vector3> govalues in gobjmove)
                    GameObject.Find(govalues.Key).transform.localPosition = govalues.Value;
                foreach (string line in coliders)
                    foreach (Collider col in GameObject.Find(line).GetComponents<Collider>())
                        col.enabled = false;


                //temp fix for foreach gameobject move failing to find this gameobject
                foreach (GameObject all in Resources.FindObjectsOfTypeAll<GameObject>())
                    if (all.name == "stage-locked_barrior")
                        all.transform.localPosition = Vector3.positiveInfinity;
            }
        }
    }
}