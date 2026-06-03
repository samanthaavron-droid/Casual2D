using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] geometry;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnRate; //in seconds

    private float dt;
    private Vector2 mousePos;
    void Start()
    {
        InvokeRepeating("SpawnBlock", 1, spawnRate);
    }
    void Update()
    {
        dt = Time.deltaTime;
        mousePos = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        mousePos.y = 0;
    }
    private void MousePosUpdate()
    {

    }
    private void SpawnBlock()
    {
        int randomIndex = Random.Range(0, geometry.Length);
        Instantiate(geometry[randomIndex], spawnPoint.position, Quaternion.identity);
    }
}
