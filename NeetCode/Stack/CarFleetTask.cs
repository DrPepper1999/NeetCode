namespace NeetCode;

/*
    There are n cars traveling to the same destination on a one-lane highway.
    You are given two arrays of integers position and speed, both of length n.

    position[i] is the position of the ith car (in miles)
    speed[i] is the speed of the ith car (in miles per hour)

    The destination is at position target miles.
    A car can not pass another car ahead of it. It can only catch up to another car and then drive at the same speed as the car ahead of it.
    A car fleet is a non-empty set of cars driving at the same position and same speed. A single car is also considered a car fleet.
    If a car catches up to a car fleet the moment the fleet reaches the destination, then the car is considered to be part of the fleet.
    Return the number of different car fleets that will arrive at the destination.

    Input: target = 10, position = [1,4], speed = [3,2]
    Output: 1

    Input: target = 10, position = [4,1,0,7], speed = [2,2,1,1]
    Output: 3
 */
public class CarFleetTask
{
    record Fleet(int Position, int Speed)
    {
        public bool IsCatchesUp(Fleet otherFleet, int target)
        {
            return CalcTimeToTarget(target) <= otherFleet.CalcTimeToTarget(target);
        }

        private double CalcTimeToTarget(int target)
        {
            return (double)(target - Position) / Speed;
        }
    }

    public static int CarFleet(int target, int[] position, int[] speed)
    {
        var feels = position
            .Zip(speed, (position, speed) => new Fleet(position, speed))
            .OrderByDescending(car => car.Position);

        var stack = new Stack<Fleet>();
        foreach (var feel in feels)
        {
            if (stack.Count == 0)
            {
                stack.Push(feel);
                continue;
            }

            var frontFeel = stack.Pop();
            if (feel.IsCatchesUp(frontFeel, target))
            {
                stack.Push(
                    new Fleet(Math.Max(feel.Position, frontFeel.Position), Math.Min(feel.Speed, frontFeel.Speed)));
            }
            else
            {
                stack.Push(frontFeel);
                stack.Push(feel);
            }
        }

        return stack.Count;
    }
}