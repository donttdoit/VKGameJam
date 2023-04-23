using UnityEngine;

public class OnLevel1Load : MonoBehaviour
{
    private void Awake()
    {
        var player = FindObjectOfType<Player>();
        player.transform.position = new Vector3(-1, 1, 0);
        player.GetComponent<Player>()._canMove = false;

        var obj = FindObjectOfType<Bees>();
        if (obj != null) obj.gameObject.SetActive(false);

        var checkslot = FindObjectOfType<CheckSlot>();
        if(checkslot != null) checkslot.gameObject.SetActive(false);
    }
}