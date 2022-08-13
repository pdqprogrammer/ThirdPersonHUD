using StarterAssets;
using UI;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private PlayerUIManager m_playerUiManager;

        [SerializeField]
        private StarterAssetsInputs m_input;

        //Map maximum values
        [SerializeField]
        private int m_maxHealth = 10;
        [SerializeField]
        private int m_maxXP = 999;

        [SerializeField]
        private int m_maxLevel = 10;

        [SerializeField]
        private int m_maxAbility_01 = 25;
        [SerializeField]
        private int m_maxAbility_02 = 6;
        [SerializeField]
        private float m_maxAbilityRefreshTime = 1.0f;

        private DebuggingInput m_debugInput;

        //current values
        private int m_currentHealth;
        private int m_currentXP = 0;

        private int m_currentLevel = 1;

        private int m_currentAbility_01;
        private int m_currentAbility_02;

        private float m_currAbilityTime_01 = 0.0f;

        private void Start()
        {
            //Set current values to maximums
            m_currentHealth = m_maxHealth;
            m_currentAbility_01 = m_maxAbility_01;
            m_currentAbility_02 = m_maxAbility_02;

            m_playerUiManager.SetXP(0);
            m_playerUiManager.SetAbility02UI(m_maxAbility_02);
        }

        private void Update()
        {
            if (m_currAbilityTime_01 < m_maxAbilityRefreshTime)
            {
                m_currAbilityTime_01 += Time.deltaTime;
                if (m_currAbilityTime_01 >= m_maxAbilityRefreshTime)
                {
                    m_currAbilityTime_01 = 0.0f;
                    UpdateAbility(1, 1);
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            //TODO add in checks for objects that can hurt or heal player
            if (other.gameObject.tag == "Damage")
            {
                UpdateHealth(-1);
                UpdateXP(10);
            }

            if (other.gameObject.tag == "Heal")
            {
                UpdateHealth(3);
                UpdateAbility(2, m_maxAbility_02);
                UpdateXP(25);
                Destroy(other.gameObject);
            }

            if (other.gameObject.tag == "Mission")
            {
                UpdateXP(50);
            }
        }

        /// <summary>
        /// Method for setting player health then updating UI
        /// </summary>
        /// <param name="healthAdjust"></param>
        public void UpdateHealth(int healthAdjust)
        {
            Debug.Log("Health Updated: " + healthAdjust);
            m_currentHealth += healthAdjust;

            if(m_currentHealth > m_maxHealth)
            {
                m_currentHealth = m_maxHealth;
            }
            else if(m_currentHealth < 0)
            {
                m_currentHealth = 0;
            }

            m_playerUiManager.SetHealth(((float)m_currentHealth / (float)m_maxHealth));
        }

        /// <summary>
        /// Method for setting player XP then updating UI
        /// </summary>
        /// <param name="xpAdjust"></param>
        public void UpdateXP(int xpAdjust)
        {
            Debug.Log("XP Updated: " + xpAdjust);
            if (m_currentLevel < m_maxLevel)
            {
                m_currentXP += xpAdjust;
                if (m_currentXP > m_maxXP)
                {       
                    m_currentLevel++;

                    if (m_currentLevel == m_maxLevel)
                    {
                        m_currentXP = m_maxXP;
                    }
                    else
                    {
                        m_currentXP -= m_maxXP;
                    }
                }
            }

            m_playerUiManager.SetXP(((float)m_currentXP / (float)m_maxXP));
        }

        /// <summary>
        /// Set aim reticle
        /// </summary>
        /// <param name="isAiming"></param>
        public void SetAim(bool isAiming)
        {
            m_playerUiManager.SetAim(isAiming);
        }

        /// <summary>
        /// Method to use specific abilities
        /// </summary>
        /// <param name="ability"></param>
        public void UseAbility(int ability)
        {
            UpdateAbility(ability, -1);
        }

        //Method to update abilities
        private void UpdateAbility(int ability, int adjustment)
        {
            Debug.Log("Ability Updated: " + ability + " adjust: " + adjustment);
            if (ability == 1)
            {
                m_currentAbility_01 += adjustment;

                if (m_currentAbility_01 > m_maxAbility_01)
                {
                    m_currentAbility_01 = m_maxAbility_01;
                }
                else if (m_currentAbility_01 < 0)
                {
                    m_currentAbility_01 = 0;
                }

                if(adjustment < 0)
                {
                    m_currAbilityTime_01 = 0.0f;
                }

                m_playerUiManager.SetAbility01UI(((float)m_currentAbility_01 / (float)m_maxAbility_01));
            }
            else if (ability == 2)
            {
                m_currentAbility_02 += adjustment;

                if (m_currentAbility_02 > m_maxAbility_02)
                {
                    m_currentAbility_02 = m_maxAbility_02;
                }
                else if (m_currentAbility_02 < 0)
                {
                    m_currentAbility_02 = 0;
                }

                m_playerUiManager.SetAbility02UI(m_currentAbility_02);
            }
        }
    }
}