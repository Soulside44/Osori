using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObject : MonoBehaviour
{
    [SerializeField] float speed = 3.0f;
    [SerializeField] float startPosition;
    [SerializeField] float endPosition;

    private void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        if(transform.position.x<=endPosition)
        {
            transform.Translate(-(endPosition - startPosition), 0, 0, 0);
            SendMessage("ChangePosition", SendMessageOptions.DontRequireReceiver);
        }
    }
}
