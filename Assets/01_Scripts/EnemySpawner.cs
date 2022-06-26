using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] monster;

    public float createTime = 2f;

    public List<Transform> points = new List<Transform>();

    public List<GameObject> monsterPool = new List<GameObject>();
    
    public int maxMonsters = 10;

    private bool isGameOver = false;

    public bool IsGameOver
    {
        get { return isGameOver; }
        set
        {
            isGameOver = value;
            if (isGameOver)
                CancelInvoke("CreateMonster");
        }
    }

    private void Start()
    {
        CreateMonsterPool();
        Transform spawnPointGroup = GameObject.Find("SpawnPointGroup_Monster")?.transform;
        foreach (Transform item in spawnPointGroup)
        {
            points.Add(item);
        }
        InvokeRepeating("CreateMonster", 2f, createTime);
    }

    public void CreateMonster()
    {
        int index = Random.Range(0, points.Count);

        //Instantiate(monster, points[index].position, points[index].rotation);

        GameObject _monster = GetMonsterInPool();
        _monster?.transform.SetPositionAndRotation(points[index].position, points[index].rotation);

        _monster?.SetActive(true);
    }
    public void CreateMonsterPool()
    {
        for (int i = 0; i < maxMonsters; i++)
        {
            var _monster = Instantiate<GameObject>(monster[Random.Range(0,2)]);

            _monster.name = $"Monster_{i:00}";

            _monster.SetActive(false);

            monsterPool.Add(_monster);
        }
    }

    public GameObject GetMonsterInPool()
    {
        foreach (var _monster in monsterPool)
        {
            if (!_monster.activeSelf)
                return _monster;
        }

        return null;
    }
}
