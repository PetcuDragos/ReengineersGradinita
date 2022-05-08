using System;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class ModalWindowTrigger : MonoBehaviour
    {
        public string title;
        public string message;
        // public bool triggerOnEnable;

        public UnityEvent onContinueEvent;
        public UnityEvent onCancelEvent;
        // public UnityEvent onAlternateEvent;

        public void TriggerModalWithInput()
        {
            // if (!triggerOnEnable) return;

            Action continueCallback = null;
            Action cancelCallback = null;
            Action alternateCallback = null;

            if (onContinueEvent.GetPersistentEventCount() > 0)
                continueCallback = onContinueEvent.Invoke;
            if (onCancelEvent.GetPersistentEventCount() > 0)
                cancelCallback = onCancelEvent.Invoke;
            // if (onAlternateEvent.GetPersistentEventCount() > 0)
            //     alternateCallback = onAlternateEvent.Invoke;

            UIController.instance.modalWindow
                .ShowModal(title, message,
                    continueCallback, "OK",
                    () => { }, "Anulează")
                .WithInput()
                .Show();
                
            UIController.instance.modalWindow.FocusInput();
        }
    }
}
