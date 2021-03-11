using UnityEngine;

public class Test : MonoBehaviour
{
    public ComputeShader calcMeshShader;
    public Vector3[] array1;
    public Vector3[] array2;
    public Vector3[] resultArr;
    public int length = 16;

    private ComputeBuffer preBuffer;
    private ComputeBuffer nextBuffer;
    private ComputeBuffer resultBuffer;
    private int kernel;

    // Use this for initialization
    void Start()
    {

        array1 = new Vector3[length];

        array2 = new Vector3[length];

        resultArr = new Vector3[length];

        for (int i = 0; i < length; i++)
        {
            array1[i] = Vector3.one;
            array2[i] = Vector3.one * 2;
        }

        InitBuffers();

        kernel = calcMeshShader.FindKernel("CSMain");

        calcMeshShader.SetBuffer(kernel, "preVertices", preBuffer);

        calcMeshShader.SetBuffer(kernel, "nextVertices", nextBuffer);

        calcMeshShader.SetBuffer(kernel, "Result", resultBuffer);
    }

    void InitBuffers()
    {
        preBuffer = new ComputeBuffer(array1.Length, 12);

        preBuffer.SetData(array1);

        nextBuffer = new ComputeBuffer(array2.Length, 12);

        nextBuffer.SetData(array2);

        resultBuffer = new ComputeBuffer(resultArr.Length, 12);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {

            calcMeshShader.Dispatch(kernel, 2, 2, 1);

            resultBuffer.GetData(resultArr);

            //do something with resultArr.
            // foreach (var item in resultArr)
            // {
            //     Debug.LogError(item);
            // }

            resultBuffer.Release();

        }
    }

    void OnDestroy()
    {

        preBuffer.Release();

        nextBuffer.Release();

    }
}