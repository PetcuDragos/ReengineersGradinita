using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ChangeActiveUIOnClick : MonoBehaviour
    {
        public GameObject fromUI;
        public GameObject toUI;
    
        // Start is called before the first frame update
        void Start()
        {
            Button btn = GetComponent<Button>();
            btn.onClick.AddListener(TaskOnClick);
        }

        void TaskOnClick()
        {
            fromUI.SetActive(false);
            toUI.SetActive(true);
        }
    }
}
