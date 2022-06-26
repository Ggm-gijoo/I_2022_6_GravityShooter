using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject NPC;


    public List<Transform> points = new List<Transform>();

    public List<GameObject> npcPool = new List<GameObject>();

    public int maxNPC = 10;

    private void Start()
    {
        CreateNPCPool();
        Transform spawnPointGroup = GameObject.Find("SpawnPointGroup_NPC")?.transform;
        foreach (Transform item in spawnPointGroup)
        {
            points.Add(item);
        }
        for(int i = 0; i < maxNPC; i++)
        {
            CreateNPC();
        }
    }

    public void CreateNPC()
    {
        int index = Random.Range(0, points.Count);

        //Instantiate(monster, points[index].position, points[index].rotation);

        GameObject _npc = GetNPCInPool();
        _npc?.transform.SetPositionAndRotation(points[index].position, points[index].rotation);

        _npc?.SetActive(true);
    }
    public void CreateNPCPool()
    {
        for (int i = 0; i < maxNPC; i++)
        {
            var _npc = Instantiate<GameObject>(NPC);

            _npc.name = $"NPC_{i:00}";

            _npc.SetActive(false);

            npcPool.Add(_npc);
        }
    }

    public GameObject GetNPCInPool()
    {
        foreach (var _npc in npcPool)
        {
            if (!_npc.activeSelf)
                return _npc;
        }

        return null;
    }
}
