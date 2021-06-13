using System;
using System.Collections.Generic;
using System.Linq;

namespace Programming_Assignment_2_Summer_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question1:
            Console.WriteLine("Question 1");
            int[] nums1 = { 2, 5, 1, 3, 4, 7 };
            int[] nums2 = { 2, 1, 4, 7 };
            Intersection(nums1, nums2);
            Console.WriteLine("");

            //Question 2 
            Console.WriteLine("Question 2");
            int[] nums = { 0, 1, 0, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question3
            Console.WriteLine("Question 3");
            int[] ar3 = { 1, 2, 3, 1, 1, 3 };
            int Lnum = LuckyNumber(ar3);
            if (Lnum == -1)
                Console.WriteLine("Given Array doesn't have any lucky Integer");
            else
                Console.WriteLine("Lucky Integer for given array {0}", Lnum);

            Console.WriteLine();

            //Question 4
            Console.WriteLine("Question 4");
            Console.WriteLine("Enter the value for n:");
            int n = Int32.Parse(Console.ReadLine());
            int Ma = GenerateNums(n);
            Console.WriteLine("Maximun Element in the Generated Array is {0}", Ma);
            Console.WriteLine();

            //Question 5

            Console.WriteLine("Question 5");
            List<List<string>> cities = new List<List<string>>();
            cities.Add(new List<string>() { "London", "New York" });
            cities.Add(new List<string>() { "New York", "Tampa" });
            cities.Add(new List<string>() { "Delhi", "London" });
            string Dcity = DestCity(cities);
            Console.WriteLine("Destination City for Given Route is : {0}", Dcity);

            Console.WriteLine();

            //Question 6
            Console.WriteLine("Question 6");
            int[] Nums = { 2, 7, 11, 15 };
            int target_sum = 9;
            targetSum(Nums, target_sum);
            Console.WriteLine();

            //Question 7
            Console.WriteLine("Question 7");
            int[,] scores = { { 1, 91 }, { 1, 92 }, { 2, 93 }, { 2, 97 }, { 1, 60 }, { 2, 77 }, { 1, 65 }, { 1, 87 }, { 1, 100 }, { 2, 100 }, { 2, 76 } };
            HighFive(scores);
            Console.WriteLine();

            //Question 8
            Console.WriteLine("Question 8");
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            int K = 3;
            RotateArray(arr, K);

            Console.WriteLine();

            //Question 9
            Console.WriteLine("Question 9");
            int[] arr9 = { 7, 1, 5, 3, 6, 4 };
            int Ms = MaximumSum(arr9);
            Console.WriteLine("Maximun Sum contiguous subarray {0}", Ma);
            Console.WriteLine();

            //Question 10
            Console.WriteLine("Question 10");
            int[] costs = { 10, 15, 20 };
            int minCost = MinCostToClimb(costs);
            Console.WriteLine("Minium cost to climb the top stair {0}", minCost);
            Console.WriteLine();
        }

        //Question 1
        /// <summary>
        //Given two integer arrays nums1 and nums2, return an array of their intersection.
        //Each element in the result must be unique and you may return the result in any order.
        //Example 1:
        //Input: nums1 = [1,2,2,1], nums2 = [2,2]
        //Output: [2]
        //Example 2:
        //Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
        //Output: [9,4]
        //
        /// </summary>

        public static void Intersection(int[] nums1, int[] nums2)
        {
            try
            {
                //Finding the common elements between the two arrays using Intersect method
                int[] Results = nums1.Intersect(nums2).ToArray();
                if (Results.Length == 0)
                    Console.WriteLine("No match found");
                else
                {
                    Console.Write(Results[0]);
                    for (int i = 1; i < Results.Length; i++)
                        Console.Write(("," + Results[i].ToString()));
                }
                Console.WriteLine();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Question 2:
        /// <summary>
        //Given a sorted array of distinct integers and a target value, return the index if the target is found.If not, return the index where it would be if it were inserted in order.
        //Note: You must write an algorithm with O(log n) runtime complexity.
        //Example 1:
        //Input: nums = [1, 3, 5, 6], target = 5
        //Output: 2
        //Example 2:
        //Input: nums = [1, 3, 5, 6], target = 2
        //Output: 1
        //Example 3:
        //Input: nums = [1, 3, 5, 6], target = 7
        //Output: 4
        //Example 4:
        //Input: nums = [1, 3, 5, 6], target = 0
        //Output: 0
        /// </summary>

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                int start = 0;
                int end = nums.Length - 1;
                while (start <= end)
                {
                    int mid = (start + end) / 2;
                    //If the target is equal to the number currently in scope return its index
                    if (nums[mid] == target)
                        return mid;
                    //If the target is greater than the number currently in scope, change the start variable as mid + 1
                    else if (nums[mid] < target)
                        start = mid + 1;
                    //If the target is less than the number currently in scope, change the start variable as mid - 1
                    else
                        end = mid - 1;
                }
                return end + 1;
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Question 3
        /// <summary>
        //Given an array of integers arr, a lucky integer is an integer which has a frequency in the array equal to its value.
        //Return a lucky integer in the array. If there are multiple lucky integers return the largest of them. If there is no lucky integer return -1.
        //Example 1:
        //Input: arr = [2, 2, 3, 4]
        //Output: 2
        //Explanation: The only lucky number in the array is 2 because frequency[2] == 2.
        /// </summary>

        private static int LuckyNumber(int[] nums)
        {
            try
            {
                IDictionary<int, int> numberNames = new Dictionary<int, int>();
                List<int> list1 = new List<int>();
                int max = -1;
                //Doing the Constraint check
                if (nums.Length >= 1 && nums.Length <= 500)
                {
                    for (int i = 0; i < nums.Length; i++)
                    {
                        //Doing the Constraint check
                        if (nums[i] >= 1 && nums[i] <= 500)
                        {
                            //If the number in scope is already present in the dictionary, increment the key by 1
                            if (numberNames.ContainsKey(nums[i]))
                                numberNames[nums[i]] += 1;
                            //If the number in scope is new to the dictionary add the number as a key and 1 as its value
                            else
                                numberNames.Add(nums[i], 1);
                        }
                        else
                            throw new Exception();
                    }
                    //Iterate over each value in the dictionary to verify if the number is equal to its times of occurence
                    foreach (int i in numberNames.Keys)
                    {
                        if (i == numberNames[i])
                        {
                            if (i > max)
                                max = i;
                        }
                    }
                }
                else
                    throw new Exception();
                return max;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Question 4:
        /// <summary>
        //You are given an integer n.An array nums of length n + 1 is generated in the following way:
        //•	nums[0] = 0
        //•	nums[1] = 1
        //•	nums[2 * i] = nums[i]  when 2 <= 2 * i <= n
        //•	nums[2 * i + 1] = nums[i] + nums[i + 1] when 2 <= 2 * i + 1 <= n
        // Return the maximum integer in the array nums.

        //Example 1:
        //Input: n = 7
        //Output: 3
        //Explanation: According to the given rules:
        //nums[0] = 0
        //nums[1] = 1
        //nums[(1 * 2) = 2] = nums[1] = 1
        //nums[(1 * 2) + 1 = 3] = nums[1] + nums[2] = 1 + 1 = 2
        //nums[(2 * 2) = 4] = nums[2] = 1
        //nums[(2 * 2) + 1 = 5] = nums[2] + nums[3] = 1 + 2 = 3
        //nums[(3 * 2) = 6] = nums[3] = 2
        //nums[(3 * 2) + 1 = 7] = nums[3] + nums[4] = 2 + 1 = 3
        //Hence, nums = [0, 1, 1, 2, 1, 3, 2, 3], and the maximum is 3.

        /// </summary>
        private static int GenerateNums(int n)
        {
            try
            {
                //Doing constraint check
                if (n >= 0 && n <= 100)
                {
                    int[] nums = new int[n + 1];
                    nums[0] = 0;
                    nums[1] = 1;
                    int nlen = n / 2;
                    //Computing the values
                    for (int i = 1; i <= nlen; i++)
                    {
                        if ((2 * i) < n + 1)
                            nums[2 * i] = nums[i];
                        if (((2 * i) + 1) < n + 1)
                            nums[(2 * i) + 1] = nums[i] + nums[i + 1];
                    }
                    //Checking for the maximum number
                    int maxnum = nums.Max();
                    return maxnum;
                }
                else
                    throw new Exception();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Question 5
        /// <summary>
        //You are given the array paths, where paths[i] = [cityAi, cityBi] means there exists a direct path going from cityAi to cityBi.Return the destination city, that is, the city without any path outgoing to another city.
        //It is guaranteed that the graph of paths forms a line without any loop, therefore, there will be exactly one destination city.
        //Example 1:
        //Input: paths = [["London", "New York"], ["New York","Lima"], ["Lima","Sao Paulo"]]
        //Output: "Sao Paulo" 
        //Explanation: Starting at "London" city you will reach "Sao Paulo" city which is the destination city.Your trip consist of: "London" -> "New York" -> "Lima" -> "Sao Paulo".
        /// </summary>
        public static string DestCity(List<List<string>> paths)
        {
            try
            {
                List<string> lst = new List<string>();
                //Adding the destination to the list
                foreach (var lststr in paths)
                {
                    lst.Add(lststr[1]);
                }
                //Checking if the source in the scope is already present in the destination list, If yes, remove that element from the destination list
                foreach (var path in paths)
                {
                    if (lst.Contains(path[0]))
                    {
                        lst.Remove(path[0]);
                    }
                }
                //Return the last element of the list
                return (lst.Last());
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Question 6:
        /// <summary>
        //Given an array of integers numbers that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number.
        //Print the indices of the two numbers (1-indexed) as an integer array answer of size 2, where 1 <= answer[0] < answer[1] <= numbers.Length.
        //You may not use the same element twice, there will be only one solution for a given array
        //Example 1:
        //Input: numbers = [2,7,11,15], target = 9
        //Output: [1,2]
        //Explanation: The sum of 2 and 7 is 9. Therefore index1 = 1, index2 = 2.

        /// </summary>
        private static void targetSum(int[] nums, int target)
        {
            try
            {
                int left = 0;
                int right = nums.Length - 1;
                if (nums.Length >= 2 && nums.Length <= (3 * 104))
                {
                    while (left < right)
                    {
                        //Doing a constraint check
                        if (nums[left] >= -1000 && nums[right] >= -1000 && nums[left] <= 1000 && nums[right] <= 1000)
                        {
                            //If the computed value is less than the target increment the left value by 1
                            if ((nums[left] + nums[right]) < target)
                                left++;
                            //If the computed value is greater than the target decrement the right value by 1
                            else if ((nums[left] + nums[right]) > target)
                                right--;
                            //If the value is found exit the loop
                            else if ((nums[left] + nums[right]) == target)
                                break;
                        }
                        else
                            throw new Exception();
                    }
                }
                else
                    throw new Exception();
                Console.WriteLine("[{0},{1}]", left + 1, right + 1);

            }
            catch (Exception)
            {
                throw;
            }
        }

        //Question 7
        /// <summary>
        /// Given a list of the scores of different students, items, where items[i] = [IDi, scorei] represents one score from a student with IDi, calculate each student's top five average.
        /// Print the answer as an array of pairs result, where result[j] = [IDj, topFiveAveragej] represents the student with IDj and their top five average.Sort result by IDj in increasing order.
        /// A student's top five average is calculated by taking the sum of their top five scores and dividing it by 5 using integer division.
        /// Example 1:
        /// Input: items = [[1, 91], [1,92], [2,93], [2,97], [1,60], [2,77], [1,65], [1,87], [1,100], [2,100], [2,76]]
        /// Output: [[1,87],[2,88]]
        /// Explanation: 
        /// The student with ID = 1 got scores 91, 92, 60, 65, 87, and 100. Their top five average is (100 + 92 + 91 + 87 + 65) / 5 = 87.
        /// The student with ID = 2 got scores 93, 97, 77, 100, and 76. Their top five average is (100 + 97 + 93 + 77 + 76) / 5 = 88.6, but with integer division their average converts to 88.
        /// Example 2:
        /// Input: items = [[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100]]
        /// Output: [[1,100],[7,100]]
        /// Constraints:
        /// 1 <= items.length <= 1000
        /// items[i].length == 2
        /// 1 <= IDi <= 1000
        /// 0 <= scorei <= 100
        /// For each IDi, there will be at least five scores.
        /// </summary>
        private static void HighFive(int[,] items)
        {
            try
            {
                List<int[]> list = new List<int[]>();
                List<int[,]> results = new List<int[,]>();

                for (int i = 0; i < items.GetLength(0); i++)
                {
                    list.Add(new int[] { items[i, 0], items[i, 1] });
                }
                //Sorting the list
                list.Sort((p, q) => { return (p[0] < q[0]) ? -1 : ((p[0] == q[0]) ? ((p[1] <= q[1]) ? 1 : -1) : 1); });
                int a = list[0][0];
                int count = 1;
                int sum = list[0][1];
                for (int i = 1; i < list.Count; i++)
                {
                    //Checking if the count is less than 5
                    if (list[i][0] == a && count < 5)
                    {
                        sum += list[i][1];
                        count += 1;
                    }
                    else if (list[i][0] != a)
                    {
                        results.Add(new int[,] { { a, sum / 5 } });

                        Console.Write("[[" + a + "," + sum / 5 + "]" + ",");
                        a = list[i][0];
                        count = 1;
                        sum = list[i][1];
                    }
                }
                results.Add(new int[,] { { a, sum / 5 } });
                Console.Write("[" + a + "," + sum / 5 + "]]");
                Console.WriteLine();

            }
            catch (Exception)
            {
                throw;
            }
        }

        //Question 8
        /// <summary>
        //Given an array, rotate the array to the right by k steps, where k is non-negative.
        //Print the Final array after rotation.
        //Example 1:
        //Input: nums = [1, 2, 3, 4, 5, 6, 7], k = 3
        //Output: [5,6,7,1,2,3,4]
        //Explanation:
        //rotate 1 steps to the right: [7,1,2,3,4,5,6]
        //rotate 2 steps to the right: [6,7,1,2,3,4,5]
        //rotate 3 steps to the right: [5,6,7,1,2,3,4]
        //Example 2:
        //Input: nums = [-1,-100,3,99], k = 2
        //Output: [3,99,-1,-100]
        //Explanation: 
        //rotate 1 steps to the right: [99,-1,-100,3]
        //rotate 2 steps to the right: [3,99,-1,-100]
        /// </summary>

        private static void RotateArray(int[] arr, int n)
        {
            try
            {

                int[] temp = new int[arr.Length - n];
                //Doing constraint check
                if (arr.Length >= 1 && arr.Length <= 105 && n >= 0 && n <= 105)
                {
                    //Taking the first (Length-n) elements and keeping them in temp array
                    for (int i = 0; i < arr.Length - n; i++)
                    {
                        if (arr[i] >= -231 && arr[i] <= 230)
                            temp[i] = arr[i];
                        else
                            throw new Exception();
                    }
                    //Taking the last n elements and placing them in the first n values of the array
                    for (int i = arr.Length - n; i < arr.Length; i++)
                    {
                        if (arr[i] >= -231 && arr[i] <= 230)
                            arr[i + n - arr.Length] = arr[i];
                        else
                            throw new Exception();
                    }
                    //Placing the temp array back into the array
                    for (int i = 0; i < arr.Length - n; i++)
                    {
                        if (arr[i] >= -231 && arr[i] <= 230)
                            arr[i + n] = temp[i];
                        else
                            throw new Exception();
                    }
                    Console.Write("[{0}", arr[0]);
                    for (int i = 1; i < arr.Length; i++)
                        Console.Write(",{0}", arr[i]);
                    Console.Write("]");
                }
                else
                    throw new Exception();
            }
            catch (Exception)
            {
                throw;
            }
            Console.WriteLine();
        }

        //Question 9
        /// <summary>
        //Given an integer array nums, find the contiguous subarray(containing at least one number) which has the largest sum and return its sum
        //Example 1:
        //Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
        //Output: 6
        //Explanation: [4,-1,2,1] has the largest sum = 6.
        //Example 2:
        //Input: nums = [1]
        //Output: 1
        // Example 3:
        // Input: nums = [5,4,-1,7,8]
        //Output: 23
        /// </summary>

        private static int MaximumSum(int[] arr)
        {
            try
            {
                //Doing the constraint check
                if (arr.Length >= 1 && arr.Length <= 30000)
                {
                    int sum = 0;
                    int max = 0;
                    for (int i = 0; i < arr.Length; i++)
                    {
                        //Doing the constraint check
                        if (arr[i] >= -100000 && arr[i] <= 100000)
                        {
                            //Add the number in scope to sum and check if it is greater than max.If yes, replace the previous value of max with the sum and complete the loop
                            sum += arr[i];
                            if (sum > max)
                                max = sum;
                        }
                        else
                            throw new Exception();
                    }
                    return max;
                }
                else
                    throw new Exception();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Question 10
        /// <summary>
        //You are given an integer array cost where cost[i] is the cost of ith step on a staircase.Once you pay the cost, you can either climb one or two steps.
        //You can either start from the step with index 0, or the step with index 1.
        //Return the minimum cost to reach the top of the floor.
        //Example 1:
        //Input: cost = [10, 15, 20]
        //Output: 15
        //Explanation: Cheapest is: start on cost[1], pay that cost, and go to the top.

        /// </summary>

        private static int MinCostToClimb(int[] costs)
        {
            try
            {
                int n = costs.Length;
                //Doing the constraint check
                if (n >= 2 && n <= 1000)
                {
                    for (int i = 2; i < n; i++)
                    {
                        //Doing the constraint check
                        if (costs[i] >= 0 && costs[i] <= 999)
                        {
                            //Computing the minimum of the two costs below the current cost and adding the current cost to it.
                            costs[i] = Math.Min(costs[i - 1], costs[i - 2]) + costs[i];
                        }
                    }
                }
                else
                    throw new Exception();
                return Math.Min(costs[n - 2], costs[n - 1]);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
