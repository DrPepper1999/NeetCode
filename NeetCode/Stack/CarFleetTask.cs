namespace NeetCode;

/*
Есть n автомобилей, едущие к одному месту назначения на шоссе с одной полосой.
    Вам дают два массива положения и скорости целых чисел, обе длина n.

    Положение [i] является позицией автомобиля (в милях)
    Скорость [i] - это скорость автомобиля (в милях в час)

    Пункт назначения находится в позиции целевых миль.
    Автомобиль не может пройти еще одну машину впереди. Он может догнать только другую машину, а затем ездить на той же скорости, что и автомобиль впереди.
    Автомобильный флот-это непустые автомобили, едущие в том же положении и той же скорости. Один автомобиль также считается автомобильным парком.
    Если машина догоняет автомобильный флот в тот момент, когда флот достигает места назначения, то автомобиль считается частью флота.
    Верните количество различных автомобильных флотов, которые поступят в пункт назначения.

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