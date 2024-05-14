using Nito.AsyncEx;

namespace ReactiveProgrammingTests
{
    public class UnitTest1
    {
        public class TestClass
        {
            public async Task<bool> ReturnFalse()
            {
                await Task.CompletedTask;
                return false;
            }
            public async Task<bool> ReturnFalseForce()
            {
                await Task.Yield(); // 이 코드 이후 다른 스레드에서 작업
                return false;
            }

            public async void AsyncVoidTest()
            {
                await Task.Yield();
            }
        }

        #region 7.1 async 메서드의 단위 테스트
        [Fact(DisplayName = "async Method Test")]
        public async Task MethodTest()
        {
            var testClass = new TestClass();
            bool result = await testClass.ReturnFalse();
            bool result1 = await testClass.ReturnFalseForce();
            Assert.False(result);
            Assert.False(result1);
        }

        [Fact(DisplayName = "AsyncContext Method Test")]
        public void AsyncContextMethodTest()
        {
            AsyncContext.Run(async () =>
            {
                var testClass = new TestClass();
                bool result = await testClass.ReturnFalse();
                Assert.False(result);
            });
        }
        #endregion

        #region 7.2 async 메서드의 실패 사례를 단위 테스트
        [Fact(DisplayName = "ThrowAsync Test")]
        public async Task ThrowAsyncExceptionTEst()
        {
            await Assert.ThrowsAsync<DivideByZeroException>(async () =>
            {
                await Task.FromException(new DivideByZeroException());
            });
        }
        #endregion

        #region async void 메서드의 단위 테스트
        [Fact(DisplayName = "async void Test")]
        public async Task AsyncVoidTest()
        {
            AsyncContext.Run(() =>
            {
                var testClass = new TestClass();
                testClass.AsyncVoidTest();
            });
        }
        #endregion
        [Fact]
        public void Test1()
        {

        }
    }
}