using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIMiniMapComponent : MonoBehaviour
    {
        [SerializeField]
        private UIMiniMapTrackerComponent[] m_miniMapTrackers;

        // Update loop for setting each tracker location
        private void Update()
        {
            foreach (var tracker in m_miniMapTrackers)
            {
                tracker.UpdateTracker();
            }
        }
    }
}