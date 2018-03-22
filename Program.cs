using System;

namespace Black_or_white_text_NN
{
    class Program
    {

        static void Main()
        {

            // Parameters
            float learningRate = 0.5f;
            int epochCount = 10;
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
            int[] darkGray = new int[3] { 67, 70, 76 };
            int[] darkRed = new int[3] { 96, 4, 14 };

            // Training input data
            int[][] trainX = new int[][] { pink, lightBlue, black, white, yellow, green, red, blue, darkBlue, darkGray, darkRed };

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
            int[] darkGrayAnswer = new int[2] { 1, 0 };
            int[] darkRedAnswer = new int[2] { 1, 0 };
            int[][] trainy = new int[][] { pinkAnswer, lightBlueAnswer, blackAnswer, whiteAnswer, yellowAnswer, greenAnswer, redAnswer, blueAnswer, darkBlueAnswer, darkGrayAnswer, darkRedAnswer };

            // Hidden Layer Array
            float[] hiddenLayerNodes = new float[4] { 0f, 0f, 0f, 0f };

            // Hidden Layer Weights
            float[] hiddenWeights = new float[12] { 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f };

            // Output Layer Array
            float[] outputLayerNodes = new float[2] { 0, 0 };

            // Output Layer Weights
            float[] outputWeights = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 };

            // Error arrays
            float[] outputErrors = new float[2] { 0, 0 };

            float[] deltaWeights = new float[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            float[] hiddenNodeErrors = new float[4] { 0, 0, 0, 0 };
            float[] hiddenErrors1 = new float[4] { 0, 0, 0, 0 };
            float[] hiddenErrors2 = new float[4] { 0, 0, 0, 0 };
            float totalHiddenWeights1 = 0;
            float totalHiddenWeights2 = 0;

            float[] inputNodeErrors = new float[3] { 0, 0, 0 };
            float[] inputErrors1 = new float[3] { 0, 0, 0 };
            float[] inputErrors2 = new float[3] { 0, 0, 0 };
            float[] inputErrors3 = new float[3] { 0, 0, 0 };
            float[] inputErrors4 = new float[3] { 0, 0, 0 };
            float totalInputErrors1 = 0;
            float totalInputErrors2 = 0;
            float totalInputErrors3 = 0;
            float totalInputErrors4 = 0;



            // Sigmoid activation function
            float sig(float val)
            {
                float num = (float)(1 / (1 + Math.Pow(2.71828, (val * -1))));
                return num;

            }


            int Train()
            {

                // Randomize hidden weights
                Random rnd = new Random();
                Console.WriteLine("Intial hidden weights:");
                for (int i = 0; i < hiddenWeights.Length; i++)
                {

                    hiddenWeights[i] = (float)rnd.NextDouble() * 2 - 1;
                    Console.WriteLine(hiddenWeights[i]);

                }

                // Randomize output weights
                Console.WriteLine("Initial output weights:");
                for (int i = 0; i < outputWeights.Length; i++)
                {

                    outputWeights[i] = (float)rnd.NextDouble() * 2 - 1;
                    Console.WriteLine(outputWeights[i]);

                }

                Console.WriteLine("Press any key...");
                Console.ReadKey();

                // --- Training loop ---
                for (int i = 0; i < epochCount; i++)
                {

                    Console.WriteLine("Epoch Num: " + i.ToString());

                    for (int y = 0; y < trainX.Length; y++)
                    {

                        Console.WriteLine("\n\nHidden Weights:");
                        Console.WriteLine("[{0}]", string.Join(", ", hiddenWeights));
                        Console.WriteLine("Output Weights:");
                        Console.WriteLine("[{0}]", string.Join(", ", outputWeights));

                        // Input nodes
                        float inp1 = (float)trainX[y][0];
                        float inp2 = (float)trainX[y][1];
                        float inp3 = (float)trainX[y][2];

                        Console.WriteLine(inp1.ToString() + " " + inp2.ToString() + " " + inp3.ToString());


                        // Output data
                        int[] wantedOut = trainy[y];

                        // -- Feedforward from inputs to hidden layer --
                        for (int x = 0; x < hiddenLayerNodes.Length; x++)
                        {

                            float val = sig((inp1 * hiddenWeights[x]) + (inp2 * hiddenWeights[x + 4]) + (inp3 * hiddenWeights[x + 8]) + bias);
                            hiddenLayerNodes[x] = val;

                        }

                        // -- Feedforward from hidden layer to outputs --
                        for (int x = 0; x < outputLayerNodes.Length; x++)
                        {

                            outputLayerNodes[x] = sig((hiddenLayerNodes[0] * outputWeights[x]) + (hiddenLayerNodes[1] * outputWeights[x + 2]) + (hiddenLayerNodes[2] * outputWeights[x + 4]) + (hiddenLayerNodes[3] * outputWeights[x + 6]) + bias);

                        }

                        Console.WriteLine("Hidden Nodes");
                        Console.WriteLine("[{0}]", string.Join(", ", hiddenLayerNodes));
                        Console.WriteLine("Output Nodes");
                        Console.WriteLine("[{0}]", string.Join(", ", outputLayerNodes));

                        if (outputLayerNodes[0] > outputLayerNodes[1])
                        {
                            Console.WriteLine("White text with " + ((outputLayerNodes[0] / (outputLayerNodes[0] + outputLayerNodes[1]))) * 100 + "% certainty.");
                        }
                        else if (outputLayerNodes[1] > outputLayerNodes[0])
                        {
                            Console.WriteLine("Black text with " + ((outputLayerNodes[1] / (outputLayerNodes[0] + outputLayerNodes[1]))) * 100 + "% certainty.");
                        }
                        else
                        {
                            Console.WriteLine("Uncertain.");
                        }

                        string answer = "";
                        if (wantedOut[0] == 1)
                        {

                            answer = "White";

                        }
                        else
                        {
                            answer = "Black";
                        }
                        Console.WriteLine("Correct answer: " + answer);

                        // -- Backprop from output to hidden layer --
                        // Calculating Error
                        for (var x = 0; x < outputLayerNodes.Length; x++)
                        {

                            outputErrors[x] = (float)wantedOut[x] - outputLayerNodes[x];
                            Console.WriteLine(outputErrors[x]);

                        }

                        // Finding Change in weights
                        int count = 0;
                        for (int x = 0; x < hiddenLayerNodes.Length; x++)
                        {

                            for (int j = 0; j < 2; j++)
                            {
                                deltaWeights[count] = learningRate * outputErrors[count % 2] * (outputLayerNodes[count % 2] * (1 - outputLayerNodes[count % 2])) * hiddenLayerNodes[x];
                                count += 1;
                            }


                        }

                        totalHiddenWeights1 = outputWeights[0] + outputWeights[2] + outputWeights[4] + outputWeights[6];
                        totalHiddenWeights2 = outputWeights[1] + outputWeights[3] + outputWeights[5] + outputWeights[7];

                        // Finding error values for hidden layer
                        for (int x = 0; x < hiddenErrors1.Length; x++)
                        {

                            hiddenErrors1[x] = (outputWeights[x * 2] / totalHiddenWeights1) * outputErrors[0];
                            hiddenErrors2[x] = (outputWeights[(x * 2) + 1] / totalHiddenWeights2) * outputErrors[1];

                            // Assign hidden nodes their error value
                            hiddenNodeErrors[x] = hiddenErrors1[x] + hiddenErrors2[x];

                        }

                        totalInputErrors1 = hiddenWeights[0] + hiddenWeights[4] + hiddenWeights[8];
                        totalInputErrors2 = hiddenWeights[1] + hiddenWeights[5] + hiddenWeights[9];
                        totalInputErrors3 = hiddenWeights[2] + hiddenWeights[6] + hiddenWeights[10];
                        totalInputErrors4 = hiddenWeights[3] + hiddenWeights[7] + hiddenWeights[11];

                        // Finding error values for input layer
                        for (int x = 0; x < inputErrors1.Length; x++)
                        {

                            inputErrors1[x] = (hiddenWeights[x * 4] / totalInputErrors1) * hiddenNodeErrors[0];
                            inputErrors2[x] = (hiddenWeights[(x * 4) + 1] / totalInputErrors2) * hiddenNodeErrors[1];
                            inputErrors3[x] = (hiddenWeights[(x * 4) + 2] / totalInputErrors3) * hiddenNodeErrors[2];
                            inputErrors4[x] = (hiddenWeights[(x * 4) + 3] / totalInputErrors4) * hiddenNodeErrors[3];

                            // Assign input nodes their error value
                            inputNodeErrors[x] = inputErrors1[x] + inputErrors2[x] + inputErrors3[x] + inputErrors4[x];

                        }




                        // Console.ReadKey();
                    }

                }

                return 0;

            }

            Train();

        }

    }

}
