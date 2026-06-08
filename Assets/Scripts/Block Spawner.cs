using System.Collections;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] geometry;
    void Start()
    {
        StartCoroutine(SpawnBlock());
    }
    public IEnumerator SpawnBlock()
    {
        yield return new WaitForSecondsRealtime(1f);
        int randomIndex = Random.Range(0, geometry.Length);
        GameObject newObj = Instantiate(geometry[randomIndex], gameObject.transform.position, Quaternion.identity);
        BlockController.instance.AssignBlock(newObj);
    }
}
