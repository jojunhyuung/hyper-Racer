using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private int gas = 100;
    [SerializeField] private float moveSpeed = 1f;
    
    public int Gas { get => gas; } // Gas 정보

    private void Start()
    {
        StartCoroutine(GasCoroutine());
    }

    IEnumerator GasCoroutine()
    {
        while (true)
        {
            gas -= 10;
            yield return new WaitForSeconds(1f);
            if (gas <= 0) break;
            
        }
        // 게임 종료
        GameManager.Instance.EndGame();
    }
    
    // 자동차 이름 메서드
    public void Move(float direction)
    {
        transform.Translate(Vector3.right * direction * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.5f, 1.5f), 0, transform.position.z);
    }
    
    // 가스 아이템 흭득시 호출되는 메서드

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gas"))
        {
            gas += 30;
            
            //가스 아이템 숨기기;
            other.gameObject.SetActive(false);
        }
    }
}
