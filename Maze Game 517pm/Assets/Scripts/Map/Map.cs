using System.Collections.Generic;

public class Map
{
    private List<List<char>> _map = new List<List<char>>();

    public Map(List<List<char>> map)
    {
        _map = map;
    }

    #region ToSctring()
    public override string ToString()
    {
        string res = default;

        for (int r = 0; r < _map.Count; ++r)
        {
            for (int c = 0; c < _map[r].Count; ++c)
                res += _map[r][c].ToString();
            res += '\n';
        }

        return res;
    }
    #endregion
}
