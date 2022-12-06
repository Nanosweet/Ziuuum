using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] List<Transform> waypoint;
    [SerializeField] float _enemyMoveSpeed = 0f;
    [SerializeField] GameObject exploOnDeath;

    private bool _switching = false;
    void Start()
    {
        //Vector3 pos1 = waypoints[0].transform.position;
        //Vector3 pos2 = waypoints[1].transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        
        
    }

    private void FixedUpdate()
    {
        if (!_switching)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoint[0].position, _enemyMoveSpeed * Time.deltaTime);

        }
        else if (_switching)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoint[1].position, _enemyMoveSpeed * Time.deltaTime);
        }

        if(transform.position == waypoint[1].position)
        {
            _switching = false;
        }
        else if (transform.position == waypoint[0].position)
        {
            _switching = true;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            // Destroy
            Destroy();
        }
    }

    private void Destroy()
    {        
        Destroy(gameObject);
        GameObject explosion = Instantiate(exploOnDeath, transform.position, transform.rotation);
    }
}
