using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bank : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Awake()
    {
        // GameManager �̺�Ʈ�� ����
        text = GetComponent<TextMeshProUGUI>();
    }

    private void PrintScreen()
    {
        // GameManager���� ���� �޾Ƽ� ���
        text.text = "";

        // ���� �Ѿ�� �� 0���̸� ���ӿ��� �޽��� ���
    }
}
