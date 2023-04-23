using UnityEngine;

public class QueenBee : MonoBehaviour
{
    [SerializeField] private Dialog _dialog;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            _dialog.OpenDialog();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            _dialog.CloseDialog();
        }
    }
}
