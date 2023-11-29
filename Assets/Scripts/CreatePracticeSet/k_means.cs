using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class k_means : MonoBehaviour
{
    [SerializeField] string filename;
    [SerializeField] string filename_clustercenter;
    [SerializeField] string filename_assignments;
    [SerializeField] string filename_closestpoints;

    [SerializeField] int k = 10; // クラスターの数


    private float[][] clusterCenters;
    private int[] assignments; // 各データポイントのクラスター割り当て
    private int[] closestpoints;
    // Start is called before the first frame update
    void Start()
    {
        float[,] dataMatrix = LoadCSV(Application.dataPath + "/StreamingAssets/Set_Practice/" + filename + ".csv");

        //クラスタの中心設計
        clusterCenters = InitializeClusterCenters(dataMatrix, k);
        assignments = new int[dataMatrix.GetLength(0)];

        bool hasChanged;
        do
        {
            hasChanged = AssignClusters(dataMatrix, clusterCenters, assignments);
            UpdateClusterCenters(dataMatrix, clusterCenters, assignments);
        }
        while (hasChanged);

        // クラスタリング結果の代表点に最も近い点を探す
        closestpoints = SelectClosestPointsToCenters(dataMatrix, clusterCenters, assignments);


        SaveClusterCenters(clusterCenters, Application.dataPath + "/StreamingAssets/Set_Practice/" + filename_clustercenter + ".csv");
        SaveAssignments(assignments, Application.dataPath + "/StreamingAssets/Set_Practice/" + filename_assignments + ".csv");
        SaveClosestPoints(closestpoints, Application.dataPath + "/StreamingAssets/Set_Practice/" + filename_closestpoints + ".csv");

    }

    float[,] LoadCSV(string path)
    {
        // ファイルの全行を読み込む
        string[] lines = File.ReadAllLines(path);

        // 行数を取得
        int rows = lines.Length;
        // 列数を最初の行から取得（カンマで分割）
        int cols = lines[0].Split(',').Length;

        // データ行列の初期化（行数と列数を動的に設定）
        float[,] dataMatrix = new float[rows-1, cols];

        for (int i = 1; i < lines.Length; i++)
        {
            // CSVの各行をカンマで分割
            string[] values = lines[i].Split(',');

            for (int j = 0; j < values.Length; j++)
            {
                // データを浮動小数点数に変換して格納
                dataMatrix[i-1, j] = float.Parse(values[j]);
            }
        }

        return dataMatrix;
    }
    // k-means++ でクラスターの中心を初期化
    float[][] InitializeClusterCenters(float[,] data, int k)
    {
        int rows = data.GetLength(0);
        int cols = data.GetLength(1);
        List<int> chosenCenters = new List<int>();
        float[][] centers = new float[k][];

        // 最初の中心をランダムに選択
        int firstCenterIndex = UnityEngine.Random.Range(0, rows);
        chosenCenters.Add(firstCenterIndex);
        centers[0] = GetRow(data, firstCenterIndex);

        for (int i = 1; i < k; i++)
        {
            // 次の中心を選択
            int nextCenterIndex = ChooseNextCenter(data, centers, chosenCenters, i);
            chosenCenters.Add(nextCenterIndex);
            centers[i] = GetRow(data, nextCenterIndex);
        }

        return centers;
    }

    // 次の中心を選択
    int ChooseNextCenter(float[,] data, float[][] centers, List<int> chosenCenters, int currentCenterCount)
    {
        int rows = data.GetLength(0);
        double[] distances = new double[rows];

        for (int i = 0; i < rows; i++)
        {
            double minDistance = double.MaxValue;

            for (int j = 0; j < currentCenterCount; j++)
            {
                double distance = CalculateDistance(GetRow(data, i), centers[j]);
                if (distance < minDistance)
                {
                    minDistance = distance;
                }
            }

            distances[i] = minDistance;
        }

        // 次の中心を重み付き確率で選択
        return WeightedRandomChoice(distances);
    }
    // 2点間の距離を計算（n次元対応）
    double CalculateDistance(float[] point1, float[] point2)
    {
        double sum = 0;
        for (int i = 0; i < point1.Length; i++)
        {
            sum += Mathf.Pow(point1[i] - point2[i], 2);
        }
        return (double)Mathf.Sqrt((float)sum);
    }

    // 重み付きランダム選択
    int WeightedRandomChoice(double[] weights)
    {
        double total = 0;
        foreach (double weight in weights)
        {
            total += weight;
        }

        double r = UnityEngine.Random.Range(0, (float)total);
        double sum = 0;

        for (int i = 0; i < weights.Length; i++)
        {
            sum += weights[i];
            if (r <= sum)
            {
                return i;
            }
        }

        return weights.Length - 1;
    }

    // 行データを取得（n次元対応）
    float[] GetRow(float[,] matrix, int rowIndex)
    {
        int cols = matrix.GetLength(1);
        float[] row = new float[cols];
        for (int i = 0; i < cols; i++)
        {
            row[i] = matrix[rowIndex, i];
        }
        return row;
    }

    // 各データポイントを最も近いクラスターに割り当てる
    bool AssignClusters(float[,] data, float[][] centers, int[] assignments)
    {
        int rows = data.GetLength(0);
        bool hasChanged = false;

        for (int i = 0; i < rows; i++)
        {
            int closestCenterIndex = -1;
            double minDistance = double.MaxValue;
            float[] point = GetRow(data, i);

            for (int j = 0; j < centers.Length; j++)
            {
                double distance = CalculateDistance(point, centers[j]);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestCenterIndex = j;
                }
            }

            if (assignments[i] != closestCenterIndex)
            {
                assignments[i] = closestCenterIndex;
                hasChanged = true;
            }
        }

        return hasChanged;
    }

    // クラスターの中心を更新する
    void UpdateClusterCenters(float[,] data, float[][] centers, int[] assignments)
    {
        int rows = data.GetLength(0);
        int cols = data.GetLength(1);
        int[] counts = new int[centers.Length];
        float[][] newCenters = InitializeCentersArray(centers.Length, cols);

        for (int i = 0; i < rows; i++)
        {
            int clusterIndex = assignments[i];
            float[] point = GetRow(data, i);

            for (int j = 0; j < cols; j++)
            {
                newCenters[clusterIndex][j] += point[j];
            }
            counts[clusterIndex]++;
        }

        for (int i = 0; i < centers.Length; i++)
        {
            if (counts[i] > 0)
            {
                for (int j = 0; j < cols; j++)
                {
                    centers[i][j] = newCenters[i][j] / counts[i];
                }
            }
        }
    }

    // 中心点の配列を初期化する
    float[][] InitializeCentersArray(int numCenters, int numDimensions)
    {
        float[][] centers = new float[numCenters][];
        for (int i = 0; i < numCenters; i++)
        {
            centers[i] = new float[numDimensions];
        }
        return centers;
    }

    int[] SelectClosestPointsToCenters(float[,] data, float[][] centers, int[] assignments)
    {
        int rows = data.GetLength(0);
        int[] closestPointIndices = new int[centers.Length];
        double[] minDistances = new double[centers.Length];

        // 最小距離を初期化
        for (int i = 0; i < centers.Length; i++)
        {
            minDistances[i] = double.MaxValue;
            closestPointIndices[i] = -1; // 初期値として無効なインデックスを設定
        }

        for (int i = 0; i < rows; i++)
        {
            int clusterIndex = assignments[i];
            float[] point = GetRow(data, i);
            double distance = CalculateDistance(point, centers[clusterIndex]);

            if (distance < minDistances[clusterIndex])
            {
                minDistances[clusterIndex] = distance;
                closestPointIndices[clusterIndex] = i; // 行番号を記録
            }
        }

        return closestPointIndices;
    }
    void SaveClusterCenters(float[][] centers, string filePath)
    {
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            foreach (float[] center in centers)
            {
                sw.WriteLine(string.Join(",", center));
            }
        }
    }

    void SaveAssignments(int[] assignments, string filePath)
    {
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            foreach (int assignment in assignments)
            {
                sw.WriteLine(assignment);
            }
        }
    }

    void SaveClosestPoints(int[] indices, string filePath)
    {
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            foreach (int index in indices)
            {
                sw.WriteLine(index);
            }
        }
    }
}
