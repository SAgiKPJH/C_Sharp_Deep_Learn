IEnumerable<int> GetNumbers()
{
    for (int i = 0; i < 5; i++)
    {
        // 여기서 i의 값을 반환하고, 다음 호출까지 실행을 중지합니다.
        yield return i;
    }
}

foreach (var number in GetNumbers())
{
    Console.WriteLine(number); // 0, 1, 2, 3, 4를 출력합니다.
}