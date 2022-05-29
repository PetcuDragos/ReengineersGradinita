using UnityEngine;

namespace GameState
{
    public class ResetGameBackOnActive : MonoBehaviour
    {
        private bool _firstActive = true;
        private void OnEnable()
        {
            Debug.Log($"{gameObject.name} - OnEnable");
            if (!_firstActive)
            {
                GameManager.Instance.ResetGame();
            }
            _firstActive = false;
        }
    }
}
