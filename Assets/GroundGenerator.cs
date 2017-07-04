using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour {
    //地面の第1層のprefab
    public GameObject GroundPrefab;
    //地面の第2層以降のprefab(1)
    public GameObject Block1Prefab;
    //地面の第2層以降のprefab(2)
    public GameObject Block2Prefab;

    //横方向のマス数
    private int yNum = 5;
    //第1層のY軸position
    private float groundYPos = -0.35f;
    //ゲーム起動時に第何層までのブロックを作成するか
    private int blockDep = 8;
    //unityちゃんの最深到達記録
    private float maxDep;

	// Use this for initialization
	void Start () {
        
        for (int i = 0; i < yNum; i++)
        {
            //地面の第1層を生成
            GameObject ground = Instantiate(GroundPrefab) as GameObject;
            ground.transform.position = new Vector2(-2.2f + i * 1.1f, groundYPos);
        }
        //地面の第2～8層を生成
        float groundHeight = GameObject.Find("GroundPrefab(Clone)").GetComponent<SpriteRenderer>().bounds.size.y;//groundオブジェクトの高さを取得
        for (int i = 0; i < blockDep-1; i++)
        {
            groundYPos -= groundHeight;
            for (int j = 0; j < yNum; j++)
            {
                int num = Random.Range(1, 10);
                if (num >= 6)//生成した乱数を元にブロックの種類を決定
                {
                    GameObject block1 = Instantiate(Block1Prefab) as GameObject;
                    block1.transform.position = new Vector2(-2.2f + j * 1.1f, groundYPos);
                }
                else
                {
                    GameObject block2 = Instantiate(Block2Prefab) as GameObject;
                    block2.transform.position = new Vector2(-2.2f + j * 1.1f, groundYPos);
                }
            }
        }


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
