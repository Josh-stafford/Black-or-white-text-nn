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
            float[] hiddenLayerNodes = new float[4] { 0, 0, 0, 0 };
        
            // Hidden Layer Weights
            float[] hiddenWeights = new float[12] { 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f };

            // Output Layer Array
            float[] outputLayerNodes = new float[2] { 0, 0 };

            // Output Layer Weights
            float[]  

            float sig(float val)
            {

                return (float)(1f / (1f + (Math.Pow(2.71828f, val * -1f))));

            }

            int Train()
            {

                // Randomize weights
                Random rnd = new Random();
                Console.WriteLine("Intial weights:");
                for (int i = 0; i < hiddenWeights.Length; i++)
                {

                    hiddenWeights[i] = rnd.Next(-5, 5);
                    Console.WriteLine(hiddenWeights[i]);

                }

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

                        // Output data
                        int[] wantedOut = trainy[y];

                        // Feedforward from inputs to hidden layer
                        for (int x = 0; x < hiddenLayerNodes.Length; x++)
                        {

                            Console.WriteLine("Hidden node: " + x.ToString());
                            hiddenLayerNodes[x] = sig((inp1 * hiddenWeights[x]) + (inp2 * hiddenWeights[x + 4]) + (inp3 * hiddenWeights[x + 8]) + bias);

                        }

                        // Feedforward from hidden layer to outputs



                    }

                    

                }

                return 0;

            }

            Train();
            Console.ReadKey();

        }
        
    }

}
