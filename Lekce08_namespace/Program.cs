//using v1 = Lekce8_namespace.V1;
using v2 = Lekce8_namespace.V2;

//using Lekce8_namespace.V1;

// kod slouzici k hrani si s namespacy, pochopeni jak funguje using
// a jak pristupovat k implementacim stejnojmenych trid v ruznych namespacich
namespace Lekce8_namespace
{
    class Program
    {
        public static void Main()
        {
            TestV1();
            TestV2();
        }

        // pracuje s classami z V1 namespacu
        // k tomu pristupuje plnym nazvem
        private static void TestV1()
        {
            var human = new Lekce8_namespace.V1.Human();
            var robot = new Lekce8_namespace.V1.Robot();
            var dogRobot = new Lekce8_namespace.V1.DogRobot();

            human.Talk();
            human.Walk();

            robot.Talk();
            robot.Walk();

            dogRobot.Talk();
            dogRobot.Walk();
        }

        // pracuje s classami z V2 namespacu
        // k tomu pristupuje pomoci zkratky v2 zadefinovane na zacatku souboru
        private static void TestV2()
        {
            var human = new v2.Human();
            var robot = new v2.Robot();
            var dogRobot = new v2.DogRobot();

            human.Talk();
            human.Walk();

            robot.Talk();
            robot.Walk();

            dogRobot.Talk();
            dogRobot.Walk();

            dogRobot.Bite();
            dogRobot.EmergencyShutdown();
        }
    }
}
