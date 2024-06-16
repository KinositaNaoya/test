using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinositaNaoya : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("éÑÇÕç◊í∑Ç¢ì§ïÖÇ≈Ç∑ÇÌÅIÅI");
        
    }
    float sperd = 0.1f;
    void Update()
    {
            Vector3 Pos = transform.position;
            Pos.y += sperd;
            if (Pos.y < -2.5f){ sperd = 0.01f; }
            if (Pos.y > 2.5f) { sperd = -0.01f; }
            transform.position = Pos;
    }
}
