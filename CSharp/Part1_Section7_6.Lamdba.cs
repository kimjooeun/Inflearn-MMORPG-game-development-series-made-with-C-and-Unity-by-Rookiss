using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    enum ItemType
    {
        Weapon,
        Armor,
        Amulet,
        Ring
    }

    enum Rarity // 희귀성 정의
    {
        Normal,
        Uncommon,
        Rare,
    }

    class Item
    {
        public ItemType ItemType;
        public Rarity Rarity;
    }

    class Part1_Section7_6
    {
        static List<Item> _items = new List<Item>(); // 가상의 인벤토리

        delegate bool ItemSelector(Item item);
        delegate Return MyFunc<T, Return>(T item);
        static Item FindWeapon(MyFunc<Item, bool> selector)
        {
            foreach (Item item in _items)
            {
                if (selector(item))
                    return item;
            }
            return null;
        }

        static bool IsWeapon(Item item)
        {
            return item.ItemType == ItemType.Weapon;
        }

        // 내가 어떤 아이템을 착용하고 있는지 확인할 때
        static Item FindWeapon (ItemSelector selector)
        {
            foreach (Item item in _items)
            {
                if (selector(item))
                    return item;
            }
            return null;
        }

        //static Item FindRareItem()
        //{
        //    foreach (Item item in _items)
        //    {
        //        if (item.Rarity == Rarity.Rare)
        //            return item;
        //    }
        //    return null;
        //}

        // 필요에 따라서 늘리는 것은 벌써부터 힘들며 일일히 치는것은 비효율적.

        static void Main (string[] args)
        {
            _items.Add(new Item() { ItemType = ItemType.Weapon, Rarity = Rarity.Normal });
            _items.Add(new Item() { ItemType = ItemType.Armor, Rarity = Rarity.Uncommon });
            _items.Add(new Item() { ItemType = ItemType.Ring, Rarity = Rarity.Rare });

            // Lambda : 일회용 함수를 만드는데 사용하는 문법이다.
            // 이 친구가 왜 필요한지 예를 들어보겠다.

            // Item item = FindWeapon(IsWeapon);
            // IsWeapon에 1회용 함수를 넣는다.

            // Item item2 = FindWeapon(delegate (Item item) { return item.ItemType == ItemType.Weapon; });
            // 무명함수, 익명함수라고 한다.
            // Anonymous Function

            // Item item3 = FindWeapon( (Item item) => { return item.ItemType == ItemType.Weapon; });
            // 람다식
            // 입력값 , 화살표, 반환값 끝!

            MyFunc<Item, bool> selector = (Item item) => { return item.ItemType == ItemType.Weapon; };
            // 이렇게 사용하면 
            // Item item = FindWeapon(IsWeapon);를 재사용 할 수 있다.
            // 람다의 진짜 함수는 선언을 직접적으로 하지 않고 빠르게 만들 수 있는 방법.

            // delegate를 직접 선언하지 않아도 이미 만들어진 애들이 존재한다
            // > 반환 타입이 있으면 Func
            // > 반환 타입이 없으면 Action
        }
    }
}
