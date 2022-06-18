using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class ScrollBGWalkCount : MonoBehaviour
    {
        [SerializeField] private BackGroundScroll backGround;
        [SerializeField] private WalkCountManager walkCountManager;
        
        void Update()
        {
            backGround.SetScrollPer(walkCountManager.GetWalkPer());
        }
    }

}
