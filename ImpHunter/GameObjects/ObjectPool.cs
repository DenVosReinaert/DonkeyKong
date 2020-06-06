using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace ImpHunter.GameObjects
{
    public class ObjectPool : GameObject
    {

        public class Pool
        {
            public string tag;
            public GameObject prefab;
            public int size;
            public Queue<GameObject> objectPool = new Queue<GameObject>();
        }

        public List<Pool> objPools;
        public Dictionary<string, Queue<GameObject>> poolDictionary;


        public ObjectPool()
        {
            objPools = new List<Pool>();
            //public Queue<GameObject> objectPool;

            poolDictionary = new Dictionary<string, Queue<GameObject>>();

            foreach (Pool pool in objPools)
            {
                pool.objectPool = new Queue<GameObject>();

                for (int i = 0; i < pool.size; i++)
                {
                    GameObject obj = pool.prefab;
                    obj.Visible = false;
                    pool.objectPool.Enqueue(obj);
                }

                poolDictionary.Add(pool.tag, pool.objectPool);
            }
        }

        public void SpawnFromPool(string tag, Vector2 position)
        {
            if (!poolDictionary.ContainsKey(tag))
            {
                Debug.WriteLine("The pool with tag " + tag + " doesn't excist. Returning.");
                return;
            }

            GameObject objToSpawn = poolDictionary[tag].Dequeue();

            objToSpawn.Visible = true;
            objToSpawn.Position = position;

            poolDictionary[tag].Enqueue(objToSpawn);
        }

    }
}

