using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Battle
{
    public class WalkCountManager : MonoBehaviour
    {
        [SerializeField] private UIWalkCounter uIWalkCounter;
        [SerializeField] private float destination = 100f;
        [SerializeField] private float walkSpeed = 5f;
        [SerializeField] private UnityEvent onReachEnd;

        private WalkCounter walkCounter;
        private bool reached = false;

        // Start is called before the first frame update
        void Start()
        {
            walkCounter = new WalkCounter(destination);
        }

        // Update is called once per frame
        void Update()
        {
            if (walkCounter.IsReachedDestination())
            {
                if (!reached)
                {
                    ReachVillage();
                }
            }
            else
            {
                walkCounter.Walk(walkSpeed * Time.deltaTime);
            }

            uIWalkCounter.UpdateUI(walkCounter);
        }

        public void ReachVillage()
        {
            onReachEnd.Invoke();
            reached = true;
            Debug.Log("We reached the village!");
        }

        public float GetWalkPer()
        {
            return walkCounter.GetRemainingMetersPer();
        }
    }
}
