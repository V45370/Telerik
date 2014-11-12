function Solve(input) {
	
	var inputArr = input.map(Number);
	var max_so_far  = inputArr[1]
	var max_ending_here = inputArr[1]; 
		
 
		// Find sequence by looping through
		for(var i = 2; i < inputArr.length; i++)
		{
			// calculate max_ending_here
			if(max_ending_here < 0)
			{
				max_ending_here = inputArr[i];
 
				// begin_temp = i;
			}
			else
			{
				max_ending_here += inputArr[i];
			}
 
		// calculate max_so_far
			if(max_ending_here >= max_so_far )
			{
				max_so_far  = max_ending_here;
 
				// begin = begin_temp;
				// end = i;
			}
		}
		
		return max_so_far;


}
var input = [
8,
1,
6,
-9,
4,
4,
-2,
10,
-1,
];
var input2 = [
	6,
1,
3,
-5,
8,
7,
-6,

];
var input3 = [
	9,
-9,
-8,
-8,
-7,
-6,
-5,
-1,
-7,
-6,

];
Solve(input);
Solve(input2);
Solve(input3);
