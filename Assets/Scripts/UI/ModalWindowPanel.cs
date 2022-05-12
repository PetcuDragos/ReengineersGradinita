using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ModalWindowPanel : MonoBehaviour
    {
        [Header("Header")]
        [SerializeField] private Transform _headerArea;
        [SerializeField] private TextMeshProUGUI _headerTitle;

        [Header("Content")]
        [SerializeField] private Transform _contentArea;
        [SerializeField] private Transform _horizontalLayoutArea;
        [SerializeField] private TextMeshProUGUI _contentText;
        [SerializeField] public TMP_InputField _inputField;

        [Header("Footer")]
        [SerializeField] private Transform _footerArea;
        [SerializeField] private Button _confirmButton;
        [SerializeField] private Button _declineButton;
        [SerializeField] private Button _alternateButton;

        private Action onConfirmCallback;
        private Action onDeclineCallback;
        private Action onAlternateCallback;

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    
        public void Confirm()
        {
            onConfirmCallback?.Invoke();
            Close();
        }

        public void Decline()
        {
            onDeclineCallback?.Invoke();
            Close();
        }

        public void Alternate()
        {
            onAlternateCallback?.Invoke();
            Close();
        }

        public string GetInputText()
        {
            return _inputField.text;
        }

        public ModalWindowPanel ShowModal(string title, string message,
            Action confirmAction, string confirmText = "Confirm",
            Action declineAction = null, string declineText = "Decline",
            Action alternateAction = null, string alternateText = "Cancel")
        {
            _inputField.gameObject.SetActive(false);
            
            bool hasTitle = !string.IsNullOrEmpty(title);
            _headerArea.gameObject.SetActive(hasTitle);
            _headerTitle.text = title;

            _contentText.text = message;

            onConfirmCallback = confirmAction;
            _confirmButton.GetComponentInChildren<TMP_Text>().text = confirmText;

            bool hasDecline = declineAction != null;
            _declineButton.gameObject.SetActive(hasDecline);
            _declineButton.GetComponentInChildren<TMP_Text>().text = declineText;
            onDeclineCallback = declineAction;

            bool hasAlternate = alternateAction != null;
            _alternateButton.gameObject.SetActive(hasAlternate);
            _alternateButton.GetComponentInChildren<TMP_Text>().text = alternateText;
            onAlternateCallback = alternateAction;
            
            return this;
        }

        public ModalWindowPanel WithInput()
        {
            _inputField.text = "";
            _inputField.gameObject.SetActive(true);
            _inputField.ForceLabelUpdate();

            return this;
        }

        public void FocusInput()
        {
            UIController.instance.modalWindow._inputField.Select();
            UIController.instance.modalWindow._inputField.ActivateInputField();
        }
    }
}
