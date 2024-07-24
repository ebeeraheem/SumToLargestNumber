

// Sample input array
int[] numbers = { 2, 3, 5,7,2,6,98,0,2, 7, 5 };

// Call the function and display the result
string result = CanSumToLargestNumber(numbers);
Console.WriteLine(result);



static string CanSumToLargestNumber(int[] numbers)
{
    if (numbers == null || numbers.Length == 0)
    {
        return "Invalid input.";
    }

    // Find the largest number in the array
    int largest = numbers.Max();

    // Filter out the largest number from the array
    var others = numbers.Where(num => num != largest).ToArray();

    // Check if any combination of numbers in 'others' can sum up to 'largest'
    if (CanSum(others, largest))
    {
        return "Yes, this combination of numbers sum up to the largest number.";
    }
    else
    {
        return "No, this combination of numbers did not sum up to the largest number.";
    }
}

static bool CanSum(int[] numbers, int target)
{
    // Initialize a boolean array to store results of subproblems
    bool[] dp = new bool[target + 1];
    dp[0] = true;

    foreach (var num in numbers)
    {
        // Traverse dp array from right to left
        for (int j = target; j >= num; j--)
        {
            if (dp[j - num])
            {
                dp[j] = true;
            }
        }
    }

    return dp[target];
}