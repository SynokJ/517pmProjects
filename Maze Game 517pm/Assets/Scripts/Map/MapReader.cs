using UnityEngine;

public abstract class MapReader<T> : MonoBehaviour
{
    protected abstract void GetMapsTemplate();
    protected abstract void InitLevels();
}
