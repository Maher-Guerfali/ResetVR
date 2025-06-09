using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    [System.Serializable]
    public class WallInfo
    {
        public GameObject wall;
        public int zombiesToKill;
    }

    public List<WallInfo> wallsInfo = new List<WallInfo>();

    // Other script code...

    public void KilledZombie()
    {
        foreach (var wallInfo in wallsInfo)
        {
            wallInfo.zombiesToKill--;

            if (wallInfo.zombiesToKill <= 0)
            {
                wallInfo.wall.SetActive(false);
            }
        }
    }
}
