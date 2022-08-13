using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIBarComponent : MonoBehaviour
    {
        [SerializeField]
        private RectTransform m_progressRectTransform;
        [SerializeField]
        private Image m_progressIconImage;

        private Vector2 m_originalProgressSize = Vector2.zero;

        private void Awake()
        {
            m_originalProgressSize = m_progressRectTransform.sizeDelta;
        }

        /// <summary>
        /// Set Bar Icon sprite
        /// </summary>
        /// <param name="newBarSprite"></param>
        public void SetBarImage(Sprite newBarSprite)
        {
            if (m_progressIconImage != null)
            {
                m_progressIconImage.sprite = newBarSprite;
            }
        }

        /// <summary>
        /// Update health bar
        /// </summary>
        /// <param name="health"></param>
        public void SetProgressBar(float percentage)
        {
            var currBar = m_originalProgressSize;
            currBar.x = currBar.x * percentage;
            m_progressRectTransform.sizeDelta = currBar;

        }
    }
}