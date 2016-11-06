using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubeSpawner : MonoBehaviour
{


    [SerializeField]
    public float hauteur;
    [SerializeField]
    public float longueur;
    [SerializeField]
    public GameObject BearTrap;
    [SerializeField]
    public int nombreBearTrap;
    [SerializeField]
    public GameObject Gravel;
    [SerializeField]
    public int nombreGravel;
    [SerializeField]
    public GameObject Glass;
    [SerializeField]
    public int nombreGlass;
    [SerializeField]
    public GameObject Hole;
    [SerializeField]
    public int nombreHole;
    [SerializeField]
    public GameObject Key;
    [SerializeField]
    public int nombreKey;

    private Vector2[] posDispoTotale;
    private bool[] posPrises;
    
    private List<Vector2> keyPosistions;

    // Use this for initialization
    void Start()
    {

        keyPosistions = new List<Vector2>();
        keyPosistions.Add(new Vector2(-3.88f, 4.63f));
        keyPosistions.Add(new Vector2(-6.19f, -4.31f));
        keyPosistions.Add(new Vector2(3.11f, -4.31f));
        keyPosistions.Add(new Vector2(6.42f, 6.16f));

        int m = 0;
        posDispoTotale = new Vector2[(int)(longueur - 2) * (int)(hauteur - 2)];
        posPrises = new bool[(int)(longueur - 2) * (int)(hauteur - 2)];
        for (float j = (int)((-hauteur / 2) + 1); j < (int)((hauteur / 2) - 1); j++)
        {
            for (float i = (int)((-longueur / 2) + 1); i < (int)((longueur / 2) - 1); i++)
            {
                posDispoTotale[m] = new Vector2(i, j);
                posPrises[m] = false;
                m++;
            }
        }

        GetComponent<GameManager>().preStart();

        Vector2 positionCube;
        for (int i = 0; i < nombreBearTrap; i++)
        {
            positionCube = randomPlace();
            GetComponent<GameManager>().create(BearTrap, positionCube);
           
        }

        for (int i = 0; i < nombreGravel; i++)
        {
            positionCube = randomPlace();
            GetComponent<GameManager>().create(Gravel, positionCube);

        }

        for (int i = 0; i < nombreGlass; i++)
        {
            positionCube = randomPlace();
            GetComponent<GameManager>().create(Glass, positionCube);

        }
        for (int i = 0; i < nombreHole; i++)
        {
            positionCube = randomPlace();
            GetComponent<GameManager>().create(Hole, positionCube);

        }
        for (int i = 0; i < nombreKey; i++)
        {
            positionCube = keyPosistions[Random.Range(0, 3)];
            GetComponent<GameManager>().create(Key, positionCube);
            
        }



        //  Vector2 position = new Vector2(0,0);
        // Instantiate(Key, position, Quaternion.identity);
        //Debug.Log(posDispoTotale[7] + "et" + posDispoTotale[143]);

        GetComponent<GameManager>().initialize();

    }

    Vector2 randomPlace()
    {
        int i = 0;
        Vector2 position = new Vector2(0, 0);
        position.x = Random.Range((int)((-longueur / 2) + 1), (int)((longueur / 2) - 1));
        position.y = Random.Range((int)(-hauteur / 2) + 1, (int)(hauteur / 2) - 1);
        bool rienAutour = false;
        if (estLibre(position) == true)
        {
            rienAutour = true;
            bool trouve = false;
            while (trouve == false)
            {

                if (posDispoTotale[i] == position)
                {
                    trouve = true;
                    position = posDispoTotale[i];
                }
                else
                {
                    i++;
                }
            }
        }
        while (rienAutour == false)
        {
            if (estLibre(posDispoTotale[i]) == true)
            {
                rienAutour = true;
            }
            else
            {
                i++;
            }

        }

        posPrises[i] = true;
        position = posDispoTotale[i];

        return position;
    }

    bool estLibre(Vector2 position)
    {
        bool estLibre = false;
        int compteur = 0;
        int i = 0;
        bool found = false;
        while (found == false)
        {

            if (posDispoTotale[i] == position)
            {
                found = true;
            }
            else
            {
                i++;
            }
        }

        if (posPrises[i] == true)
        {
            compteur++;
        }
        if ((i % (longueur - 2)) != 0 && posPrises[i - 1] == true)
        {
            compteur++;
        }
        if (((i + 1) % (longueur - 2)) != 0 && posPrises[i + 1] == true)
        {
            compteur++;
        }
        if (((i) - (longueur - 2) >= 0) && posPrises[i - ((int)longueur - 2)] == true)
        {
            compteur++;
        }
        if (((i + 1) + (longueur - 2) < ((longueur - 2) * (hauteur - 2))) && posPrises[i + ((int)longueur - 2)] == true)
        {
            compteur++;
        }

        if (compteur == 0)
            estLibre = true;
        return estLibre;
    }

}