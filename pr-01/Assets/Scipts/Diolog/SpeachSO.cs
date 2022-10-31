using UnityEngine;

[CreateAssetMenu(fileName = "Speach", menuName = "ScriptableObjects/Speach")]
public class SpeachSO : ScriptableObject
{
    [Header("Player Speach:")]
    public string playerInitSpeach;
    public string[] playerSpeaches;

    [Header("Enemy Speach:")]
    public string enemyInitSpeach;
    public string[] enemySpeachs;
}
