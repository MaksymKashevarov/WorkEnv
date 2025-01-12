using System.Collections.Generic;
using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    [SerializeField] private float coolDownLevel = 1.0f;
    [SerializeField] private List<GameObject> _items = new List<GameObject>();
    private float _time;


    public bool isCoolDowned()
    {
        if (_time > 0)
        {
            CoolDown();
            return true;
        }
        else
        {
            _time = 0;
            return false;
        }
    }

    public void CoolDown()
    {
        _time -= coolDownLevel * Time.deltaTime;
    }

    public void SpawnItem()
    {
        _time = Random.Range(0f, 3f);
        int _index = Random.Range(0, _items.Count);

        Instantiate(_items[_index], gameObject.transform.position, Quaternion.identity);

        _index = 0;
    }

    private void Update()
    {
        if (!isCoolDowned()) 
            SpawnItem();

    }

}
