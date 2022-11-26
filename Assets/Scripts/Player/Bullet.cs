using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float flySpeed;
    public BullletPooling mypool;
    [SerializeField] float TimeExist = 1;
    // Start is called before the first frame update
    private void OnEnable()
    {
        Invoke(nameof(Recursion), TimeExist);
    }
    void Recursion()
    {
        mypool.DeQueue(this);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward*flySpeed*Time.deltaTime;
    }
    
}
