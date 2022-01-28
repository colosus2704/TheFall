using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PooledItems // Esta clase serivrá para identificar cada lista
{
    public string Name;             // El identificador de la lista
    public GameObject objectToPool; // El objeto que queremos multiplicar
    public int amount;              // La cantidad de intancias iniciales
}

public class PoolingManager : MonoBehaviour
{
    private static PoolingManager _instance;

    public static PoolingManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PoolingManager>();
            }
            return _instance;
        }
    }

    [SerializeField]
    private List<PooledItems> pooledLists = new List<PooledItems>();


    // _items es un Dictionary, guarda parejas de datos: nombre-lista de objetos
    // Este Dictionary permite buscar de forma muy rápida un objeto por su nombre
    [SerializeField]
    private Dictionary<string, List<GameObject>> _items = new Dictionary<string, List<GameObject>>();

    void Awake()
    {
        for (int i = 0; i < pooledLists.Count; i++) // Para cada lista de objetos
        {
            PooledItems l = pooledLists[i];
            _items.Add(l.Name, new List<GameObject>()); // creamos una entrada en el Dictionary
                                                        // y
            for (int j = 0; j < l.amount; j++)           // añadimos las copias
            {
                GameObject tmp;
                tmp = Instantiate(l.objectToPool);  // Aquí creamos la copia
                tmp.SetActive(false);               // la desactivamos
                _items[l.Name].Add(tmp);            // y la añadimos a la lista
            }
        }
    }

    public GameObject GetPooledObject(string name)  // Para obtener una copia es necesario especificar el
    {                                               // nombre de la lista de donde lo vamos a obtener
        List<GameObject> tmp = _items[name];
        for (int i = 0; i < tmp.Count; i++)
        {
            if (!tmp[i].activeInHierarchy)
            {
                return tmp[i];
            }
        }
        return null;
    }
}