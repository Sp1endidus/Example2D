using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HeapResearch : MonoBehaviour {


    void Start() {
        var ll1 = new LinkedList<int>();
        ll1.AddFirst(33);
        ll1.AddLast(55);
        ll1.AddLast(77);
        Debug.Log($"{ll1.ElementAt(0)} {ll1.ElementAt(1)} {ll1.ElementAt(2)}");
    }

    void Update() {
        
    }

    public void RunResearch() {

    }
}