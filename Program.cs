using System.Text;

namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        //<==================================== 507. Perfect Number ===================================>
        public bool CheckPerfectNumber(int num)
        {
            int sum = 0;
            for (int i = 1; i < num; i++)
            {
                if ((num % i) == 0)
                {
                    sum += i;
                }
            }
            if (sum == num)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //<==================================== 704. Binary Search ===================================>
        public int Search(int[] nums, int target)
        {
            int i = 0;
            if (target >= nums[nums.Length / 2])
            {
                i = nums.Length / 2;
            }
            while (i < nums.Length)
            {
                if (nums[i] == target)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        //<==================================== 20. Valid Parentheses ===================================>
        public bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();
            var dict = new Dictionary<char, char>()
            {
                { ')', '(' },
                { '}', '{' },
                { ']', '[' }
            };

            foreach (char c in s)
            {
                // If it's a closing bracket, check for match
                if (dict.TryGetValue(c, out char result))
                {
                    // Check if the stack is empty or the top doesn't match
                    if (stack.Count == 0 || stack.Pop() != result)
                    {
                        return false;
                    }
                }
                else
                {
                    // If it's an opening bracket, push to stack
                    stack.Push(c);
                }
            }

            // If the stack is empty, all parentheses are matched
            return stack.Count == 0;
        }

        public bool IsValid2(string s)
        {
            Stack<char> paraStack = new Stack<char>();
            paraStack.Push(s[0]);
            for (int i = 1; i < s.Length; i++)
            {
                if (paraStack.Count != 0 && s[i] == ParaChecker(paraStack.Peek()))
                {
                    paraStack.Pop();
                }
                else
                {
                    paraStack.Push(s[i]);
                }
            }
            return paraStack.Count == 0;
        }

        public char ParaChecker(char c)
        {
            switch (c)
            {
                case '[':
                    return ']';
                case '{':
                    return '}';
                case '(':
                    return ')';
            }
            return 'n';
        }

        //<==================================== 9. Palindrome Number ===================================>
        public bool IsPalindrome(int x)
        {
            int temp = x;
            int reversedNum = 0;

            if (x == 0) return true;
            if (x < 0 || x % 10 == 0) return false;

            while (temp != 0)
            {

                reversedNum = (reversedNum * 10) + temp % 10;
                temp = temp / 10;
            }
            return reversedNum == x;
        }

        //<==================================== 58. Length of Last Word ===================================>
        public int LengthOfLastWord(string s)
        {
            s = s.Trim();
            string[] subStrings = s.Split(" ");

            return subStrings[subStrings.Length - 1].Length;
        }

        //<==================================== 605. Can Place Flowers ===================================>
        public bool CanPlaceFlowers(int[] flowerbed, int seeds)
        {
            int plotLength = flowerbed.Length;
            int i = 0;
            while (i < plotLength && seeds > 0)
            {
                if (flowerbed[i] == 0 && (i == 0 || flowerbed[i - 1] == 0) && (i == plotLength - 1 || flowerbed[i + 1] == 0))
                {
                    flowerbed[i] = 1;
                    seeds--;
                    i += 2;
                }
                else
                {
                    i++;
                }
            }
            return seeds <= 0;
        }

        //<==================================== 70. Climbing Stairs ===================================>
        public int ClimbStairs(int steps)
        {
            int x1 = 0;
            int x2 = 1;
            int current = 0;
            for (int i = 0; i < steps; i++)
            {
                current = x1 + x2;
                x1 = x2;
                x2 = current;
            }
            return current;
        }

        //<==================================== 268. Missing Number ===================================>
        public int MissingNumber(int[] nums)
        {
            int n = nums.Length;
            int num = 0;
            int num2 = 0;
            for (int i = 0; i < n + 1; i++)
            {
                num += i;
                if (i < n)
                {
                    num2 += nums[i];
                }
            }
            return num - num2;
        }

        //<==================================== 1768. Merge Strings Alternately ===================================>
        public string MergeAlternately(string word1, string word2)
        {
            StringBuilder sb = new StringBuilder();
            int word1Len = word1.Length;
            int word2Len = word2.Length;
            int longestLen = Math.Max(word1Len, word2Len);

            for (int i = 0; i < longestLen; i++)
            {
                if (i < word1Len)
                {
                    sb.Append(word1[i]);
                }
                if (i < word2Len)
                {
                    sb.Append(word2[i]);
                }
            }

            return sb.ToString();
        }

        //<==================================== 345. Reverse Vowels of a String ===================================>
        public string ReverseVowels(string word)
        {
            StringBuilder sb = new StringBuilder(word);

            int leftPointer = 0;
            int rightPointer = word.Length - 1;
            while (leftPointer < rightPointer)
            {
                if ("aeiouAEIOU".Contains(word[leftPointer]) && "aeiouAEIOU".Contains(word[rightPointer]))
                {
                    (sb[leftPointer], sb[rightPointer]) = (sb[rightPointer], sb[leftPointer]);
                    leftPointer++;
                    rightPointer--;
                }
                if (!"aeiouAEIOU".Contains(word[leftPointer]))
                {
                    leftPointer++;
                }
                if (!"aeiouAEIOU".Contains(word[rightPointer]))
                {
                    rightPointer--;
                }
            }
            return sb.ToString();
        }

        //<==================================== 242. Valid Anagram ===================================>
        public bool IsAnagram(string word1, string word2)
        {
            if (word1.Length != word2.Length) return false;
            int n = word1.Length;
            var charCounter = new int[128];

            for (int i = 0; i < n; i++)
            {
                charCounter[word1[i]]++;
            }
            for (int i = 0; i < n; i++)
            {
                charCounter[word2[i]]--;
                if (charCounter[word2[i]] < 0)
                {
                    return false;
                }
            }
            for (int i = 0; i < 26; i++)
            {
                if (charCounter[i] > 0)
                    return false;
            }

            return true;
        }

        //<==================================== 1431. Kids With the Greatest Number of Candies ===================================>
        public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            bool[] temp = new bool[candies.Length];
            int max = 0;
            for (int i = 0; i < candies.Length; i++)
            {
                max = Math.Max(max, candies[i]);
            }

            for (int i = 0; i < candies.Length; i++)
            {
                if (candies[i] + extraCandies >= max)
                {
                    temp[i] = true;
                }
                else
                {
                    temp[i] = false;
                }
            }
            return temp;
        }

        //<==================================== 283. Move Zeroes ===================================>
        public void MoveZeroes(int[] nums)
        {
            int n = nums.Length;
            int i = 0;
            int j = 0;
            while (i < n && j < n)
            {
                // Find the zero
                if (nums[i] != 0)
                {
                    i++;
                    j = i;
                    continue;
                }
                // Find the non zero
                if (nums[j] == 0)
                {
                    j++;
                    continue;
                }
                (nums[i], nums[j]) = (nums[j], nums[i]);
            }
        }

        //<==================================== 392. Is Subsequence ===================================>
        public bool IsSubsequence(string s, string t)
        {
            if (s.Length == 0) return true;
            if (t.Length == 0 && s.Length != 0) return false;
            int j = 0;
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i] == s[j])
                {
                    j++;
                    if (j == s.Length)
                    {
                        return true;
                    }
                }
            }
            return j == s.Length;
        }

        //<==================================== 643. Maximum Average Subarray I ===================================>
        public double FindMaxAverage(int[] nums, int k)
        {
            double total = 0;
            for (int i = 0; i < k; i++)
            {
                total += nums[i];
            }
            int fi = 0;
            int li = k;
            double mAvg = total / k;
            while (li < nums.Length)
            {
                total = total - nums[fi] + nums[li];
                mAvg = Math.Max(mAvg, total / k);
                fi++;
                li++;
            }
            return mAvg;
        }

        //<==================================== 1732. Find the Highest Altitude ===================================>
        public int LargestAltitude(int[] gain)
        {
            int highestAlt = 0;
            int currAlt = 0;
            for (int i = 0; i < gain.Length; i++)
            {
                currAlt = currAlt + gain[i];
                if (currAlt > highestAlt)
                {
                    highestAlt = currAlt;
                }
            }
            return highestAlt;
        }

        //<==================================== 724. Find Pivot Index ===================================>
        public int PivotIndex(int[] nums)
        {
            int leftSum = 0;
            int rightSum = 0;
            int sum = 0;
            //Get total sum of array values
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }

            for (int i = 0; i < nums.Length; i++)
            {
                // Find rightSum by subtracting left summation and current index value (nums[i]) from total sum
                rightSum = sum - leftSum - nums[i];
                //Check if left and right match, if so return current index(i)
                if (leftSum == rightSum)
                {
                    return i;
                }
                // Find leftSum by Adding current index value to current value of leftSum
                leftSum += nums[i];
            }
            return -1;
        }

        //<==================================== 2215. Find the Difference of Two Arrays ===================================>
        public IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
        {
            HashSet<int> answer1 = new HashSet<int>(nums1);
            HashSet<int> answer2 = new HashSet<int>(nums2);
            List<IList<int>> list = new List<IList<int>>();
            foreach (int i in answer1)
            {
                if (answer2.Contains(i))
                {
                    answer1.Remove(i);
                    answer2.Remove(i);
                }
            }
            list.Add(answer1.ToList());
            list.Add(answer2.ToList());
            return list;
        }

        //<==================================== 1207. Unique Number of Occurrences ===================================>
        public bool UniqueOccurrences(int[] arr)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            HashSet<int> set = new HashSet<int>();
            foreach (int i in arr)
            {
                if (!dict.TryAdd(i, 1))
                {
                    dict[i]++;
                }
            }
            foreach (var i in dict)
            {
                if (!set.Add(i.Value)) return false;
            }
            return true;
        }

        //<==================================== 1769. Minimum Number of Operations to Move All Balls to Each Box ===================================>
        public int[] MinOperations(string boxes)
        {
            int n = boxes.Length;
            int[] ans = new int[n];

            int opLeft = 0;
            int countLeft = 0;
            for (int i = 0; i < n; i++)
            {
                ans[i] += opLeft;
                countLeft += Convert.ToInt32(boxes[i].ToString());
                opLeft += countLeft;
            }
            int opRight = 0;
            int countRight = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                ans[i] += opRight;
                countRight += Convert.ToInt32(boxes[i].ToString());
                opRight += countRight;

            }
            return ans;
        }

        //<==================================== 1408. String Matching in an Array ===================================>
        public IList<string> StringMatching(string[] words)
        {
            var set = new HashSet<string>();
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words.Length; j++)
                {
                    if (words[i].IndexOf(words[j]) != -1 && j != i)
                    {
                        set.Add(words[j]);
                    }
                }
            }
            var lst = new List<string>();
            foreach (var i in set)
            {
                lst.Add(i);
            }
            return lst;
        }

        //<==================================== 3042. Count Prefix and Suffix Pairs I ===================================>
        public int CountPrefixSuffixPairs(string[] words)
        {
            int count = 0;
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = i + 1; j < words.Length; j++)
                {
                    if (isPrefixAndSuffix(words[i], words[j]))
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        bool isPrefixAndSuffix(string str1, string str2)
        {
            int n = str1.Length;
            if (n > str2.Length) return false;
            for (int i = 0; i < n; i++)
            {
                if (str1[i] != str2[i] || str1[n - i - 1] != str2[str2.Length - i - 1])
                {
                    Console.WriteLine("check");
                    return false;
                }
            }
            return true;
        }

        //<==================================== 2185. Counting Words With a Given Prefix ===================================>
        public int PrefixCount(string[] words, string pref)
        {
            int prefLen = pref.Length;
            int count = 0;
            foreach (var i in words)
            {
                if (i.Length < prefLen)
                {
                    continue;
                }
                if (i.Substring(0, prefLen) == pref)
                {
                    count++;
                }
            }
            return count;
        }

        //<==================================== 1400. Construct K Palindrome Strings ===================================>
        public bool CanConstruct(string s, int k)
        {
            // Covers single letter edge case
            if (s.Length == k)
            {
                return true;
            }
            // If word length is less than k return false. All letters must be used to create k palindromes
            if (s.Length < k)
            {
                return false;
            }

            var dict = new Dictionary<char, int>();
            // Freq dicionary for string
            foreach (var c in s)
            {
                if (!dict.TryAdd(c, 1))
                {
                    dict[c]++;
                }
            }

            // Check to see if char count of odds is greater than k
            int oddCount = 0;
            foreach (var kvp in dict)
            {
                if (kvp.Value % 2 != 0)
                {
                    oddCount++;
                }
                if (oddCount > k) return false;
            }
            return true;
        }

        //<==================================== 3223. Minimum Length of String After Operations ===================================>
        public int MinimumLength(string s)
        {
            int n = s.Length;
            // String length must be 3 or more to perform operations
            if (n < 3) return n;

            // set up freq array
            int[] freqArr = new int[26];
            foreach (var c in s)
            {
                freqArr[c - 'a']++;
            }

            //Create a new int to account for char removals
            int result = n;
            int currIndex;
            //Loop through stringbuilder string
            for (int i = 0; i < n; i++)
            {
                currIndex = s[i] - 'a';
                // If char value is less than 3 keep looping, else save index
                if (freqArr[currIndex] >= 3)
                {
                    freqArr[currIndex] -= 2;
                    result -= 2;
                }
            }
            return result;
        }




    }
}

