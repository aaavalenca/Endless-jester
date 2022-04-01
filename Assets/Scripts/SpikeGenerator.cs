using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGenerator : MonoBehaviour
{
    // esta é a variável onde colocaremos o sprike spike
    // podemos ter spikes diferentes, e isso aqui
    // é que vai determinar onde ele está.
    public GameObject spike;

    public float minSpeed;
    public float maxSpeed;
    public float currentSpeed;

    public float acceleration;

    void Awake()
    {
        currentSpeed = minSpeed;
        generateSpike();
    }

    public void GenerateNextSpikeWithGap() {
        float randomWait = Random.Range(0.1f, 1.2f);
        // O métdo Invoke passa o nome de um outro métdo e um valor, que
        // representa um tempo. A função então é chamada com um atraso
        // deste tempo. Portanto, toda vez que generateSpike está
        // sendo chamada agora, ele está tendo um atraso de tempo aleatório
        Invoke("generateSpike", randomWait);
    }

    void generateSpike() {
        // um spike será criado no exato local onde o Spike Generator se encontra
        // (este script está atribuído ao SpikeGenerator)
        GameObject spikeInstance = Instantiate(spike, transform.position, transform.rotation);

        // Tods os spikes gerados terão uma referência ao gerador
        spikeInstance.GetComponent<Spike>().spikeGenerator = this;

    }

    void Update()
    {

        currentSpeed += acceleration;
        
    }
}
