using System;

namespace Black_white_text_NN
{
    class Program
    {

        static void Main() {

            // Parameters
            float learningRate = 0.05f;
            int iterationCount = 1000;

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
            // 0 = White
            // 1 = Black
            int[] trainy = new int[9] { 1, 1, 0, 1, 1, 1, 1, 0, 0 };

            // Hidden Layer Weights
            int[] weights = new int[4] { 0, 0, 0, 0 };

            double sig(int val)
            {

                return (1f / (1f + (Math.Pow(2.71828f, val * -1f))));

            }

            int Train()
            {

                // Randomize weights
                Random rnd = new Random();
                Console.WriteLine("Intial weights:");
                for (var i = 0; i < weights.Length; i++)
                {

                    weights[i] = rnd.Next(-5, 5);
                    Console.WriteLine(weights[i]);

                }

                // Training loop
                for (var i = 0; i < iterationCount; i++)
                {

                    // Input nodes
                    int inp1 = trainX[i][0];
                    int inp2 = trainX[i][1];
                    int inp3 = trainX[i][2];

                    // Output data
                    int wantedOut = trainy[i];

                }

                return 0;

            }

            Train();
            Console.ReadKey();

        }
        
    }

}
