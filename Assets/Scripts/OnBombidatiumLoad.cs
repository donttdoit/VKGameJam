using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBombidatiumLoad : MonoBehaviour
{
    private void Awake()
    {
        var player = FindObjectOfType<Player>(true);
        player.transform.position = new Vector3(-1, 1, 0);
        player.GetComponent<Player>()._canMove = false;

        var obj = FindObjectOfType<Bees>(true);
        if (obj != null) obj.gameObject.SetActive(true);

        var checkslot = FindObjectOfType<CheckSlot>(true);
        if(checkslot != null) checkslot.gameObject.SetActive(true);

        var sign = FindObjectOfType<SignToLevel>(true);
        if(sign != null) sign.gameObject.SetActive(false);
    }
    
}
