using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    [Range(0, 1)]
    private int stage;

    private bool valueChanged;

    public GameObject enemyPrefab;


    private List<Stage> stages;

    private List<GameObject> enemies;

    public int StageNum {  get { return stage; } set { valueChanged = true; stage = value; } }

    private void Awake()
    {
        stages = Resources.Load<StageInfo>("Data/Stage/StageInfo").stages;

        SpawnEnemy(0);
    }


    private void Update()
    {
        if(valueChanged)
        {
            valueChanged = false;

            RemoveEnemy();
            SpawnEnemy(stage);
        }
    }

    public void SpawnEnemy(int stage)
    {
        if (stages.Count >= stage) return;

        var enemyList = stages[stage].enemies;

        for(int i = 0; i < enemyList.Count; i++)
        {
            GameObject go = Instantiate(enemyPrefab, transform);
            go.name = enemyList[i].name;
            go.GetComponent<CharacterStat>().maxHP = enemyList[i].maxHP;
            go.GetComponent<CharacterStat>().curHP = enemyList[i].maxHP;
            go.GetComponent<CharacterStat>().attack = enemyList[i].attack;
            go.GetComponent<CharacterStat>().defense = enemyList[i].defense;

            enemies.Add(go);
        }
    }

    public void RemoveEnemy()
    {
        foreach(var enemy in enemies) Destroy(enemy);
    }
}
