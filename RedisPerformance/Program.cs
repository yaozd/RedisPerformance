using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Beetle.Redis;

namespace RedisPerformance
{
    /// <summary>
    /// 参考01：BUNOOB.COM--REDIS
    /// http://www.runoob.com/redis/keys-ttl.html
    /// 参考02：
    /// Redis .NET开源组件Beetle.Redis
    /// http://www.cnblogs.com/smark/p/3476596.html
    /// 参考03：
    /// https://github.com/IKende/IKendeLib/wiki/Beetle.Redis
    /// 参考04： 
    /// http://ec.ikende.com/redis
    /// </summary>
    class Program
    {
        //原子计数
        public static int Count;
        //错误原子计数
        public static int ErrorCount;
        //测试数据
        public static Byte[] TestData;
        public static string TestData2;
        public static int TestDataSize = 1 * 1024;
        public static string LogPath = @"D:\temp-test";
        public static string LogName = "log_BeetleRedis.txt";

        static void Main(string[] args)
        {
            BuildTestData2();
            Init();
            //
            while (true)
            {
                try
                {
                    PerformanceTest.Time("Test_Incr", 40, 5000, (Test_Incr));
                    PerformanceTest.Time("Test_Decr", 40, 5000, (Test_Decr));
                    PerformanceTest.Time("Test_Set", 40, 5000, (Test_Set));
                    PerformanceTest.Time("Test_Get", 40, 5000, (Test_Get));
                }
                catch (Exception ex)
                {
                    //记录报错信息
                    var current = Interlocked.Increment(ref ErrorCount);
                    Logger.Info(string.Format("2-Error-Count-{0}-{1}", current, DateTime.Now));
                    Logger.Info(string.Format("2-Error-Count-{0}-{1}", current, ex.Message));
                }

            }

            //
            End();
        }

        static void Demo()
        {
            StringKey key = "-----------------01";
            //从0开始，减1操作，
            var t1 = key.Decr();
            key.Delete();
            //如果获不到值则返回为NULL
            var t2 = key.Get<string>();
        }

        static void Test_Incr()
        {
            StringKey key = "IncrOrDecr";
            var t1 = key.Incr();
        }
        static void Test_Decr()
        {
            StringKey key = "IncrOrDecr";
            var t1 = key.Decr();
        }
        static void Test_Set()
        {
            //
            //设置有过期时间的key的时候必须先设置set,再设置Expire
            var guid = "201606201340";
            StringKey key = guid;
            key.Set(TestData2);//1
            key.Expire(600);//2
            var s = key.TTL();
            if (s == 0)
            {
                var current = Interlocked.Increment(ref Count);
                Console.WriteLine("{0} {1}", current, s);
                Logger.Info(string.Format("Test_Set--{0} {1}--Time:{2}", current, s, DateTime.Now));
            }
        }

        static void Test_Get()
        {
            //
            var guid = "201606201340";
            StringKey key = guid;
            var s = key.Get<string>();
            if (s == null)
            {
                Console.WriteLine(s);
                Logger.Info(string.Format("Test_Get--{0}--Time:{1} ", s, DateTime.Now));
            }
        }
        static void Example()
        {
            var current = Interlocked.Increment(ref Count);
            Logger.Info(current.ToString());
        }

        static void Example_Loop()
        {
            while (true)
            {
                try
                {
                    //
                    PerformanceTest.Time("Test_Set", 40, 5000, (Test_Set));
                    PerformanceTest.Time("Test_Get", 40, 5000, (Test_Get));
                    //
                }
                catch (Exception ex)
                {
                    //记录报错信息
                    var current = Interlocked.Increment(ref ErrorCount);
                    Logger.Info(string.Format("2-Error-Count-{0}-{1}", current, DateTime.Now));
                    Logger.Info(string.Format("2-Error-Count-{0}-{1}", current, ex.Message));
                }
            }
        }
        static void Init()
        {
            Logger.Initialize(LogPath, LogName);
            PerformanceTest.Initialize();
            BuildTestData();
        }
        private static void End()
        {
            Console.WriteLine("Test End");
            Logger.Close();
            Console.Read();
        }
        static void BuildTestData()
        {
            TestData = new byte[TestDataSize];
            for (int i = 0; i < TestDataSize; i++)
            {
                TestData[i] = 0x30;
            }
        }
        static void BuildTestData2()
        {
            for (int i = 0; i < TestDataSize; i++)
            {
                TestData2 += "1";
            }
        }
    }
}
