using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ImpHunter.GameObjects
{
    public class ObjectPool : GameObject
    {
        #region Object Pools

        #region Projectile
        public Pool projectiles;
        public Projectile projectile;
        #endregion

        #endregion

        public class Pool
        {
            public string tag;
            public int size;

            public GameObjectList objList = new GameObjectList();
            public Queue<GameObject> objectPool = new Queue<GameObject>();
        }

        public List<Pool> objPools = new List<Pool>();
        public Dictionary<string, Queue<GameObject>> poolDictionary;


        public ObjectPool()
        {
            #region Pool Instantiation

            #region Projectile Pool


            objPools.Add(projectiles = new Pool());

            projectiles.tag = "projectile";
            projectiles.size = 2;



            #endregion

            #endregion




            poolDictionary = new Dictionary<string, Queue<GameObject>>();

            foreach (Pool pool in objPools)
            {
                pool.objectPool = new Queue<GameObject>();

                #region Pool Object List Population
                if(pool.tag == "projectile")
                    for (int i = 0; i < projectiles.size; i++)
                    {
                        pool.objList.Add(projectile = new Projectile());
                    }
                Console.WriteLine(pool.objList.Children.Count);
                #endregion

                foreach (GameObject obj in pool.objList.Children)
                {
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

