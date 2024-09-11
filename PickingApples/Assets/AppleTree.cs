using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    // Prefab for instantiating apples
    public GameObject applePrefab;

    // speed at which the apple tree moves
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float changeDirChance = 0.1f;
    public float appleDropDelay = 1f;
    public float rotationSpeed = 30f; // Speed of rotation in degrees per second

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // start dropping apples
        Invoke("DropApple", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        // basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;



        // changing direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); // Move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
        else if (Random.value < changeDirChance)
        {
            speed *= -1;
        }
    }  
    void FixedUpdate()
      {
        if (Random.value < changeDirChance)
        {
            speed *= -1;
        }

      }
    void DropApple()
        {
            GameObject apple = Instantiate<GameObject>(applePrefab);
            apple.transform.position = transform.position; //place that apple on the apple tree
            Invoke("DropApple", appleDropDelay);
        }
    }
