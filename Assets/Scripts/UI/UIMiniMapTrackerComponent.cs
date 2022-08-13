using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIMiniMapTrackerComponent : MonoBehaviour
    {
        [SerializeField]
        private Transform m_trackingTransform = null;
        [SerializeField]
        private float m_trackerHeight = 10.0f;

        /// <summary>
        /// Set tracker location based on transform of target being tracked and exepected height above object
        /// </summary>
        public void UpdateTracker()
        {
            var transformPos = m_trackingTransform.position;
            transformPos.y = transformPos.y + m_trackerHeight;

            transform.position = transformPos;
        }
    }
}