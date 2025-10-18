using System;
using System.Collections.Generic;


var nums = new int[] {2, 3, 4, 6, 8, 10};

var target = 12;

var result = TwoSums(nums, target);

Console.WriteLine(string.Join(", ", result));



static int[] TwoSums(int[] nums, int target){

  var map = new Dictionary<int, int>();

  for(int i = 0; i < nums.Length; i++){

    var complement = target - nums[i];

    if(map.ContainsKey(complement)){

      return new int[] {map[complement],i};
    }

    map[nums[i]] = i;
  }

  return new int[] {-1, -1};
}