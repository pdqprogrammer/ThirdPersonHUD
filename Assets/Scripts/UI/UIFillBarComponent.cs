using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIFillBarComponent : MonoBehaviour
    {
        [SerializeField]
        private RectTransform m_prefabAbility02 = null;
        [SerializeField]
        private RectTransform m_progressRectTransform;

        /// <summary>
        /// Set fill bar objects based on current amount on screen and expected amount
        /// </summary>
        /// <param name="fillCount"></param>
        public void SetBarFill(int fillCount)
        {
            while(m_progressRectTransform.childCount != fillCount)
            {
                if(fillCount > m_progressRectTransform.childCount)
                {
                    Instantiate(m_prefabAbility02, m_progressRectTransform);
                }
                else if (fillCount < m_progressRectTransform.childCount)
                {
                    var childObject = m_progressRectTransform.GetChild(0);
                    childObject.parent = null;
                    Destroy(childObject.gameObject);
                }
            }
        }
    }

}