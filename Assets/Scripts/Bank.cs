using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bank : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Awake()
    {
        // GameManager 이벤트와 연결
        text = GetComponent<TextMeshProUGUI>();
    }

    private void PrintScreen()
    {
        // GameManager에서 정보 받아서 출력
        text.text = "";

        // 만약 넘어온 게 0원이면 게임오버 메시지 출력
    }
}
