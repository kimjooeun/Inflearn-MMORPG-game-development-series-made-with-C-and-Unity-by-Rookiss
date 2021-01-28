using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class TreeNode<T>
    {
        // 1
        public T Data { get; set; }

        // 2
        public List<TreeNode<T>> Children { get; set; } = new List<TreeNode<T>>();
        // 자식들을 선언하는 함수, 부모들이 누구인지는 모르는 채로 진행하게 된다.
    }

    class Part2_Section5
    {
        // 3
        static TreeNode<String> MakeTree()
        {
            // 맨 위부터 구상
            TreeNode<string> root = new TreeNode<string>() { Data = "R1 개발실" };
            {
                {
                    // 나머지 노드들을 구성
                    TreeNode<string> node = new TreeNode<string>() { Data = "디자인팀" };
                    node.Children.Add(new TreeNode<string>() { Data = "전투" });
                    node.Children.Add(new TreeNode<string>() { Data = "경제" });
                    node.Children.Add(new TreeNode<string>() { Data = "스토리" });
                    root.Children.Add(node);
                }

                {
                    // 나머지 노드들을 구성
                    TreeNode<string> node = new TreeNode<string>() { Data = "프로그래밍팀" };
                    node.Children.Add(new TreeNode<string>() { Data = "서버" });
                    node.Children.Add(new TreeNode<string>() { Data = "클라" });
                    node.Children.Add(new TreeNode<string>() { Data = "엔진" });
                    root.Children.Add(node);
                }

                {
                    // 나머지 노드들을 구성
                    TreeNode<string> node = new TreeNode<string>() { Data = "아트팀" };
                    node.Children.Add(new TreeNode<string>() { Data = "배경" });
                    node.Children.Add(new TreeNode<string>() { Data = "캐릭터" });
                    root.Children.Add(node);
                }
            }
            return root;
        }

        // 4
        static void PrintTree(TreeNode<string> root)
        {
            // 트리는 서브트리의 개념이 있으므로 재귀함수를 구현하면 보다 편리하다

            // 접근
            Console.WriteLine(root.Data);

            foreach (TreeNode<string> child in root.Children)
            {
                PrintTree(child);
            }

        }

        // 5
        // 트리의 높이를 구하는 함수
        static int GetHeight(TreeNode<string> root)
        {
            int height = 0;

            foreach (TreeNode<string> child in root.Children)
            {
                int newHieght = GetHeight(child) + 1;
                //if (height < newHieght)
                //{
                //    height = newHieght;
                //}

                // 위와 같은 의미이다
                height = Math.Max(height, newHieght);
            }

            return height;
        }

        static void Main(string[] args)
        {
            TreeNode<string> root = MakeTree();

            //PrintTree(root);

            Console.WriteLine(GetHeight(root));

        }
    }
}
