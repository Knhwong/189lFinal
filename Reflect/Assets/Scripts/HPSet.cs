using UnityEngine;
using UnityEngine.UI;

public class HPSet : MonoBehaviour
{

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Text hpText;

    void Update()
    {
        this.hpText.text =  player.GetComponent<PlayerController>().GetCurrentHealth().ToString();
    }
}