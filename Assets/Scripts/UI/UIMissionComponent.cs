using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UIMissionComponent : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text m_titleText = null;
        [SerializeField]
        private TMP_Text m_detailsText = null;
        [SerializeField]
        private float MAX_DURATION = 2.0f;

        private float m_duration = 0.0f;


        private void Start()
        {
            m_duration = MAX_DURATION + 0.1f;
            gameObject.SetActive(false);
        }

        private void Update()
        {
            if (m_duration <= MAX_DURATION)
            {
                m_duration += Time.deltaTime;

                if (m_duration > MAX_DURATION)
                {
                    gameObject.SetActive(false);
                }
            }
        }

        /// <summary>
        /// Set Misson Text based on Trigger
        /// </summary>
        /// <param name="title"></param>
        /// <param name="details"></param>
        public void SetMissionText(string title, string details)
        {
            if (!gameObject.activeSelf)
            {
                m_duration = 0.0f;
                m_titleText.SetText(title);
                m_detailsText.SetText(details);
                gameObject.SetActive(true);
            }
        }
    }
}