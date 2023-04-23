using UnityEngine;

public class OnLevelLoad : MonoBehaviour
{
    private void Awake()
    {
        var player = FindObjectOfType<Player>(true);
        player.transform.position = new Vector3(-1, 1, 0);
        player.GetComponent<Player>()._canMove = false;

        var obj = FindObjectOfType<Bees>(true);
        if (obj != null) obj.gameObject.SetActive(false);

        var checkslot = FindObjectOfType<CheckSlot>(true);
        if(checkslot != null) checkslot.gameObject.SetActive(false);
    }
}