using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public float playerSpeed = 1500;
    public float directionalSpeed = 20;
    public GameObject EnemyCube, FriendlyCube, StackCube;
    private Stack<GameObject> cubeStack;

    // Start is called before the first frame update
    void Start()
    {
        cubeStack = new Stack<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(Mathf.Clamp(gameObject.transform.position.x + moveHorizontal, -3f, 3f), gameObject.transform.position.y, gameObject.transform.position.z), directionalSpeed * Time.deltaTime);

        GetComponent<Rigidbody>().velocity = Vector3.forward * playerSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyCube")
        {
            if (cubeStack.Count > 0)
            {
                cubeStack.Pop();
                Destroy(gameObject.transform.GetChild(gameObject.transform.childCount - 1).gameObject);
            }
        }
        if (other.gameObject.tag == "FriendlyCube")
        {
            cubeStack.Push(other.gameObject);
            transform.DOJump(new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y + 1.1f, other.gameObject.transform.position.z), 1, 1, 1);
            
        }
    }
}
