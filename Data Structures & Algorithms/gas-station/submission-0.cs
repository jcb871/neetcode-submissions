public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        int totalGas =  gas.Sum(), totalCost = cost.Sum();
        if(totalCost > totalGas) return-1;
        
        int n = gas.Length;
        int start = 0, fuel = 0;
        for(int i=0; i<n; i++) {
            int newFuelLevel = gas[i] - cost[i];
            fuel += newFuelLevel;

            if(fuel < 0) {
                start = i+1;
                fuel = 0;
            }
        }
        return start;
    }
}
