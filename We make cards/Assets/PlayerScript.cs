using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Netcode;
using UnityEngine;

public class PlayerScript : NetworkBehaviour
{
    private NetworkVariable<int> number = new NetworkVariable<int>(1, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);
    // Start is called before the first frame update
    public override void OnNetworkSpawn()
    {
        number.OnValueChanged += (int previousValue, int newValue) =>
        {
            Debug.Log(OwnerClientId + "; randomNumber; " + number.Value);
        };
    }
    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;
        if (Input.GetKey(KeyCode.Space)) 
        {
            number.Value = Random.Range(0, 100);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * 5f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * 5f * Time.deltaTime;
        }
    }
}
