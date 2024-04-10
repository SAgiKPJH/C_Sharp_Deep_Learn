using System.Threading.Tasks.Dataflow;

var multipleBlock = new TransformBlock<int, int>(item => item * 2);
var subtracBlock = new TransformBlock<int, int>(item => item - 2);

// 일반 연결
IDisposable link = multipleBlock.LinkTo(subtracBlock);
link.Dispose(); // 연결 해제

// Option 연결
var flowOptions = new DataflowLinkOptions
{
    PropagateCompletion = true, // 완료 및 오류 전파
};

var blockOptions = new ExecutionDataflowBlockOptions
{
    // 각 데이터 항목은 블록 처리를 시작할 때 슬롯을 차지
    MaxDegreeOfParallelism = DataflowBlockOptions.Unbounded // 동시성의 수준, 슬롯의 수 결정. 병렬처리 무한대
};

multipleBlock.LinkTo(subtracBlock, flowOptions);
await multipleBlock.SendAsync(10);
int result = await subtracBlock.ReceiveAsync();
Console.WriteLine($"Result = {result}");

try
{
    try
    {
        var exceptionMultipleBlock = new TransformBlock<int, int>(item =>
        {
            if (item == 1)
                throw new InvalidOperationException("Error");
            return item * 2;
        }, blockOptions);

        exceptionMultipleBlock.LinkTo(subtracBlock, flowOptions);

        exceptionMultipleBlock.Post(1);
        exceptionMultipleBlock.Post(2);
     
        exceptionMultipleBlock.Complete();
    }
    catch (InvalidOperationException)
    {
        Console.WriteLine("catch InvalidOperationException");
    }

    // 첫 번째 블록의 완료를 두 번째 블록에 전파
    await subtracBlock.Completion;
}
catch (AggregateException)
{
    Console.WriteLine("catch AggregateException");
}

IPropagatorBlock<int, int> CreateMyCustomBlock()
{
    var multiplyBlock = new TransformBlock<int, int>(item => item * 2);
    var addBlock = new TransformBlock<int, int>(item => item + 2);
    var divideBlock = new TransformBlock<int, int>(item => item / 2);

    var flowCompletion = new DataflowLinkOptions { PropagateCompletion = true };
    multipleBlock.LinkTo(addBlock, flowCompletion);
    addBlock.LinkTo(divideBlock, flowCompletion);

    return DataflowBlock.Encapsulate(multipleBlock, divideBlock);
}