using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Area{
  public  Transform upperBound;
  public  Transform lowerBound;
  public  Transform rightBound;
  public  Transform leftBound;
    }
[System.Serializable]
public class MinionInfo {

}
public class MinionManager : MonoBehaviour
{
    public GameObject miniona;
    public Area rightSector;
    public Area leftSector;

    public List<float[]> minionsInfo { get; set; } 
    void Start()
    {
        if (GameManager.newGame) {
        minionsInfo = new List<float[]>();       
        }

    } 
   public void SpawnMinionaRandomly() {
        int num = Random.Range(0, 2);
        float x;
        float y;
        
        Vector2 position;
        if (num == 0)
        {
            x = Random.Range(leftSector.leftBound.position.x, leftSector.rightBound.position.x);
            y = Random.Range(leftSector.lowerBound.position.y, leftSector.upperBound.position.y);
            
        }
        else {
            x = Random.Range(rightSector.leftBound.position.x, rightSector.rightBound.position.x);
            y = Random.Range(rightSector.lowerBound.position.y, rightSector.upperBound.position.y);
        }

        minionsInfo.Add(new float[2] { x, y });
        position = new Vector2(x, y);
        SpawnMiniona(position);
    }

    public void SpawnMiniona(Vector2 position) {
        Instantiate(miniona, position, Quaternion.identity);
    }
}
