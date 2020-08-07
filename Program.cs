using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text.RegularExpressions;


namespace testingapp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testarray =  {17,18,5,4,6,1};
            Console.Write(string.Join(",",ReplaceElements(testarray)));
        }

        static public int[] ReplaceElements(int[] arr) {
            int largestnumber = -1;
            for(int i = arr.Length-1; i >= 0 ; i--){
                int tmp = arr[i];
                arr[i]=largestnumber;
                largestnumber = Math.Max(largestnumber,tmp);
            }
            return arr;
        }



        static bool ValidMountainArray(int[] A){
            if(A.Length<3){
                return false;
            }
            int i = 0;
            int p = 1;
            
            if(A[i]>A[p]){
                return  false;
            }

            while(A[i]<A[p]){
                i++;
                p++;

                if(p==A.Length){
                    return false;
                }
            }
            if(A[i]==A[p]){
                return false;
            }

            while(p<A.Length && A[i]>A[p]){
                i++;
                p++;
            }
            
            if(p==A.Length){
                return true;
            }else{
                return false;
            }
            
        }




        static public bool CheckIfExist(int[] arr){
            Dictionary<int,int> doubledlist = new Dictionary<int, int>();
            for(int i = 0; i<arr.Length;i++){
                if(!doubledlist.ContainsKey(arr[i]*2)){
                    doubledlist.Add(arr[i]*2,i);
                }
                
            }
            for(int i = 0; i<arr.Length;i++){
                if(doubledlist.ContainsKey(arr[i])&&doubledlist[arr[i]]!=i){
                    return true;
                }
            }
            return false;
        }



        static public int RemoveElement(int[] nums)
        {
            if(nums.Length==1){
                return nums.Length;
            }
            int dval = 0;
            for(int i = 0; i<nums.Length-dval;i++){
                
                    while(nums[i]==nums[i+1]&&i<nums.Length-dval){
                        dval++;
                        for(int itwo = i+1;itwo<nums.Length-dval;itwo++){
                            nums[itwo]=nums[itwo+1];
                        }
                        
                    }

                
                
            }

            return nums.Length-dval+1;

        }


        static public int FindMaxones(int[] nums){
            int result =0;
            foreach(int num in nums){
                if(num ==1){
                    result++;
                }
            }
            return result;
        }






        static public int MyAtoi(string str) {
        if (string.IsNullOrEmpty(str)) { return 0; }
        
        int res = 0, i = 0, sign = 1;
        
        while (i < str.Length && Char.IsWhiteSpace(str[i])) { i++; }
        
        if (i < str.Length && (str[i] == '-' || str[i] == '+')) {
            sign = str[i++] == '-' ? -1 : 1;
        }
        
        while (i < str.Length && Char.IsDigit(str[i])) {
            int dig = str[i++] - '0';
            int threshold = (int.MaxValue - dig) / 10;
            
            if (res > threshold) {
                return sign == -1 ? int.MinValue : int.MaxValue;
            }
            
            res = res * 10 + dig;
        }
        
        return res * sign;
    }



        static public int LengthOfLongestSubstring(String s)
        {
            int msc = 0;
            Dictionary<char, int> map = new Dictionary<char, int>();
            for(int wl = 0, wr = 0; wr < s.Length; wr++)
            {
                if (map.ContainsKey(s[wr]))
                {
                    wl = Math.Max(map[s[wr]], wl);
                }
                msc = Math.Max(msc, wr - wl + 1);
                map[s[wr]] = wr + 1;
            }

            return msc;

        }


        static public int findlongeststring(string s)
        {
            int pointer_a = 0;
            int pointer_b = 0;
            int result = 0;
            HashSet<int> map = new HashSet<int>();
            while (pointer_b < s.Length)
            {
                if (!map.Contains(s[pointer_b])){
                    map.Add(s[pointer_b++]);
                    result = Math.Max(map.Count, result);
                }
                else
                {
                    map.Remove(s[pointer_a++]);
                    
                }
            }
            return result;
        }




        static public int HeightChecker(int[] heights)
        {
            int[] tarray = (int[])heights.Clone();
            Array.Sort(tarray);
            int ans = 0;
            for (int pointer = 0; pointer < heights.Length; pointer++)
            {
                
                if(heights[pointer] != tarray[pointer])
                {
                    ans++;
                    
                }
            }
            return ans;
        }

        static public int FindLength(int[] A, int[] B)
        {
            List<int> list = new List<int>();
            List<int> templist = new List<int>();
            int index = 0;


            for (int pa = 0, pb = 0; index < B.Length; index++)
            {

                while (pa < A.Length)
                {
                    
                    if (pb==B.Length||A[pa] == B[pb])
                    {
                        while (A[pa] == B[pb])
                        {
                            templist.Add(A[pa]);

                            pa++;
                            pb++;

                            if (pa == A.Length || pb ==B.Length|| A[pa] != B[pb])
                            {
                                break;
                            }

                        }

                        if (list.Count < templist.Count)
                        {
                            list = templist;
                            templist.Clear();
                        }

                    }
                    pa++;
                }
                


            }
            int[] ans = list.ToArray();

            return ans.Length;
        }


    }   
}
