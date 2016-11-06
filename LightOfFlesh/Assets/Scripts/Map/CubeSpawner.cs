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
    public GameObject cubeRouge;
    [SerializeField]
    public int nombreCubeRouge;
    [SerializeField]
    public GameObject cubeBleu;
    [SerializeField]
    public int nombreCubeBleu;

    private Vector2[] posDispoTotale;
    private bool[] posPrises;
    

    // Use this for initialization
    void Start()
    {

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
        for (int i = 0; i < nombreCubeRouge; i++)
        {
            positionCube = randomPlace();
            GetComponent<GameManager>().create(cubeRouge, positionCube);
            //Object obj = Instantiate(cubeRouge, positionCube, Quaternion.identity);

            //items.Add((GameObject)obj);
        }

        for (int i = 0; i < nombreCubeBleu; i++)
        {
            positionCube = randomPlace();
            GetComponent<GameManager>().create(cubeBleu, positionCube);
            //Object obj = Instantiate(cubeBleu, positionCube, Quaternion.identity);

            //items.Add((GameObject)obj);
        }

        //  Vector2 position = new Vector2(0,0);
        // Instantiate(cubeBleu, position, Quaternion.identity);
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