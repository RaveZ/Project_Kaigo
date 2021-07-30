using Z.Collections;
using UnityEngine;
using System.Collections.Generic;

namespace Z.TargetLock.Runtime
{
    public class TargetLockHandler : MonoBehaviour
    {
        public List<GameObject> Targets = new List<GameObject>();
        bool enterBattle;
        public LayerMask TargetLayer;
       /* public LayerMask enemyLayers;
        int numColliders;
        int maxColliders = 100;
        public Collider[] EnemyColliders;
        void UpdateTarget(Vector3 center, float radius)
        {
            EnemyColliders = new Collider[maxColliders];
            numColliders = Physics.OverlapSphereNonAlloc(
                         transform.position,
                         radius,
                         EnemyColliders,
                         enemyLayers
                       );
            *//*for(int i = 0; i < numColliders; i++)
            {
                Target.Add();
            }*//*
            Target = new List<Collider>(EnemyColliders);
        }*/
        void Start()
        {

        }


        //trigger if enemy get on the field
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == TargetLayer)
            {
                Targets.Add(other.gameObject);
                enterBattle = true;
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == TargetLayer)
            {
                Targets.Remove(other.gameObject);
                if (Targets.Count == 0)
                {
                    enterBattle = false;
                }
            }
        }
    }
}

