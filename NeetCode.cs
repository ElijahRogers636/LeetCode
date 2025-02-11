using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class NeetCode
    {
        //<======================================== Contains Duplicate ========================================>
        public bool hasDuplicate(int[] nums)
        {
            var HSet = new HashSet<int>(nums);
            return HSet.Count < nums.Length;
        }

        //<======================================== Valid Anagram ========================================>
        public bool IsAnagram(string s, string t)
        {
            if (!(s.Length == t.Length))
            {
                return false;
            }
            int[] freqArr = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                freqArr[s[i] - 'a']++;
                freqArr[t[i] - 'a']--;
            }
            foreach (int i in freqArr)
            {
                if (i != 0)
                {
                    return false;
                }
            }
            return true;
        }

        //<======================================== Two Sum ========================================>
        public int[] TwoSum(int[] nums, int target)
        {
            var result = new int[2];
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    result[0] = dict[nums[i]];
                    result[1] = i;
                }
                dict.TryAdd(target - nums[i], i);
            }
            return result;
        }

        //<======================================== Group Anagrams ========================================>
        public List<List<string>> GroupAnagrams(string[] strs)
        {
            var dict = new Dictionary<string, List<string>>();
            foreach (var s in strs)
            {
                int[] freqArr = new int[26];
                for (int i = 0; i < s.Length; i++)
                {
                    freqArr[s[i] - 'a']++;
                }
                string strKey = string.Join(",", freqArr);
                if (!dict.ContainsKey(strKey))
                {
                    dict[strKey] = new List<string>();
                }
                dict[strKey].Add(s);
            }
            return dict.Values.ToList<List<string>>();
        }

        //<======================================== Top K Frequent Elements ========================================>
        public int[] TopKFrequent(int[] nums, int k)
        {
            //Use Priority Queue
            var result = new int[k];
            var res = new Dictionary<int, int>();
            // Freq hashmap
            foreach (int i in nums)
            {
                if (!res.TryAdd(i, 1))
                {
                    res[i]++;
                }
            }
            // Create a priority queue to save int and their frequency as priority
            var pQueue = new PriorityQueue<int, int>();
            foreach (var kvp in res)
            {
                pQueue.Enqueue(kvp.Key, kvp.Value);
            }
            //Loop k times and if priority queue count is greater than k, dequeue, decrement i, continue loop
            //Once priority queue count is equal to k, dequeue to result array
            for (int i = 0; i < k; i++)
            {
                if (pQueue.Count > k)
                {
                    pQueue.Dequeue();
                    i--;
                    continue;
                }
                result[i] = pQueue.Dequeue();
            }
            return result;
        }

        //<======================================== Encode and Decode Strings ========================================>
        public string Encode(IList<string> strs)
        {
            string res = "";
            foreach (string s in strs)
            {
                res += s.Length + "#" + s;
            }
            return res;
        }

        public List<string> Decode(string s)
        {
            List<string> res = new List<string>();
            int i = 0;
            while (i < s.Length)
            {
                int j = i;
                while (s[j] != '#')
                {
                    j++;
                }
                int length = int.Parse(s.Substring(i, j - i));
                i = j + 1;
                j = i + length;
                res.Add(s.Substring(i, length));
                i = j;
            }
            return res;
        }

        //<======================================== Products of Array Except Self ========================================>
        public int[] ProductExceptSelf(int[] nums)
        {
            int n = nums.Length;
            int[] output = new int[n];
            int[] prefix = new int[n];
            int[] suffix = new int[n];

            prefix[0] = 1;
            suffix[n - 1] = 1;
            for (int i = 1; i < n; i++)
            {
                prefix[i] = nums[i - 1] * prefix[i - 1];
            }
            for (int i = n - 2; i >= 0; i--)
            {
                suffix[i] = nums[i + 1] * suffix[i + 1];
            }
            for (int i = 0; i < n; i++)
            {
                output[i] = prefix[i] * suffix[i];
            }
            return output;
        }

        //<======================================== Valid Sudoku ========================================>
        public bool IsValidSudoku(char[][] board)
        {
            int len = board[0].Length;
            HashSet<int> tempSet;
            //Check rows are valid
            for (int i = 0; i < len; i++)
            {
                tempSet = new HashSet<int>();
                for (int j = 0; j < len; j++)
                {
                    int res = board[i][j] - '0';
                    if (!tempSet.Add(res) && res != '.' - '0') return false;
                }
            }
            //Check columns are valid
            for (int i = 0; i < len; i++)
            {
                tempSet = new HashSet<int>();
                for (int j = 0; j < len; j++)
                {
                    int res = board[j][i] - '0';
                    if (!tempSet.Add(res) && res != '.' - '0') return false;
                }
            }
            //Check 3x3 matrixes
            for (int k = 0; k < len; k++)
            {
                tempSet = new HashSet<int>();
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        int row = (k / 3) * 3 + i;
                        int col = (k % 3) * 3 + j;
                        int res = board[row][col] - '0';
                        if (!tempSet.Add(res) && res != '.' - '0') return false;
                    }
                }
            }
            return true;
        }

        //<======================================== Longest Consecutive Sequence ========================================>
        public int LongestConsecutive(int[] nums)
        {
            List<int> consecLens = new List<int>();
            if (nums.Length == 0) return 0;
            Array.Sort(nums);
            int count = 1;
            int prevNum = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == prevNum + 1)
                {
                    count++;
                }
                else if (i < nums.Length - 1 && nums[i] != prevNum)
                {
                    consecLens.Add(count);
                    count = 1;
                }
                prevNum = nums[i];
            }
            consecLens.Add(count);
            count = 0;
            foreach (int i in consecLens)
            {
                if (i > count)
                {
                    count = i;
                }
            }
            return count;
        }

        //<======================================== Valid Palindrome ========================================>
        public bool IsPalindrome(string s)
        {
            s = s.ToLower();
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                if (!AlphaNum(s[left]))
                {
                    left++;
                    continue;
                }
                if (!AlphaNum(s[right]))
                {
                    right--;
                    continue;
                }
                if (s[left] != s[right])
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }

        public bool AlphaNum(char c)
        {
            return (c >= 'a' && c <= 'z' ||
                    c >= '0' && c <= '9');
        }

        //<======================================== Two Integer Sum II ========================================>
        public int[] TwoSum2(int[] numbers, int target)
        {
            int l = 0;
            int r = numbers.Length - 1;
            int sum = 0;
            while (l < r)
            {
                sum = numbers[l] + numbers[r];
                if (numbers[l] == numbers[r]) continue;
                if (sum > target)
                {
                    r--;
                    continue;
                }
                if (sum < target)
                {
                    l++;
                    continue;
                }
                break;
            }
            return new int[] { l + 1, r + 1 };
        }

        //<======================================== Valid Parentheses ========================================>
        public bool IsValid(string s)
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

        //<======================================== Evaluate Reverse Polish Notation ========================================>
        public int EvalRPN(string[] tokens)
        {
            //if string is numeric convert to int and push to stack
            // if not solve equation, push( pop() operator pop() )
            // Continue until end of array
            // return top of stack
            Stack<int> stack = new Stack<int>();
            foreach (var s in tokens)
            {
                if (int.TryParse(s, out int i))
                {
                    stack.Push(i);
                }
                else
                {
                    stack.Push(OperatorCheck(stack.Pop(), stack.Pop(), s));
                }
            }
            return stack.Pop();
        }

        public int OperatorCheck(int pop1, int pop2, string oper)
        {
            switch (oper)
            {
                case "+":
                    return pop2 + pop1;
                case "-":
                    return pop2 - pop1;
                case "*":
                    return pop2 * pop1;
                case "/":
                    return pop2 / pop1;
            }
            return -1;
        }

        //<======================================== 3151. Special Array I ========================================>
        public bool IsArraySpecial(int[] nums)
        {
            bool isEven = IsEven(nums[0]);
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] % 2 == 0 && isEven != false)
                {
                    return false;
                }
                if (nums[i] % 2 != 0 && isEven == false)
                {
                    return false;
                }
                isEven = IsEven(nums[i]);
            }
            return true;
        }

        bool IsEven(int num)
        {
            if (num % 2 == 0)
            {
                return true;
            }
            return false;
        }

        //<======================================== 1910. Remove All Occurrences of a Substring ========================================>
        public string RemoveOccurrences(string s, string part)
        {
            StringBuilder tempS = new StringBuilder(s);
            int index = 0;
            while (index != -1)
            {
                index = s.IndexOf(part);
                if (index != -1)
                {
                    tempS.Remove(index, part.Length);
                    s = tempS.ToString();
                }
            }
            return s;
        }

        //<========================================  ========================================>





    }
}
