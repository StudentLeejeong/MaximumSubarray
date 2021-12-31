using System;

namespace MaximumSubarray
{
    class Program
    {
        static void Main(string[] args)
        {
            int [] Price = new int[] { 100, 113, 110, 85, 105, 102, 86, 63, 81, 101, 94, 106, 101, 79, 94, 90, 97 };
            //
            // Price : 100 113 110 85 105 102 86 63 81 101 94 106 101 79 94 90 97
            int[] DiffPrice = new int[Price.Length - 1];
            for (int i = 0; i < DiffPrice.Length; i++)
            {
                DiffPrice[i] = Price[i + 1] - Price[i];
            }
            // DiffPrice : 13 -3 -25 20 -3 -16 -23 18 20 -7 12 -5 -22 15 -4 7
            foreach (int diffPrice in DiffPrice)
            {
                Console.Write(diffPrice + " ");
            }

            int a, b, c;
            (a,b,c) =  Find_Max_Crossing_Subarray(DiffPrice, 0, DiffPrice.Length/2, DiffPrice.Length-1);
            (a, b, c) = Fine_Maximum_Subarray(DiffPrice, 0, DiffPrice.Length - 1);

            Console.WriteLine("\n{0} {1} {2}\n",a, b, c);

        }
        static int number = 0;
        static (int,int,int) Fine_Maximum_Subarray(int[] A,int low,int high)
        {
            if(high == low)
            {
                return (low, high, A[low]);
            }
            else
            {s
                int mid = (low + high) / 2;
                Console.WriteLine("{0}st 시도", number);
                number++;
                Console.WriteLine("low : {0} mid {1}", low, mid);
                (int leftLow, int leftHigh, int leftSum) = Fine_Maximum_Subarray(A, low, mid);
                Console.WriteLine(" leftLow {0}, leftHigh{1}, leftSum {2}", leftLow, leftHigh, leftSum);

                Console.WriteLine("(mid+1): {0} high : {1}", mid + 1, high);
                (int rightlow, int righthigh, int rightsum) = Fine_Maximum_Subarray(A, mid + 1, high);
                Console.WriteLine(" rightlow {0}, righthigh{1}, rightsum {2}", rightlow, righthigh, rightsum);

                Console.WriteLine("low {0} mid {1} high {2}", low, mid, high);
                (int crosslow, int crosshigh, int crosssum) = Find_Max_Crossing_Subarray(A, low, mid, high);
                Console.WriteLine(" crosslow {0}, crossHigh {1}, crossum {2}", crosslow, crosshigh, crosssum);

                if(leftSum >= rightsum && leftSum >=crosssum)
                {
                    return (leftLow, leftHigh, leftSum);
                }
                else if(rightsum >=leftSum && rightsum >=crosssum)
                {
                    return (rightlow, righthigh, rightsum);
                }
                else
                {
                    return (crosslow, crosshigh, crosssum);
                }
            }
        }
        // 1st
        // mid = 15/2 =7
        // Fine_Maximum_Subarray(A,0,7)
        // 2st
        // mid = 7/2 = 3
        // Fine_Maximum_Subarray(A,0,3)
        // 3st
        // mid = 3/2 = 1
        // Fine_Maximum_Subarray(A,0,1)
        //4st
        //mid =1/2 =0
        //Fine_Maximum_Subarray(A,0,0)
        //5st
        //return (0,0,A[0]
        //6st
        //(leftLow,leftHigh,leftSum) = (0,0,A[0])
        //7st
        //Fine_Maximum_Subarray(A,1,1)
        //8st
        //return (1,1,A[1])
        //9st
        //rightlow,rightHigh,rightSum = (1,1,A[1])
        //10st
        //crosslow,crosshigh,crosssum = (


        static (int,int,int) Find_Max_Crossing_Subarray(int[] A,int low,int mid,int high)
        {
            int leftSum = int.MinValue;//임시로 설정 
            int maxLeft=mid;
            int sum = 0;

            for (int i = mid; i >= low; i-- )
            {
                sum = sum + A[i];
                
                if(sum > leftSum)
                {
                    leftSum = sum;
                    maxLeft = i;
                }

            }
            
            int rightSum = int.MinValue;
            int maxRight = 0 ;
            sum = 0;


            for(int j = mid+1;j<=high;j++)
            {
                sum = sum + A[j];

                if(sum > rightSum)
                {
                    rightSum = sum;
                    maxRight = j;
                }
            }
           // Console.WriteLine("\nleftSum : {0} , rightSum : {1}", leftSum, rightSum);

            return (maxLeft, maxRight, leftSum + rightSum);

        }
        
    }
}
