using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    private float delta = 0;
    public GameObject arrowPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > 1.0f)
        {
            this.delta = 0;
            //ȭ��ǥ ���� 
            var arrowGo = Instantiate<GameObject>(this.arrowPrefab);
            var arrowController = arrowGo.GetComponent<ArrowController>();
            var randSpeed = Random.Range(1, 3);
            var randPosX = Random.Range(-8f, 9f);
            arrowController.Init(randSpeed, new Vector3(randPosX, 7, 0));
        }
    }
}
