public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Create a new double array with the requested length.
        double[] result = new double[length];

        // Step 2: Use a loop to visit every position in the array.
        for (int i = 0; i < length; i++)
        {
            // Step 3: For each position, calculate the multiple of the supplied number.
            //         Since the array index starts at 0, multiply by (index + 1).
            double multiple = number * (i + 1);

            // Step 4: Store the calculated multiple in the current array position.
            result[i] = multiple;
        }

        // Step 5: Return the completed array.
        return result; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.


        // Step 1: Find the index where the last 'amount' elements begin.
        //         This is data.Count - amount.
        int splitIndex = data.Count - amount;

        // Step 2: Use GetRange to save the last 'amount' elements.
        List<int> lastPart = data.GetRange(splitIndex, amount);
        
        // Step 3: Use GetRange to save all the elements before those last elements.
        List<int> firstPart = data.GetRange(0, splitIndex);
        
        // Step 4: Clear the original data list.
        data.Clear();
        
        // Step 5: Add the saved last elements to the beginning of the original list.
        data.AddRange(lastPart);
        
        // Step 6: Add the saved first elements after them.
        //         The original list is now rotated to the right.
        data.AddRange(firstPart);
    }
}
