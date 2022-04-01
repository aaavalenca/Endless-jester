using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    // Esse script foi criado dentro do sprite em si.
    // O próprio sprite do Spike (então, se eu quiser
    // outros objetos, eu crio sprites novos e dou scripts
    // novos para eles

    public SpikeGenerator spikeGenerator;

    // Update is called once per frame
    void Update()
    {
        // translate: mova o objeto para a esquerda, num deslocamento determinado
        // pela velocidade do spike que está no gerador de spikes * tempo
        transform.Translate(Vector2.left * spikeGenerator.currentSpeed * Time.deltaTime);

    }

    // Se o gameObject deste script é acionado (triggered) por uma colisão
    // faça algo
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Se esta colisão é com o objeto com a tag NextLine,
        // gere um spike novo
        if (collision.gameObject.CompareTag("NextLine"))
        {
            spikeGenerator.GenerateNextSpikeWithGap();
        }

        // Destrói o próprio spike se ele entrar em contato
        // com o objeto de fim
        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(this.gameObject);
        }

    }

}
