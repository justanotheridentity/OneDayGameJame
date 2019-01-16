using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnForm : MonoBehaviour {

    //Sprite mettre
    public Sprite blockSprite; //default

    public Sprite mur;
    public Sprite superMur;
    public Sprite caserne;
    public Sprite superCaserne;

    [Header("A IMPORTER DE GRILLE")]
    public int largeur = 6;
    public int hauteur = 14;

    //Variables
    private int largeurTemp;
    private int hauteurTemp;

    private Vector4 bordure;
    private float side;
    private string nom;
    private GameObject piece;

    private int randomBlock;

    private string[] stringPiece = new string[] {"I","T","J","L","O","Z","S"};
   

    private GameObject block;
    private Vector2 LastBlockPostion;

    float position;

	// Use this for initialization
	void Start ()
    {
        bordure = blockSprite.border;
        side = bordure.x;
        CreateBlock(0.95f, 0, 0);
    }
	
   private GameObject ChooseBlock (GameObject pieceParent , int numero)
   {
        randomBlock = Random.Range(0, 6);

        switch(randomBlock)
        {
            case 0:
                block = new GameObject("block" + numero.ToString() + "mur");
                SpriteRenderer rendererA = block.AddComponent<SpriteRenderer>();
                rendererA.sprite = mur;
                block.transform.parent = pieceParent.transform;

                BlockScript blockScriptA =block.AddComponent<BlockScript>();
                blockScriptA.type = 1;

                break;
            case 1:
                block = new GameObject("block" + numero.ToString() + "superMur");
                SpriteRenderer rendererB = block.AddComponent<SpriteRenderer>();
                rendererB.sprite = superMur;
                block.transform.parent = pieceParent.transform;

                BlockScript blockScriptB = block.AddComponent<BlockScript>();
                blockScriptB.type = 2;

                break;
            case 2:
                block = new GameObject("block" + numero.ToString() + "caserne");
                SpriteRenderer rendererC = block.AddComponent<SpriteRenderer>();
                rendererC.sprite = caserne;
                block.transform.parent = pieceParent.transform;

                BlockScript blockScriptC = block.AddComponent<BlockScript>();
                blockScriptC.type = 3;

                break;
            case 3:
                block = new GameObject("block" + numero.ToString() + "superCaserne");
                SpriteRenderer rendererD = block.AddComponent<SpriteRenderer>();
                rendererD.sprite = superCaserne;
                block.transform.parent = pieceParent.transform;

                BlockScript blockScriptD = block.AddComponent<BlockScript>();
                blockScriptD.type = 4;
                break;
            default:
                block = new GameObject("block" + numero.ToString() + "base");
                SpriteRenderer rendererE = block.AddComponent<SpriteRenderer>();
                rendererE.sprite = blockSprite;
                block.transform.parent = pieceParent.transform;

                BlockScript blockScriptE = block.AddComponent<BlockScript>();
                blockScriptE.type = 0;
                break;
        }
        
        return block;
   }



    public void CreateBlock (float espacement, float xPos, float yPos)
    {
        string form = stringPiece[Random.Range(0, stringPiece.Length)];
        if (form == "I")
        {
            piece = new GameObject("pieceI");
            piece.transform.position = new Vector2(xPos, yPos);
            for (int i = 0; i < 3; i++)
            {
                //nom = "block" + i.ToString();
                block = ChooseBlock(piece, i);
                BlockScript blockScriptPos = block.GetComponent<BlockScript>();

                if (i==0)
                {
                    block.transform.position = piece.transform.position;
                    largeurTemp = (int)Mathf.Ceil(largeur / 3);
                    hauteurTemp = hauteur;
                    blockScriptPos.position = new Vector2(hauteurTemp, largeurTemp);
                    //position = largeur /3 ;(arrondi)
                    //on le met dans la grille

                    //position =  Mathf.Ceil(position);

                }
                else
                {
                    
                    block.transform.position = new Vector2(LastBlockPostion.x + side + espacement, LastBlockPostion.y);
                    blockScriptPos.position = new Vector2(hauteurTemp + 1, largeurTemp);
                    //position ++;
                    //on met le block dans la grille
                }

                LastBlockPostion = block.transform.position;

                

            }

        }
        else if (form == "T")
        {
            piece = new GameObject("pieceT");
            piece.transform.position = new Vector2(xPos, yPos);
            for (int i = 0; i < 4; i++)
            {
                block = ChooseBlock(piece, i);
                BlockScript blockScriptPos = block.GetComponent<BlockScript>();
                switch (i)
                { 
                    case 0:
                        block.transform.position = piece.transform.position;
                        largeurTemp = (int)Mathf.Ceil(largeur / 3);
                        hauteurTemp = hauteur;
                        blockScriptPos.position = new Vector2(hauteurTemp, largeurTemp);
                        //position = largeur /3 ;(arrondi)
                        //on le met dans la grille
                        //position =  Mathf.Ceil(position);
                        break;
                    case 2:
                        block.transform.position = new Vector2(LastBlockPostion.x , LastBlockPostion.y + side + espacement);
                        blockScriptPos.position = new Vector2(hauteurTemp, largeurTemp + 1);
                        break;
                    case 3:
                        block.transform.position = new Vector2(LastBlockPostion.x + side + espacement, LastBlockPostion.y - side - espacement);
                        blockScriptPos.position = new Vector2(hauteurTemp +1 , largeurTemp - 1);
                        break;
                    default:
                        
                        block.transform.position = new Vector2(LastBlockPostion.x + side + espacement, LastBlockPostion.y);
                        blockScriptPos.position = new Vector2(hauteurTemp + 1, largeurTemp);
                        //position ++;
                        //on met le block dans la grille
                        break;
                }
                LastBlockPostion = block.transform.position;
            }
        }
        else if (form == "J")
        {
            piece = new GameObject("pieceJ");
            piece.transform.position = new Vector2(xPos, yPos);
            for (int i = 0; i < 4; i++)
            {
                block = ChooseBlock(piece, i);
                BlockScript blockScriptPos = block.GetComponent<BlockScript>();
                switch (i)
                {
                    case 0:
                        block.transform.position = piece.transform.position;
                        largeurTemp = (int)Mathf.Ceil(largeur / 3);
                        hauteurTemp = hauteur;
                        blockScriptPos.position = new Vector2(hauteurTemp, largeurTemp);
                        //position = largeur /3 ;(arrondi)
                        //on le met dans la grille
                        //position =  Mathf.Ceil(position);
                        break;
                    case 3:
                        block.transform.position = new Vector2(LastBlockPostion.x , LastBlockPostion.y + side + espacement);
                        blockScriptPos.position = new Vector2(hauteurTemp, largeurTemp + 1);
                        break;
                    default:
                        
                        block.transform.position = new Vector2(LastBlockPostion.x + side + espacement, LastBlockPostion.y);
                        blockScriptPos.position = new Vector2(hauteurTemp + 1, largeurTemp);
                        //position ++;
                        //on met le block dans la grille
                        break;
                }
                LastBlockPostion = block.transform.position;
            }
        }
        else if (form == "L")
        {
            piece = new GameObject("pieceL");
            piece.transform.position = new Vector2(xPos, yPos);
            for (int i = 0; i < 4; i++)
            {
                block = ChooseBlock(piece, i);
                BlockScript blockScriptPos = block.GetComponent<BlockScript>();
                switch (i)
                {
                    case 0:
                        block.transform.position = piece.transform.position;
                        largeurTemp = (int)Mathf.Ceil(largeur / 3);
                        hauteurTemp = hauteur;
                        blockScriptPos.position = new Vector2(hauteurTemp, largeurTemp);
                        //position = largeur /3 ;(arrondi)
                        //on le met dans la grille
                        //position =  Mathf.Ceil(position);
                        break;
                    case 3:
                        block.transform.position = new Vector2(LastBlockPostion.x, LastBlockPostion.y - side - espacement);
                        blockScriptPos.position = new Vector2(hauteurTemp, largeurTemp - 1);
                        break;
                    default:
                        
                        block.transform.position = new Vector2(LastBlockPostion.x + side + espacement, LastBlockPostion.y);
                        blockScriptPos.position = new Vector2(hauteurTemp + 1, largeurTemp);
                        //position ++;
                        //on met le block dans la grille
                        break;
                }
                LastBlockPostion = block.transform.position;
            }
        }
        else if (form == "O")
        {
            piece = new GameObject("pieceO");
            piece.transform.position = new Vector2(xPos, yPos);
            for (int i = 0; i < 4; i++)
            {
                block = ChooseBlock(piece, i);
                BlockScript blockScriptPos = block.GetComponent<BlockScript>();
                switch (i)
                {
                    case 0:
                        block.transform.position = piece.transform.position;
                        largeurTemp = (int)Mathf.Ceil(largeur / 3);
                        hauteurTemp = hauteur;
                        blockScriptPos.position = new Vector2(hauteurTemp, largeurTemp);
                        //position = largeur /3 ;(arrondi)
                        //on le met dans la grille
                        //position =  Mathf.Ceil(position);
                        break;
                    case 2:
                        block.transform.position = new Vector2(LastBlockPostion.x, LastBlockPostion.y - side - espacement);
                        blockScriptPos.position = new Vector2(hauteurTemp, largeurTemp - 1);
                        break;
                    case 3:
                        block.transform.position = new Vector2(LastBlockPostion.x - side - espacement, LastBlockPostion.y );
                        blockScriptPos.position = new Vector2(hauteurTemp -1 , largeurTemp );
                        break;
                    default:
                        
                        block.transform.position = new Vector2(LastBlockPostion.x + side + espacement, LastBlockPostion.y);
                        blockScriptPos.position = new Vector2(hauteurTemp + 1, largeurTemp);
                        //position ++;
                        //on met le block dans la grille
                        break;
                }
                LastBlockPostion = block.transform.position;
            }
        }
        else if (form == "Z")
        {
            piece = new GameObject("pieceZ");
            piece.transform.position = new Vector2(xPos, yPos);
            for (int i = 0; i < 4; i++)
            {
                block = ChooseBlock(piece, i);
                BlockScript blockScriptPos = block.GetComponent<BlockScript>();
                switch (i)
                {

                    case 0:
                        block.transform.position = piece.transform.position;
                        largeurTemp = (int) Mathf.Ceil(largeur / 3);
                        hauteurTemp = hauteur;
                        blockScriptPos.position = new Vector2(hauteurTemp, largeurTemp);
                        //on le met dans la grille
                        //position =  Mathf.Ceil(position);
                        break;
                    case 2:
                        block.transform.position = new Vector2(LastBlockPostion.x, LastBlockPostion.y - side - espacement);
                        blockScriptPos.position = new Vector2(hauteurTemp, largeurTemp-1);
                        break;
                    default:
                        
                        block.transform.position = new Vector2(LastBlockPostion.x + side + espacement, LastBlockPostion.y);
                        blockScriptPos.position = new Vector2(hauteurTemp +1, largeurTemp);
                        //position ++;
                        //on met le block dans la grille
                        break;
                }
                LastBlockPostion = block.transform.position;
            }
        }
        else if (form == "S")
        {
            piece = new GameObject("pieceZ");
            piece.transform.position = new Vector2(xPos, yPos);
            for (int i = 0; i < 4; i++)
            {
                block = ChooseBlock(piece, i);
                BlockScript blockScriptPos = block.GetComponent<BlockScript>();
                switch (i)
                {
                    case 0:
                        block.transform.position = piece.transform.position;
                        largeurTemp = (int)Mathf.Ceil(largeur / 3);
                        hauteurTemp = hauteur;
                        blockScriptPos.position = new Vector2(hauteurTemp, largeurTemp);
                        //position = largeur /3 ;(arrondi)
                        //on le met dans la grille
                        //position =  Mathf.Ceil(position);
                        break;
                    case 2:
                        block.transform.position = new Vector2(LastBlockPostion.x, LastBlockPostion.y + side + espacement);
                        blockScriptPos.position = new Vector2(hauteurTemp, largeurTemp + 1);
                        break;
                    default:
                        
                        block.transform.position = new Vector2(LastBlockPostion.x + side + espacement, LastBlockPostion.y);
                        blockScriptPos.position = new Vector2(hauteurTemp + 1, largeurTemp);
                        //position ++;
                        //on met le block dans la grille
                        break;
                }
                LastBlockPostion = block.transform.position;
            }
        }
    }


	// Update is called once per frame
	void Update () {
		
	}
}
