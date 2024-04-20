using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRandomizer : MonoBehaviour
{
    [SerializeField] Transform[] positions;
    [SerializeField] GameObject[] platforms;
    [SerializeField] GameObject[] instantiatedPlatforms;
    [SerializeField] GameObject bossPrefab;
    [SerializeField] Player player;
    bool bossFight;
    int cont = 1;
    // Start is called before the first frame update
    void Start()
    {
        RandomizeArray();
        instantiatedPlatforms = new GameObject[platforms.Length];
        instantiatedPlatforms[0] = platforms[0]; //posicionar a base como 0 para que seja deletada
        instantiatedPlatforms[1] = Instantiate(platforms[1], positions[1].position, Quaternion.identity); //começando contagem
    }

    // Update is called once per frame
    void Update()
    {
        if (!bossFight)
        {
            if (player.transform.position.x >= positions[cont].position.x)
            {
                SwitchPlatforms();
            }
        }
    }

    void RandomizeArray()
    {
        int n = platforms.Length;
        while (n > 1) 
        {
            int k = Random.Range(1, n--); //comeca em 1 para nao alterar a base
            GameObject temp = platforms[n];
            platforms[n] = platforms[k];
            platforms[k] = temp;
        }
    }

    void SwitchPlatforms()
    {
        Destroy(instantiatedPlatforms[cont-1]); //deleta a anterior
        cont++;
        if (cont < platforms.Length) //se o contador se manter menor que o maximo ainda ha plataformas para colocar
        {
            instantiatedPlatforms[cont] = Instantiate(platforms[cont], positions[cont].position, Quaternion.identity);
        }
        else
        {
            StartBossFight();
        }
    }

    void StartBossFight()
    {
        bossFight = true;
        Instantiate(bossPrefab, positions[positions.Length - 1].position, Quaternion.identity);
    }
}
