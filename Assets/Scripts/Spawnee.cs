using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnee : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_cube,transform);
        }
    }
}
