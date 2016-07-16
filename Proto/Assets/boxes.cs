using UnityEngine;
using System.Collections;

public class boxes : MonoBehaviour {

    public GameObject[] bxs_R; //오른쪽 박스 배열
    public GameObject[] bxs_L; //왼쪽 박스 배열
                        
                            //Swap을 위한 임시 변수들
    GameObject temp_bxs_R; //temp object
    GameObject temp_bxs_L; //temp object
    Vector3 temp_pos_R; //temp Vector3
    Vector3 temp_pos_L; //temp Vector3
                    
    Color[] base_col= { Color.blue, Color.black }; //기본 칼라
    int random_seed;    //칼라 선택을 위한 랜덤 시드

    Score _Score;   //Score 변경을 위한 object

    // Use this for initialization
    void Start()
    {
        //Score object를 찾아 _Score에 저장.
        _Score = GameObject.FindObjectOfType<Score>();

        
        for (int i = 0; i < 12; i++)    //12개의 박스의 색깔을 랜덤으로 초기화
        {
            random_seed = Random.Range(0, 2);   //0 또는 1을 random_seed에 저장
            
            //왼쪽 오른쪽 중복된 색깔이 나오지 않도록 아래와 같이 구현
            bxs_L[i].transform.GetComponent<SpriteRenderer>().color = base_col[random_seed];    // random_seed가 0이면 Color.blue , 1이면 Color.black
            bxs_R[i].transform.GetComponent<SpriteRenderer>().color = base_col[1- random_seed]; // random_seed가 0이면 Color.black , 1이면 Color.blue        
        }

    }

    public void LClicked()      //왼쪽 버튼 클릭 시 호출되는 함수
    {
        Debug.Log('L');
        if (bxs_L[0].transform.GetComponent<SpriteRenderer>().color == base_col[0])     //왼쪽 블럭 중 가장아래(1층) 블럭의 색깔이 blue일 때 실행
        {
            Boxes_down();          //Boxes_down() 호출
            _Score.value += 100;   // 100점 획득
        }
        else _Score.value -= 100f; //왼쪽 블럭 중 가장아래(1층) 블럭의 색깔이 black 일 때 -100점
    }

    public void RClicked()    //오른쪽 버튼 클릭 시 호출되는 함수
    {
        Debug.Log('R');
        if (bxs_R[0].transform.GetComponent<SpriteRenderer>().color == base_col[0])     //오른쪽 블럭 중 가장아래(1층) 블럭의 색깔이 blue일 때 실행
        {
            Boxes_down();         //Boxes_down() 호출
            _Score.value += 100f; // 100점 획득
        }
        else _Score.value -= 100f; //오른쪽 블럭 중 가장아래(1층) 블럭의 색깔이 black 일 때 -100점
    }


    // 박스를 한칸씩 아래로 내리고, object를 swap하는 함수.
    // 가장 아래(index=0) box는 가장 위(index=11)로 옮기고 색깔을 랜덤으로 재생성
    void Boxes_down()  
    {
        temp_pos_L = bxs_L[11].transform.position;  //swap을 위해 bxs_L[11]과 bxs_R[11]의 위치를 임시 저장
        temp_pos_R = bxs_R[11].transform.position;

        for (int i = 11; i >= 0; i--)   //최상위 box부터 아래로 접근
        {
            if (i == 0) //최하위(index=0) box는 최상위(index=11)로 옮김
            {
                bxs_L[i].transform.position = temp_pos_L;
                bxs_R[i].transform.position = temp_pos_R;

                random_seed = Random.Range(0, 2);       //최상위로 옮겨진 box 색깔 랜덤으로 재생성
                bxs_L[i].transform.GetComponent<SpriteRenderer>().color = base_col[random_seed];
                bxs_R[i].transform.GetComponent<SpriteRenderer>().color = base_col[1 - random_seed];
            }
            else
            {
                bxs_L[i].transform.position = bxs_L[i - 1].transform.position;  //최하위 이외의 box들은 1칸씩 아래로 이동
                bxs_R[i].transform.position = bxs_R[i - 1].transform.position;
            }
        }

        //여기까지는 단순히 box의 position만 변경해 준 부분이고, 아래는 옮겨진 위치에 따른 bxs_L, bxs_R의 참조 object를 swap해주는 부분

        //즉, 아래부터 0-1-2-3-4-5-6-7-8-9-10-11 순으로 되어있던 box가 위에서 위치 변경 후,
        //현재는 아래부터 1-2-3-4-5-6-7-8-9-10-11-0 으로 되어있으므로,
        //다시 0-1-2-3-4-5-6-7-8-9-10-11 순으로 object 참조를 swap해주는 부분

        temp_bxs_L = bxs_L[0];  //swap을 위한 임시 object 저장
        temp_bxs_R = bxs_R[0];  // bxs_L[0]과 bxs_R[0]은 위에서 위치를 옮겼기 때문에 현재 최상위에 있음

        for (int i = 0; i <12; i++) //index 0 부터 접근
        {
            if (i == 11)    //index가 11일 때, 현재 최상위에 위치한 box 0번을 저장
            {
                bxs_L[i] = temp_bxs_L;
                bxs_R[i] = temp_bxs_R;
            }
            else            //각 index에 옮겨진 box들을 저장
            {
                bxs_L[i] = bxs_L[i+1];  
                bxs_R[i] = bxs_R[i+1];
            }
        }
    }
}
