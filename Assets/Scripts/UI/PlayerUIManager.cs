using UnityEngine;

namespace UI
{
    public class PlayerUIManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_aimUIObject = null;

        [SerializeField]
        private UIMissionComponent m_hudMission = null;
        [SerializeField]
        private UIBarComponent m_healthBar = null;
        [SerializeField]
        private UIBarComponent m_experienceBar = null;
        [SerializeField]
        private UIBarComponent m_ability01Bar = null;
        [SerializeField]
        private UIFillBarComponent m_ability02FillBar = null;



        /// <summary>
        /// Handle Triggering Mission UI
        /// </summary>
        /// <param name="title"></param>
        /// <param name="details"></param>
        public void TriggerMission(string title, string details)
        {
            m_hudMission.SetMissionText(title, details);
        }

        /// <summary>
        /// Handle Setting Health
        /// </summary>
        /// <param name="healthPercent"></param>
        public void SetHealth(float healthPercent)
        {
            m_healthBar.SetProgressBar(healthPercent);
        }

        /// <summary>
        /// Handle Setting XP
        /// </summary>
        /// <param name="xpPercent"></param>
        public void SetXP(float xpPercent)
        {
            m_experienceBar.SetProgressBar(xpPercent);
        }

        /// <summary>
        /// Handle Setting Ability 01
        /// </summary>
        /// <param name="ability01Percent"></param>
        public void SetAbility01UI(float ability01Percent)
        {
            //TODO set up ability ui here
            m_ability01Bar.SetProgressBar(ability01Percent);
        }

        /// <summary>
        /// Handle Setting Ability 02
        /// </summary>
        /// <param name="ability02Count"></param>
        public void SetAbility02UI(int ability02Count)
        {
            //TODO set up ability ui here
            m_ability02FillBar.SetBarFill(ability02Count);
        }

        /// <summary>
        /// Handle Setting Aim Reticle
        /// </summary>
        /// <param name="isAiming"></param>
        public void SetAim(bool isAiming)
        {
            m_aimUIObject.SetActive(isAiming);
        }
    }
}