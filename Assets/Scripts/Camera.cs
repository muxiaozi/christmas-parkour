using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float m_moveSpeed;
    public bool m_isGameover;

    // Start is called before the first frame update
    void Start()
    {
        m_isGameover = false;
    }

    private void FixedUpdate()
    {
        if (!m_isGameover)
        {
            transform.position += new Vector3(Time.fixedDeltaTime * m_moveSpeed, 0, 0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Game over");
            m_isGameover = true;
        }
    }
}
