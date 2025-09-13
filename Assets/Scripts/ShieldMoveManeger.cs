using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldMoveManeger : MonoBehaviour
{
    bool _isMove = false;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Collider>(); player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // ÉvÉåÉCÉÑÅ[Ç…í«è]
        transform.position = player.position;

        // âÒì]èàóù
        transform.rotation = Input.GetKey(KeyCode.Space)
            ? Quaternion.Euler(0, -90, 0)
            : Quaternion.Euler(0, 0, 0);
    }


    private void OnCollisionEnter(Collision collision)
    {

    }
}
