using System;

class Program
{
    static void Main(string[] args)
    {
        int[,] matrix;
        int rows, cols;

        do
        {
            // Initialize the matrix
            matrix = ArrayData(out rows, out cols);

            // Display the original matrix
            Console.WriteLine("Displaying The Original Two Dimension Array Data. Press 'Enter' to display the next matrix :");
            DisplayArray(matrix, rows, cols);
            Console.ReadKey();

            // Swap the rows and display the new matrix
            SwapRow(matrix, rows, cols);
            Console.WriteLine("Displaying The Matrix After Swapping Rows. Press 'Enter' to display the next matrix :");
            DisplayArray(matrix, rows, cols);
            Console.ReadKey();

            // Swap the columns and display the new matrix
            SwapColumn(matrix, rows, cols);
            Console.WriteLine("Displaying The Matrix After Swapping Columns. Press 'Enter' to display the next matrix :");
            DisplayArray(matrix, rows, cols);
            Console.ReadKey();

            // Rotate the matrix to the left and display the new matrix
            matrix = RotateLeftDiagonal(matrix);
            Console.WriteLine("Displaying The Matrix After Rotating Left Diagonal. Press 'Enter' to display the next matrix :");
            DisplayArray(matrix, cols, rows);
            Console.ReadKey();

            // Rotate the matrix to the right and display the new matrix
            matrix = RotateRightDiagonal(matrix);
            Console.WriteLine("Displaying The Matrix After Rotating Right Diagonal. Press 'Enter' to continue :");
            DisplayArray(matrix, cols, rows);
            Console.ReadKey();

            // Ask the user if they want to continue
            Console.WriteLine("Do you want to run the program again? (Y/N) :");

        } while (Console.ReadLine().ToUpper() == "Y");
    }

    static int[,] ArrayData(out int row, out int col)
    {
        Console.Write("Enter the number of rows: ");
        row = int.Parse(Console.ReadLine());
        Console.Write("Enter the number of columns: ");
        col = int.Parse(Console.ReadLine());

        int[,] matrix = new int[row, col];
        Random randNum = new Random();

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                matrix[i, j] = randNum.Next(1, 101);
            }
        }

        return matrix;
    }

    static void DisplayArray(int[,] array, int row, int col)
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                Console.Write("{0}\t", array[i, j]);
            }
            Console.WriteLine();
        }
    }

    static void SwapRow(int[,] matrix, int row, int col)
    {
        for (int i = 0; i < row / 2; i++)
        {
            for (int j = 0; j < col; j++)
            {
                int temp = matrix[i, j];
                matrix[i, j] = matrix[row - i - 1, j];
                matrix[row - i - 1, j] = temp;
            }
        }
    }

    static void SwapColumn(int[,] matrix, int row, int col)
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col / 2; j++)
            {
                int temp = matrix[i, j];
                matrix[i, j] = matrix[i, col - 1 - j];
                matrix[i, col - 1 - j] = temp;
            }
        }
    }

    static int[,] RotateLeftDiagonal(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        int[,] rotatedMatrix = new int[cols, rows];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                rotatedMatrix[j, i] = matrix[i, j];
            }
        }

        return rotatedMatrix;

    }

    static int[,] RotateRightDiagonal(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        int[,] rotatedMatrix = new int[cols, rows];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                rotatedMatrix[cols - j - 1, rows - i - 1] = matrix[i, j];
            }
        }

        return rotatedMatrix;

    }
}
