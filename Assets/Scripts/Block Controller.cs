using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public static BlockController instance;

    private Vector3 mousePos;
    private GameObject currentBlock;
    private List<GameObject> laidBlocks = new();

    [SerializeField] private BlockSpawner spawner;

    [Header("Walls")]
    [SerializeField] private float minX;
    [SerializeField] private float maxX;

    [SerializeField] private int blockFreezeThreshold;
    void Start()
    {
        instance = this;
    }

    void Update()
    {
        MouseToBlock();
    }
    public void AssignBlock(GameObject newBlock)
    {
        currentBlock = newBlock;
    }
    private void MouseToBlock()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.x = Mathf.Clamp(mousePos.x, minX, maxX);

        if (currentBlock != null)
        {
            currentBlock.transform.position = new Vector2(mousePos.x, currentBlock.transform.position.y);
        }
    }
    public void ReleaseBlock()
    {
        laidBlocks.Add(currentBlock);
        currentBlock = null;

        StartCoroutine(spawner.SpawnBlock());

        if (laidBlocks.Count >= blockFreezeThreshold)
        {
            FreezeBlocks();
        }
    }
    private void FreezeBlocks()
    {
        foreach (GameObject block in laidBlocks)
        {
            if (block == null)
            {
                Debug.Log("null block");
                return;
            }
                

            Rigidbody2D rb = block.GetComponent<Rigidbody2D>();

            if (rb == null)
            {
                Debug.Log("Null rb");
                return;
            }
                
          
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
