using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

        //     // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

        //     // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

        //     // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

        //     // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

        //     // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }
    
        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                List<int> result = new List<int>();

        // Mark elements as negative to indicate presence of the number
        // Loop through each element in the array
for (int i = 0; i < nums.Length; i++)
{
    // Calculate the index corresponding to the current number's value
    // Math.Abs is used to handle already negated numbers
    int index = Math.Abs(nums[i]) - 1;

    // If the value at the calculated index is positive, negate it
    // This indicates that the number (index + 1) is present in the array
    if (nums[index] > 0)
    {
        nums[index] = -nums[index];
    }
}

// Find all indices that are still positive, indicating missing numbers
for (int i = 0; i < nums.Length; i++)
{
    // If the value is still positive, the number (i + 1) was missing
    if (nums[i] > 0)
    {
        // Add the missing number to the result list
        result.Add(i + 1);
    }
}
        return result;
                return new List<int>(); // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }

        // // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                // Create a new array to hold the sorted elements
            int[] sortedArray = new int[nums.Length];
            int evenIndex = 0; // Pointer for even numbers
            int oddIndex = nums.Length - 1; // Pointer for odd numbers

            // Fill the sortedArray with even numbers first
            foreach (int num in nums)
            {
                if (num % 2 == 0) // Check if the number is even
                {
                    sortedArray[evenIndex] = num;
                    evenIndex++;
                }
            }

            // Then fill the sortedArray with odd numbers
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 != 0) // Check if the number is odd
                {
                    sortedArray[evenIndex] = nums[i];
                    evenIndex++;
                }
            }

            return sortedArray;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                // Create a dictionary to store the value and its index
            Dictionary<int, int> numMap = new Dictionary<int, int>();

            // Iterate through the array
            for (int i = 0; i < nums.Length; i++)
            {
                // Calculate the complement
                int complement = target - nums[i];

                // Check if the complement exists in the dictionary
                if (numMap.ContainsKey(complement))
                {
                    // Return the indices of the two numbers
                    return new int[] { numMap[complement], i };
                }

                // Add the current number and its index to the dictionary
                numMap[nums[i]] = i;
            }

            // If no solution is found, return an empty array
            return new int[0];
                return new int[0]; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }

        // // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                // Sort the array to find the largest and smallest values easily
            Array.Sort(nums);

            // The maximum product can be either:
            // 1. The product of the three largest numbers
            // 2. The product of the two smallest numbers and the largest number
            int n = nums.Length;
            int maxProduct1 = nums[n - 1] * nums[n - 2] * nums[n - 3]; // Product of three largest numbers
            int maxProduct2 = nums[0] * nums[1] * nums[n - 1]; // Product of two smallest and the largest number

            // Return the maximum of the two products
            return Math.Max(maxProduct1, maxProduct2);
                return 0; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }

        // // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                // Handle the case when the number is 0
            if (decimalNumber == 0) return "0";

            string binary = "";

            // Convert decimal to binary
            while (decimalNumber > 0)
            {
                int remainder = decimalNumber % 2; // Get remainder
                binary = remainder + binary; // Prepend remainder to binary string
                decimalNumber /= 2; // Divide the number by 2
            }

            
                return binary; // Return the binary equivalent
            }
            catch (Exception)
            {
                throw;
            }
        }

        // // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                 int left = 0;
            int right = nums.Length - 1;

            // If the array is not rotated (first element is less than the last element)
            if (nums[left] < nums[right])
            {
                return nums[left];
            }

            // Perform binary search to find the minimum element
            while (left < right)
            {
                int mid = left + (right - left) / 2;

                // Check if mid element is greater than the rightmost element
                if (nums[mid] > nums[right])
                {
                    // The minimum element is in the right part
                    left = mid + 1;
                }
                else
                {
                    // The minimum element is in the left part including mid
                    right = mid;
                }
            }

            // left will be pointing to the minimum element
            return nums[left];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // If x is negative or ends with a 0 (but is not 0), it cannot be a palindrome
            if (x < 0 || (x % 10 == 0 && x != 0))
            {
                return false;
            }

            int reversed = 0;
            while (x > reversed)
            {
                // Append the last digit of x to the reversed number
                reversed = reversed * 10 + x % 10;
                // Remove the last digit from x
                x /= 10;
            }

            // For even-length numbers, x should equal reversed
            // For odd-length numbers, we can remove the middle digit by reversed / 10
            return x == reversed || x == reversed / 10;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                 // Handle the base cases
            if (n == 0) return 0;
            if (n == 1) return 1;

            // Initialize the first two Fibonacci numbers
            int a = 0, b = 1, fib = 0;

            // Calculate Fibonacci iteratively
            for (int i = 2; i <= n; i++)
            {
                fib = a + b; // F(n) = F(n-1) + F(n-2)
                a = b; // Move to the next Fibonacci number
                b = fib; // Update to the new Fibonacci number
            }

                return fib; // Return the nth Fibonacci number
            }
            catch (Exception)
            {
                throw;
            }
         }
    }
}
