using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiControler : MonoBehaviour
{
    public bool danhTruoc;
    private long[] MangTanCong = new long[7] { 0, 3, 24, 192 ,1536,12288,98304};//x8
    private long[] MangPhongThu = new long[7] { 0, 1, 9, 81, 729, 6561, 59049 };//x9
    // Start is called before the first frame update
    void Start()
    {

        if (danhTruoc)
        {
            DanhCo(7, 7);
        }   
    }

    private void DanhCo(int v1, int v2)
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
