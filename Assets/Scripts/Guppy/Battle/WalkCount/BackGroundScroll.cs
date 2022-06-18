using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class BackGroundScroll : MonoBehaviour
    {
        [SerializeField] private Transform backGroundTransform;
        [SerializeField] private float startPos = 9f;
        [SerializeField] private float endPos = 418f;
        
        void Start()
        {
            UpdateBG(0f);
        }

        public void SetScrollPer(float scrollPer)
        {
            UpdateBG(scrollPer);
        }

        private void UpdateBG(float scrollPer)
        {
            float xPosition = (endPos - startPos) * scrollPer + startPos;
            backGroundTransform.position = new Vector3(xPosition, 0f, 0f);
        }
    }

}
