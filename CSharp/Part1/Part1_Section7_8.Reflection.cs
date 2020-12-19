using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CSharp
{
    class Part1_Section7_8
    {
        class important : System.Attribute
        {
            string message;
            public important(string message) { this.message = message; }
        }

        // 예시
        class Monster
        {
            // hp입니다. 중요한 정보입니다.
            [important("Very Important")]
            // 주석값을 런타임으로 보내는 행위
            public int hp;
            protected int attack;
            private float speed;

            void Attack() { }
        }

        static void Main(string[] args)
        {
            // Reflection : X-ray 를 찍는 것
            // Reflection 을 이용하면 실행중 (런타임중에) 다 뜯어보고 분석 할 수 있다는 것
            Monster monster = new Monster();
            Type type = monster.GetType();
            // GetType은 Object라는 최상위 클래스안에 있는 애들

            var fields = type.GetFields(System.Reflection.BindingFlags.Public
                | System.Reflection.BindingFlags.NonPublic
                | System.Reflection.BindingFlags.Static
                | System.Reflection.BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                string access = "protected";
                if (field.IsPublic)
                    access = "public";
                else if (field.IsPrivate)
                    access = "private";

                var attribute = field.GetCustomAttributes();

                Console.WriteLine($"{access} {field.FieldType.Name} {field.Name}");
            }
        }
    }
}
