using System;
using System.Text;
using UnityEditor.UIElements;
using UnityEngine;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        public static UIController instance;

        [SerializeField] private Transform _loginUI;
        [SerializeField] private Transform _teacherUI;
        [SerializeField] private ModalWindowPanel _modalWindow;
        [SerializeField] private ModalWindowPanel _modalWindow2;
        public ModalWindowPanel modalWindow => _modalWindow;
        public ModalWindowPanel modalWindow2 => _modalWindow2;

        private void Awake()
        {
            instance = this;
        }

        public void checkPass(string requiredPass)
        {
            string enteredPass = modalWindow.GetInputText();
            
            // cut out the weirdest spacing character ever :(
            // enteredPass = enteredPass.Substring(0, enteredPass.Length - 1);
            
            // Debug.Log(String.Format("req pass: '{0}'; len: {2} \nact pass: '{1}'; len: {3}", requiredPass, enteredPass, requiredPass.Length, enteredPass.Length));
            //
            // if (enteredPass.Length != requiredPass.Length)
            //     Debug.LogError("Required and provided passwords have different length");
            //
            // for (int i = 0; i < enteredPass.Length; i++)
            // {
            //     Debug.Log(String.Format("{0}--{1}--{2}", i.ToString(), enteredPass[i], ((int)enteredPass[i]).ToString()));
            //     if (enteredPass[i] != requiredPass[i]) {
            //         Debug.LogError("Difference at character: " + i+1);
            //     }
            // }
            
            if (enteredPass.Equals(requiredPass))
            {
                _loginUI.gameObject.SetActive(false);
                _teacherUI.gameObject.SetActive(true);
                Debug.Log("passes equal");
            }
            else
            {
                modalWindow2.ShowModal("Parolă incorectă: " + enteredPass, 
                    "Vă rugăm, reîncercați cu parola corectă", 
                    () => {}, "OK")
                    .Show();
                Debug.Log("passes different");
            }
        }
    }
}
