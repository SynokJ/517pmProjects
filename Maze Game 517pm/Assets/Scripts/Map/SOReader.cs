using System.Collections.Generic;
using UnityEngine;

public class SOReader : MapReader<MapSO>
{

    private List<MapSO> maps = new List<MapSO>();

    protected override void GetMapsTemplate()
    {
        Debug.Log(maps[0].ToString());
    }

    protected override void InitLevels()
    {
        throw new System.NotImplementedException();
    }
}
