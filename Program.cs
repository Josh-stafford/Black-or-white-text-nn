using System;

namespace Black_white_text_NN
{
    class Program
    {

        static void Main() {

            // Parameters
            float learningRate = 0.05f;
            int epochCount = 1000;
            int bias = 1;

            // Colour RGB Values
            int[] pink = new int[3] { 244, 66, 161 };
            int[] lightBlue = new int[3] { 0, 255, 255 };
            int[] black = new int[3] { 255, 255, 255 };
            int[] white = new int[3] { 0, 0, 0 };
            int[] yellow = new int[3] { 255, 255, 0 };
            int[] green = new int[3] { 0, 255, 0 };
            int[] red = new int[3] { 255, 0, 0 };
            int[] blue = new int[3] { 0, 0, 255 };
            int[] darkBlue = new int[3] { 18, 0, 140 };

            // Training input data
            int[][] trainX = new int[][] { pink, lightBlue, black, white, yellow, green, red, blue, darkBlue };

            // Training output data
            // 1, 0 = White
            // 0, 1 = Black
            int[] pinkAnswer = new int[2] { 0, 1 };
            int[] lightBlueAnswer = new int[2] { 0, 1 };
            int[] blackAnswer = new int[2] { 1, 0 };
            int[] whiteAnswer = new int[2] { 0, 1 };
            int[] yellowAnswer = new int[2] { 0, 1 };
            int[] greenAnswer = new int[2] { 0, 1 };
            int[] redAnswer = new int[2] { 0, 1 };
            int[] blueAnswer = new int[2] { 1, 0 };
            int[] darkBlueAnswer = new int[2] { 1, 0 };
            int[][] trainy = new int[][] { pinkAnswer, lightBlueAnswer, blackAnswer, whiteAnswer, yellowAnswer, greenAnswer, redAnswer, blueAnswer, darkBlueAnswer };

            // Hidden Layer Array
            float[] hiddenLayerNodes = new float[4] { 0f, 0f, 0f, 0f };
        
            // Hidden Layer Weights
            float[] hiddenWeights = new float[12] { 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f };

            // Output Layer Array
            float[] outputLayerNodes = new float[2] { 0, 0 };

            // Output Layer Weights
            float[] outputWeights = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 };


            // Sigmoid activation function
            float sig(float val)
            {

                return (float)(1f / (1f + (Math.Pow(2.71828f, val * -1f))));

            }

            int Train()
            {

                // Randomize hidden weights
                Random rnd = new Random();
                Console.WriteLine("Intial hidden weights:");
                for (int i = 0; i < hiddenWeights.Length; i++)
                {

                    hiddenWeights[i] = rnd.Next(-5, 5);
                    Console.WriteLine(hiddenWeights[i]);

                }

                // Randomize output weights
                Console.WriteLine("Initial output weights:");
                for (int i = 0; i < outputWeights.Length; i++)
                {

                    outputWeights[i] = rnd.Next(-5, 5);
                    Console.WriteLine(outputWeights[i]);

                }

                Console.WriteLine("Press any key...");
                Console.ReadKey();

                // Training loop
                for (int i = 0; i < epochCount; i++)
                {

                    Console.WriteLine("Epoch Num: " + i.ToString());

                    for (int y = 0; y < trainX.Length; y++)
                    {

                        // Input nodes
                        float inp1 = (float)trainX[y][0];
                        float inp2 = (float)trainX[y][1];
                        float inp3 = (float)trainX[y][2];

                        Console.WriteLine(inp1.ToString() + " " + inp2.ToString() + " " + inp3.ToString());

                        // Output data
                        int[] wantedOut = trainy[y];

                        // Feedforward from inputs to hidden layer
                        for (int x = 0; x < hiddenLayerNodes.Length; x++)
                        {

                            Console.WriteLine("Hidden node: " + x.ToString());
                            float val = sig((inp1 * hiddenWeights[x]) + (inp2 * hiddenWeights[x + 4]) + (inp3 * hiddenWeights[x + 8]) + bias);
                            Console.WriteLine(inp1 * hiddenWeights[x]);
                            Console.WriteLine(inp2 * hiddenWeights[x + 4]);
                            Console.WriteLine(inp3 * hiddenWeights[x + 8]);
                            hiddenLayerNodes[x] = val;

                        }

                        // Feedforward from hidden layer to outputs
                        for (int x = 0; x < outputLayerNodes.Length; x++)
                        {

                            Console.WriteLine("Output node: " + x.ToString());
                            outputLayerNodes[x] = sig((hiddenLayerNodes[0] * outputWeights[x]) + (hiddenLayerNodes[1] * outputWeights[x + 2]) + (hiddenLayerNodes[2] * outputWeights[x + 4]) + (hiddenLayerNodes[3] * outputWeights[x + 6]));

                        }

                        Console.WriteLine("Hidden Nodes");
                        Console.WriteLine("[{0}]", string.Join(", ", hiddenLayerNodes));
                        Console.WriteLine("Output Nodes");
                        Console.WriteLine("[{0}]", string.Join(", ", outputLayerNodes));

                        if (outputLayerNodes[0] > outputLayerNodes[1])
                        {
                            Console.WriteLine("White text with " + ((int)(outputLayerNodes[0] / (outputLayerNodes[0] + outputLayerNodes[1]))) + " certainty.");
                        }
                        else if (outputLayerNodes[1] > outputLayerNodes[0])
                        {
                            Console.WriteLine("White text with " + ((outputLayerNodes[1] / (outputLayerNodes[0] + outputLayerNodes[1]))) * 100 + "% certainty.");
                        } else
                        {
                            Console.WriteLine("Uncertain.");
                        }

                        Console.ReadKey();

                        


                    }

                    

                }

                return 0;

            }

            Train();
            Console.ReadKey();

        }
        
    }

}
