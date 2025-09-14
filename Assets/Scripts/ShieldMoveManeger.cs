using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldMoveManeger : MonoBehaviour
{

    private Transform player;
    float _time;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Collider>(); player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        // ƒvƒŒƒCƒ„[‚É’Ç]
        transform.position = player.position;

        // ‰ñ“]ˆ—
        transform.rotation = Input.GetKey(KeyCode.Space)
            ? Quaternion.Euler(0, -90, 0)
            : Quaternion.Euler(0, 0, 0);
        if (_time > -0.5 && _time < 0.5)
        {
            JustGuardManager.SemiJust();
        }
        if (_time > -0.1 && _time < 0.1)
        {
            JustGuardManager.Just();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {

    }
}
