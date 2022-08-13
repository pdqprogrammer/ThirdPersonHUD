using Player;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace Debugging
{
    public class InputDebugHandler : MonoBehaviour
    {
        [SerializeField]
        private PlayerController m_playerController;

        private DebuggingInput m_debugInput;

#if UNITY_EDITOR
        private void Awake()
        {
            //Setup inputs for debugging player UI and functionality -- remove from real game
            m_debugInput = new DebuggingInput();
            m_debugInput.Debug.Enable();
            m_debugInput.Debug.Heal.performed += HealAction;
            m_debugInput.Debug.Hurt.performed += HurtAction;
            m_debugInput.Debug.Ability01.performed += Ability01Action;
            m_debugInput.Debug.Ability02.performed += Ability02Action;

            m_debugInput.Debug.Aim.performed += SetAim;
            m_debugInput.Debug.Aim.canceled += SetAim;
        }

        //Functions for all of the Debug inputs
        #region debugActions
        private void HealAction(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                m_playerController.UpdateHealth(1);
            }
        }

        private void HurtAction(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                m_playerController.UpdateHealth(-1);
            }
        }

        private void Ability01Action(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                m_playerController.UseAbility(1);
            }
        }

        private void Ability02Action(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                m_playerController.UseAbility(2);
            }
        }

        private void SetAim(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                m_playerController.SetAim(true);
            }
            else if(context.canceled)
            {
                m_playerController.SetAim(false);
            }
        }
        #endregion
    }
#endif
}