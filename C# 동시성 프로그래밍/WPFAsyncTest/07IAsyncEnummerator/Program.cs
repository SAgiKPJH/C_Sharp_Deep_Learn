using System;
using System.Collections;
namespace Enumerable;


class MyList : IEnumerable, IEnumerator
{
    private int[] array;
    int position = -1;  // 컬렉션의 현재 위치를 다루는 변수, 첫 번째 반복 때 0이 되어야 하므로 

    public MyList()
    {
        array = new int[3];
    }

    public int this[int index]
    {
        get { return array[index]; }

        set
        {
            if (index >= array.Length)
            {
                Array.Resize<int>(ref array, index + 1);
                Console.WriteLine($"Array Resized : {array.Length}");
            }
            array[index] = value;
        }
    }

    // IEnumerator 멤버
    public object Current
    {  // 현재 위치의 요소 반환
        get { return array[position]; }
    }

    // IEnumerator 멤버
    public bool MoveNext()
    {  // 다음 위치의 요소로 이동
        if (position == array.Length - 1)
        {
            Reset();
            return false;
        }
        position++;
        return (position < array.Length);
    }

    // IEnumerator 멤버
    public void Reset()
    {  // IEnumerator로부터 상속받은 Reset()메소드, 요소의 위치를 첫 요소의 "앞"으로 옮김
        position = -1;
    }

    // IEnumerable 멤버
    public IEnumerator GetEnumerator()
    {
        return this;
    }
}

public class MyListAsync : IAsyncEnumerable<int>
{
    private int[] array;

    public MyListAsync()
    {
        array = new int[3];
    }

    public int this[int index]
    {
        get => array[index];
        set
        {
            if (index >= array.Length)
            {
                Array.Resize(ref array, index + 1);
                Console.WriteLine($"Array Resized : {array.Length}");
            }
            array[index] = value;
        }
    }

    public IAsyncEnumerator<int> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        return new AsyncEnumerator(array);
    }

    private class AsyncEnumerator : IAsyncEnumerator<int>
    {
        private readonly int[] _array;
        private int _position = -1;

        public AsyncEnumerator(int[] array)
        {
            _array = array;
        }

        public int Current => _array[_position];

        public ValueTask<bool> MoveNextAsync()
        {
            if (_position < _array.Length - 1)
            {
                _position++;
                return new ValueTask<bool>(true);
            }
            else
            {
                return new ValueTask<bool>(false);
            }
        }

        public ValueTask DisposeAsync()
        {
            // 여기에 필요한 정리 작업을 수행합니다.
            return new ValueTask();
        }
    }

}

class MainApp
{
    static async Task Main(string[] args)
    {
        MyListAsync list = new MyListAsync();
        for (int i = 0; i < 5; i++)
            list[i] = i;

        await foreach (int e in list)
            Console.WriteLine(e);
    }
}