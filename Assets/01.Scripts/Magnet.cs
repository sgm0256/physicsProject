using UnityEngine;
using DG.Tweening;

public class Magnet : MonoBehaviour
{
    [SerializeField]
    private Transform spawnTrm;


    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            transform.DOMoveY(transform.position.y - 2.5f, 0.2f);
        }

        if(transform.position.y <= -6.5f)
        {
            transform.position = spawnTrm.position;
        }
    }
}
