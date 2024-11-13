using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageInfo", menuName = "StageInfo")]
public class StageInfo : ScriptableObject
{
    public List<Stage> stages;
}

[System.Serializable]
public struct Stage
{
    public int reward;
    public List<EnemyInfo> enemies;
}
