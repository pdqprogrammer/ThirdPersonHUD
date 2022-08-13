using UnityEngine;

namespace UI
{
    public class MissionTrigger : MonoBehaviour //TODO consider changing to serializable
    {
        [SerializeField]
        private PlayerUIManager m_playerUIManager = null;

        [SerializeField]
        private string m_missionTitle = "";
        [SerializeField]
        private string m_missionDetails = "";

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Player")
            {
                //Set mission UI text information based on trigger
                m_playerUIManager.TriggerMission(m_missionTitle, m_missionDetails);
            }
        }
    }
}