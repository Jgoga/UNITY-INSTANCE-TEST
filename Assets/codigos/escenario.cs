using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class escenario : MonoBehaviour
{
    public GameObject cuboInicial;
    public GameObject cuboInstanciado;
    public Transform posicionInicial;
    public float velocidadCaida = -1000;
    public bool useGravity = true;
    public Text FPS,CantidadDeCubos;
    private int contador;

    float deltaTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
       contador = 1;
       cuboInicial.GetComponent<Rigidbody>().AddForce(new Vector3(0,velocidadCaida,0));
       StartCoroutine("instanciarCubo");
    }
    

    private void FixedUpdate() 
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        FPS.text = "FPS= " + fps.ToString();
    }

    IEnumerator instanciarCubo()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.1f);
            contador ++;
            CantidadDeCubos.text = "Cantidad de cubos = " + contador.ToString();
            GameObject cuboActual =Instantiate(cuboInstanciado,posicionInicial);
            cuboActual.GetComponent<Rigidbody>().AddForce(new Vector3(0,velocidadCaida,10));
            //cubos.Add(cuboInstanciado)
        }
    }

        
    
}
