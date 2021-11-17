using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Creational.ObjectPool
{
    public class ItemsObjectPool : ObjectPool<Item>
    {
        private ICollection<Item> _itemInUse = new List<Item>();

        public ItemsObjectPool(int counter) : base(() => new Item(), counter)
        {
        }


        public override Item Acquire()
        {
                foreach (var item in _itemInUse.ToList())
                {
                    if (!item.IsVisible)
                        Release(item);
                }

            var selectedItem = base.Acquire();
            if (selectedItem == null)
                return null; 

            selectedItem.IsVisible = true;
                _itemInUse.Add(selectedItem);
            return selectedItem;
        }

        public override void Release(Item item)
        {
            _itemInUse.Remove(item);
            base.Release(item);
        }
    }
}
