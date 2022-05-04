using System;
using System.Collections.Generic;

namespace Combination_Sum_II
{
  // https://leetcode.com/problems/subsets/discuss/27281/A-general-approach-to-backtracking-questions-in-Java-(Subsets-Permutations-Combination-Sum-Palindrome-Partitioning)
  class Program
  {
    static void Main(string[] args)
    {
      var candidates = new int[] { 10, 1, 2, 7, 6, 1, 5 };
      Program p = new Program();
      var result = p.CombinationSum2(candidates, 8);
    }

    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
      var result = new List<IList<int>>();
      Array.Sort(candidates);
      Backtracking(candidates, target, result, new List<int>(), 0, 0);
      return result;
    }

    private void Backtracking(int[] candidates, int target, List<IList<int>> result, List<int> temp, int currentSum, int start)
    {
      if (currentSum > target) return;
      else if (currentSum == target)
      {
        result.Add(new List<int>(temp));
      }
      else
      {
        for (int i = start; i < candidates.Length; i++)
        {
          if (i > start && candidates[i] == candidates[i - 1]) continue;
          temp.Add(candidates[i]);
          currentSum += candidates[i];
          Backtracking(candidates, target, result, temp, currentSum, i + 1);
          currentSum -= candidates[i];
          temp.RemoveAt(temp.Count - 1);
        }
      }
    }
  }
}
