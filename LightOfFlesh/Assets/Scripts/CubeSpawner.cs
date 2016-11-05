using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubeSpawner : MonoBehaviour {


    [SerializeField]
    public int hauteur;
    [SerializeField]
    public int longueur;
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
	void Start () {
        int m = 0;
        posDispoTotale = new Vector2[(longueur - 2) * (hauteur - 2)];
        posPrises = new bool[(longueur - 2) * (hauteur - 2)];
        for (int j = 1; j < (hauteur - 1); j++)
       {
            for (int i = 1; i < (longueur - 1); i++)
            {
                posDispoTotale[m] = new Vector2(i, j);
                posPrises[m] = false;
                m++;
            }
        }
        Vector2 positionCube;
        for ( int i = 0; i < nombreCubeRouge; i++)
        {
            positionCube = randomPlace();
            Instantiate(cubeRouge, positionCube, Quaternion.identity);
        }

        for ( int i = 0; i < nombreCubeBleu; i++)
        {
            positionCube = randomPlace();
            Instantiate(cubeBleu, positionCube, Quaternion.identity);
        }

            
	}

    Vector2 randomPlace()
    {
        int i = 0;
        Vector2 position = new Vector2(0,0);
        position.x = Random.Range(1, longueur -1);
        position.y = Random.Range(1, hauteur -1);
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
        while(rienAutour == false)
        {
            if ( estLibre(posDispoTotale[i]) == true)
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
        if ((i % (longueur - 2)) != 0 && posPrises[i - 1] == true )
        {
            compteur++;
        }
        if (((i + 1) % (longueur - 2)) != 0 && posPrises[i + 1] == true )
        {
            compteur++;
        }
        if(((i)-(longueur-2)  >= 0) && posPrises[i - (longueur-2)] == true)
        {
            compteur++;
        }
        if (((i+1) + (longueur - 2)  < ((longueur - 2) * (hauteur - 2))) && posPrises[i + (longueur - 2)] == true) 
        {
            compteur++;
        }

        if (compteur == 0)
            estLibre = true;
        return estLibre;
    }
   
}
