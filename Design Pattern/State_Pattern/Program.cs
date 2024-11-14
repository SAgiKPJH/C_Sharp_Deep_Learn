Console.WriteLine("\n\n------분기 판단--------\n");

var mario1 = new State_Pattern.분기판단.MarioStateMachine();
Console.WriteLine($"Socre : {mario1.Score}, State : {mario1.CurrentState}");
mario1.ObtainCape();
Console.WriteLine($"Socre : {mario1.Score}, State : {mario1.CurrentState}");


Console.WriteLine("\n\n------테이블 조회--------\n");

var mario2 = new State_Pattern.테이블_조회.MarioStateMachine();
Console.WriteLine($"Socre : {mario2.Score}, State : {mario2.CurrentState}");
mario2.ObtainMushroom();
Console.WriteLine($"Socre : {mario2.Score}, State : {mario2.CurrentState}");
mario2.ObtainCape();
Console.WriteLine($"Socre : {mario2.Score}, State : {mario2.CurrentState}");
mario2.ObtainFire();
Console.WriteLine($"Socre : {mario2.Score}, State : {mario2.CurrentState}");
mario2.MeetMonster();
Console.WriteLine($"Socre : {mario2.Score}, State : {mario2.CurrentState}");


Console.WriteLine("\n\n------상태 패턴--------\n");

var mario3 = new State_Pattern.상태_패턴.MarioStateMachine();
Console.WriteLine($"Socre : {mario3.Score}, State : {mario3.GetCurrentState()}");
mario3.ObtainMushRoom();
Console.WriteLine($"Socre : {mario3.Score}, State : {mario3.GetCurrentState()}");
mario3.ObtainMushRoom();
Console.WriteLine($"Socre : {mario3.Score}, State : {mario3.GetCurrentState()}");
mario3.ObtainCape();
Console.WriteLine($"Socre : {mario3.Score}, State : {mario3.GetCurrentState()}");